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

        // Fejltyperne, som ListBox'en er bundet til (ItemsSource="{Binding ErrorTypes}")
        public List<string> ErrorTypes { get; }

        public CreateServiceController()
        {
            costumerRepository = new CostumerRepository();
            serviceRepository = new ServiceRepository();

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

        // UC3: søg efter kunden på telefonnummer. Returnerer null, hvis kunden ikke findes
        public Costumer? SearchCustomer(string phoneNumber)
        {
            return costumerRepository.Get(phoneNumber.Trim());
        }

        // UC3: opret servicen (følger SD UC3)
        public Service CreateService(string phoneNumber, string brand, string model,
                                      string? errorType, string description)
        {
            brand = brand.Trim();
            model = model.Trim();
            description = description.Trim();

            if (brand == "" || model == "" || errorType == null || description == "")
                throw new Exception("Udfyld mærke, model, fejltype og fejlbeskrivelse.");

            // Komma bruges til at adskille felterne i csv-filen
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
