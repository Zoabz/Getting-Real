using System;
using System.Collections.Generic;
using System.Text;

namespace Vekto.Models
{
    public class StockRow
    {
        public string Name { get; set; } = "";
        public string Supplier { get; set; } = "";
        public int Quantity { get; set; }
        public int MinQuantity { get; set; }
        public int Missing { get; set; }
        public string Status { get; set; } = "";

        public override string ToString()
        {
            return Name + " (" + Quantity + " på lager)";
        }
    }
}
