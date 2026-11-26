using System;
using System.Collections.Generic;
using System.Text;

namespace Vekto.Models
{
    public class Part
    {
        public string Name { get; set; }
        public string Supplier { get; set; }
        public int Quantity { get; set; }
        public int MinQuantity { get; set; }

        public Part(string name, string supplier, int quantity, int minQuantity)
        {
            Name = name;
            Supplier = supplier;
            Quantity = quantity;
            MinQuantity = minQuantity;
        }

        public override string ToString()
        {
            return Name + " (" + Quantity + " på lager)";
        }
    }
}
