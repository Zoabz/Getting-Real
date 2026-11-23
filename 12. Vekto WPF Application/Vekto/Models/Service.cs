using System;
using System.Collections.Generic;
using System.Text;

namespace Vekto.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public DateTime DropOffDate { get; set; }
        public string Brand { get; set; } = "";
        public string Model { get; set; } = "";
        public string ErrorType { get; set; } = "";
        public string Description { get; set; } = "";
        public ServiceStatus Status { get; set; }
        public string Customer { get; set; } = ""; // Kundens telefonnummer
    }
}
