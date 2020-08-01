using System;
using System.Collections.Generic;
using System.Text;

namespace Freerider.Models
{
    public class SubscribeModel
    {
        public int Id { get; set; }
        public string FromDestination { get; set; }
        public string ToDestination { get; set; }
    }
}