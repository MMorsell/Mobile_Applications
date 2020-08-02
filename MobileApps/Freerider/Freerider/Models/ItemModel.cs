using System;
using System.Collections.Generic;
using System.Text;

namespace Freerider.Models
{
    public class ItemModel
    {
        public ItemModel()
        {
        }

        public ItemModel(string fromDestination, string toDestination)
        {
            FromDestination = fromDestination;
            ToDestination = toDestination;
            FormattedString = $"{FromDestination} -> {ToDestination}";
        }

        public int Id { get; set; }
        public string FromDestination { get; set; }
        public string ToDestination { get; set; }
        public string FormattedString { get; set; }

        public void RecalculateFormattedString()
        {
            FormattedString = $"{FromDestination} -> {ToDestination}";
        }
    }
}