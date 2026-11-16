using Vekto.Models;

namespace Vekto.Controllers
{
    // UC2 Opret Kunde
    public class CreateCustomerController
    {
        private CustomerRepo customerRepo;

        public CreateCustomerController()
        {
            customerRepo = new CustomerRepo();
        }

        public Customer CreateCustomer(string name, string phoneNumber)
        {
            // Mellemrum fjernes, fx bliver "+45 23 12 94 28" til "+4523129428"
            phoneNumber = phoneNumber.Replace(" ", "");

            if (name == "" || phoneNumber.Length < 8)
                throw new Exception("Skriv kundens navn og et telefonnummer med mindst 8 cifre, fx +4523129428.");

            Customer existingCustomer = customerRepo.GetById(phoneNumber);
            if (existingCustomer != null)
                throw new Exception("Kunden findes allerede: " + existingCustomer.Name + " (" + phoneNumber + ").");

            Customer customer = new Customer(name, phoneNumber);
            customerRepo.Add(customer);

            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            return customerRepo.GetAll();
        }
    }
}
