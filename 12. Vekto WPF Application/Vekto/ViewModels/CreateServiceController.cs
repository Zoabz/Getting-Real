using System;
using System.Collections.Generic;
using System.Text;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreateServiceController
    {
        private CostumerRepository costumerRepository;
        private ServiceRepository serviceRepository;

        public List<string> ErrorTypes { get; }

        public List<string> PhoneNumbers { get; } = new List<string>();

        public CreateServiceController()
        {
            costumerRepository = new CostumerRepository();
            serviceRepository = new ServiceRepository();

            foreach (Costumer c in costumerRepository.GetAll())
                PhoneNumbers.Add(c.PhoneNumber);

            ErrorTypes = new List<string>();
            ErrorTypes.Add("Bremser");
            ErrorTypes.Add("Gear");
            ErrorTypes.Add("Dæk/slange");
            ErrorTypes.Add("Kæde");
            ErrorTypes.Add("Lys");
            ErrorTypes.Add("Motor");
            ErrorTypes.Add("Elektronik");
            ErrorTypes.Add("Andet");
        }

        public Costumer? SearchCustomer(string phoneNumber)
        {
            return costumerRepository.Get(phoneNumber.Trim());
        }

        public Service CreateService(string phoneNumber, string brand, string model,
                                      string? errorType, string description)
        {
            brand = brand.Trim();
            model = model.Trim();
            description = description.Trim();

            if (brand == "" || model == "" || errorType == null || description == "")
                throw new Exception("Udfyld mærke, model, fejltype og fejlbeskrivelse.");

            if (brand.Contains(',') || model.Contains(',') || description.Contains(','))
                throw new Exception("Mærke, model og fejlbeskrivelse må ikke indeholde komma.");

            Costumer? costumer = SearchCustomer(phoneNumber);
            if (costumer == null)
                throw new Exception("Find kunden på telefonnummer. Findes kunden ikke, så opret den først under Opret kunde.");

            int serviceId = serviceRepository.GetNextId();

            Service service = serviceRepository.Add(serviceId, DateTime.Now, brand, model,
                errorType, description, ServiceStatus.Open, costumer.PhoneNumber);

            return service;
        }
    }
}
