using Freerider.Models;
using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    internal class Program
    {
        private static readonly string url = "https://www.hertzfreerider.se/unauth/list_transport_offer.aspx";

        private static void Main(string[] args)
        {
            GetNewUpdate().Wait();
        }

        private static async Task<List<Freerider.Models.ItemModel>> GetNewUpdate()
        {
            var result = new List<Freerider.Models.ItemModel>();
            var regexMatchOnFalun = new Regex("target[=][\"]stationInfo[\"][>]Falun[<][/]");
            var webInterface = new HtmlWeb();

            var htmlDocument = await webInterface.LoadFromWebAsync(url);

            var innerBlockHtmlNodes = htmlDocument.DocumentNode.SelectNodes("//tr[@class = 'highlight']");

            int totalNumberOfMatches = 0;

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