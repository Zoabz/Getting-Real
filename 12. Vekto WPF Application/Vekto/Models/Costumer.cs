namespace Vekto.Models
{
    public class Costumer
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Costumer(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        // Det er den tekst, der vises i kundelisten
        public override string ToString()
        {
            return Name + " (" + PhoneNumber + ")";
        }
    }
}
