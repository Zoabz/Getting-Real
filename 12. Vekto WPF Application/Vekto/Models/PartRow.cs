using System;
using System.Collections.Generic;
using System.Text;

namespace Vekto.Models
{
    public class PartRow
    {
        public string Name { get; set; } = "";
        public string Supplier { get; set; } = "";
        public int InStock { get; set; }
        public int Amount { get; set; }
    }
}
