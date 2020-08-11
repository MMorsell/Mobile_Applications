using Freerider.Models;
using HpScraper.Enums;
using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                HpScraper.Helpers.WebscraperHelper.GetNewUpdate();
            }
        }
    }
}