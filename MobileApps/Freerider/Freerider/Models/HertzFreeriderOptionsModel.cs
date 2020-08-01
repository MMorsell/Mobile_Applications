using System;
using System.Collections.Generic;
using System.Text;

namespace Freerider.Models
{
    public class HertzFreeriderOptionsModel
    {
        public HertzFreeriderOptionsModel()
        {
            DestinationOptions = new List<string>()
            {
                "aaa",
                "vvbb"
            };
        }

        public List<string> DestinationOptions { get; set; }
    }
}