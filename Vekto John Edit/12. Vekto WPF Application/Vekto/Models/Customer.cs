namespace Vekto.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string PhoneNumber { get; }

        public Customer(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
