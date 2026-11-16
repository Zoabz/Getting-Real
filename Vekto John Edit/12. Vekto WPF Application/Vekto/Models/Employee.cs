namespace Vekto.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Initials { get; }

        public Employee(string name, string initials)
        {
            Name = name;
            Initials = initials;
        }
    }
}
