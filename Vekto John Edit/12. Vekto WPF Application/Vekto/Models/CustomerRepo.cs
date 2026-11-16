using System.IO;

namespace Vekto.Models
{
    public class CustomerRepo
    {
        private List<Customer> customers;
        private string fileName = "Customer.csv";

        public CustomerRepo()
        {
            customers = new List<Customer>();
            Load();
        }

        public Customer GetById(string phoneNumber)
        {
            foreach (Customer customer in customers)
            {
                if (customer.PhoneNumber == phoneNumber)
                    return customer;
            }

            return null;
        }

        public List<Customer> GetAll()
        {
            return customers;
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
            Save();
        }

        // Henter kunderne fra tekstfilen. Én kunde pr. linje: navn;tlf
        private void Load()
        {
            if (!File.Exists(fileName))
                return;

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(';');

                    if (parts.Length == 2)
                        customers.Add(new Customer(parts[0], parts[1]));

                    line = reader.ReadLine();
                }
            }
        }

        // Gemmer alle kunderne i tekstfilen
        private void Save()
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Customer customer in customers)
                {
                    writer.WriteLine(customer.Name + ";" + customer.PhoneNumber);
                }
            }
        }
    }
}
