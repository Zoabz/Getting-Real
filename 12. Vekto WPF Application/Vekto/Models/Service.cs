using System;
using System.Collections.Generic;
using System.Text;

namespace Vekto.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public DateTime DropOffDate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ErrorType { get; set; }
        public string Description { get; set; }
        public ServiceStatus Status { get; set; }
        public string Customer { get; set; } // Kundens telefonnummer

        // UC5: udfyldes, når det udførte arbejde gemmes og servicen lukkes
        public string CompletedWork { get; set; } = "";
        public string Employee { get; set; } = ""; // Medarbejderens initialer
        public DateTime? ClosedDate { get; set; }

        public Service(int serviceId, DateTime dropOffDate, string brand, string model,
                       string errorType, string description, string customer)
        {
            ServiceId = serviceId;
            DropOffDate = dropOffDate;
            Brand = brand;
            Model = model;
            ErrorType = errorType;
            Description = description;
            Customer = customer;
            Status = ServiceStatus.Open;
        }
    }
}
