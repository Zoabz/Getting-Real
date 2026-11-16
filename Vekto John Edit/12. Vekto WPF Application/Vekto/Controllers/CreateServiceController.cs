using Vekto.Models;

namespace Vekto.Controllers
{
    // UC3 Opret Service
    public class CreateServiceController
    {
        private CustomerRepo customerRepo;
        private ServiceRepo serviceRepo;

        public CreateServiceController()
        {
            customerRepo = new CustomerRepo();
            serviceRepo = new ServiceRepo();
        }

        // Returnerer null, hvis der ikke findes en kunde med telefonnummeret
        public Customer SearchCustomer(string phoneNumber)
        {
            return customerRepo.GetById(phoneNumber.Replace(" ", ""));
        }

        public Service CreateService(string phoneNumber, string brand, string model, string errorType, string description)
        {
            if (brand == "" || model == "" || string.IsNullOrEmpty(errorType) || description == "")
                throw new Exception("Udfyld mærke, model, fejltype og fejlbeskrivelse.");

            Customer customer = SearchCustomer(phoneNumber);
            if (customer == null)
                throw new Exception("Find kunden på telefonnummer. Findes kunden ikke, så opret den først under Opret kunde.");

            int serviceId = serviceRepo.GetNextId();
            Service service = new Service(serviceId, customer, brand, model, errorType, description);
            serviceRepo.Add(service);

            return service;
        }
    }
}
