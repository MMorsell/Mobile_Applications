using HpScraper.Enums;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HpScraper.Helpers
{
    public class WebscraperHelper
    {
        private static bool _firstListen { get; set; } = true;
        private static readonly string _url = "https://store.hp.com/SwedenStore/Merch/Product.aspx?id=158P3EA&opt=UUW&sel=NTB";
        private static HtmlDocument previousHtmlDocument = new HtmlDocument();

        public static UpdateType GetNewUpdate()
        {
            using (var myWebClient = new WebClient())
            {
                myWebClient.Headers["User-Agent"] = "MOZILLA/5.0 (WINDOWS NT 6.1; WOW64) APPLEWEBKIT/537.1 (KHTML, LIKE GECKO) CHROME/21.0.1180.75 SAFARI/537.1";

                string page = myWebClient.DownloadString(_url);

                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(page);

                var innerBlockHtmlNodes = htmlDocument.DocumentNode.SelectNodes("//a[@class = 'js-product-add-to-cart pb-cta__btn pb-cta__btn--color-2 pb-cta__btn--with-select']");

                InitializePreviousDocument(htmlDocument);

                if (innerBlockHtmlNodes != null && innerBlockHtmlNodes[0].InnerText.Equals("Lägg i kundvagnen", StringComparison.CurrentCultureIgnoreCase))
                {
                    return UpdateType.Major;
                }

                if (!_firstListen)
                {
                    if (htmlDocument.DocumentNode.OuterHtml != previousHtmlDocument.DocumentNode.OuterHtml)
                    {
                        previousHtmlDocument = htmlDocument;
                        return UpdateType.Minor;
                    }
                }
            }

            return UpdateType.No_Difference;
        }

        private static void InitializePreviousDocument(HtmlDocument htmlDocument)
        {
            if (_firstListen)
            {
                previousHtmlDocument = htmlDocument;
                _firstListen = false;
            }
        }
    }
}