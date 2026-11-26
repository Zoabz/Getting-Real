using System;
using System.Collections.Generic;
using System.Text;

namespace Vekto.Models
{
    public class ServiceRow
    {
        public int Number { get; set; }
        public string Customer { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Bike { get; set; } = "";
        public string ErrorType { get; set; } = "";
        public string Description { get; set; } = "";
        public string Status { get; set; } = "";

        // Det er den tekst, der vises i "Vælg service"
        public override string ToString()
        {
            return Number + " · " + Customer + " · " + Bike;
        }
    }
}
