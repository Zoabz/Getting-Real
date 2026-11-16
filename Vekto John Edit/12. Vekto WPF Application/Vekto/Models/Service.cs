namespace Vekto.Models
{
    public class Service
    {
        public int ServiceId { get; }
        public DateTime DropOffDate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ErrorType { get; set; }
        public string Description { get; set; }
        public ServiceStatus Status { get; set; }
        public Customer Customer { get; set; }

        public Service(int serviceId, Customer customer, string brand, string model, string errorType, string description)
        {
            ServiceId = serviceId;
            Customer = customer;
            Brand = brand;
            Model = model;
            ErrorType = errorType;
            Description = description;

            // En ny service er indleveret i dag og har status Åben
            DropOffDate = DateTime.Now;
            Status = ServiceStatus.Open;
        }
    }
}
