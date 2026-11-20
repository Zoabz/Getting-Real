namespace Vekto.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Initials { get; set; }

        public Employee(string name, string initials)
        {
            Name = name;
            Initials = initials;
        }

        // Det er den tekst, der vises i medarbejderlisten
        public override string ToString()
        {
            return Name + " (" + Initials + ")";
        }
    }
}
