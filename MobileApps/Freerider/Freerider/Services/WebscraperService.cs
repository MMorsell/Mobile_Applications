using Freerider.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Freerider.Services
{
    public class WebscraperService
    {
        private static readonly string url = "https://www.hertzfreerider.se/unauth/list_transport_offer.aspx";

        public static List<ItemModel> GetNewUpdate()
        {
            HtmlWeb web = new HtmlWeb();
            //TODO: Async freezes the thread indefinently, bug?
            var htmlDocument = web.Load(url);
            //var htmlDoc = await web.LoadFromWebAsync(url);

            var innerBlockHtmlNodes = htmlDocument.DocumentNode.SelectNodes("//tr[@class = 'highlight']");

            return ConvertNodesToResult(innerBlockHtmlNodes[0].SelectNodes("//a"));
        }

        private static List<ItemModel> ConvertNodesToResult(HtmlNodeCollection nodeCollection)
        {
            /*
             * Startresult is "hem"
             * Split is "Boka"
             * End is www.hertz.se
             */
            bool start = false;
            var returnModels = new List<ItemModel>();
            var itemModelPlaceHolder = new Freerider.Models.ItemModel();
            itemModelPlaceHolder = null;

            foreach (var node in nodeCollection)
            {
                if (start)
                {
                    if (node.InnerText.Equals("www.hertz.se", StringComparison.CurrentCultureIgnoreCase))
                    {
                        start = false;
                    }
                    else
                    {
                        if (node.InnerText.Equals("Boka", StringComparison.CurrentCultureIgnoreCase))
                        {
                            returnModels.Add(new ItemModel(itemModelPlaceHolder.FromDestination, itemModelPlaceHolder.ToDestination));
                            itemModelPlaceHolder = null;
                        }
                        else if (itemModelPlaceHolder == null)
                        {
                            itemModelPlaceHolder = new Freerider.Models.ItemModel();
                            itemModelPlaceHolder.FromDestination = node.InnerText;
                        }
                        else
                        {
                            itemModelPlaceHolder.ToDestination = node.InnerText;
                        }
                    }
                }
                if (node.InnerText.Equals(""))
                {
                    start = true;
                }
            }

            return returnModels;
        }
    }
}