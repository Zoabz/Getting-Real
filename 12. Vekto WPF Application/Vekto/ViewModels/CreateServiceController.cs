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

        public CreateServiceController()
        {
            costumerRepository = new CostumerRepository();
            serviceRepository = new ServiceRepository();
        }

        public Costumer SearchCustomer(string phoneNumber)
        {
            return costumerRepository.Get(phoneNumber);
        }

        public Service CreateService(string phoneNumber, string brand, string model, 
                                      string errorType, string description)
        {
            if (brand == "" || model == "" || errorType == "" || description == "")
                throw new Exception("Udfyld mærke, model, fejltype og fejlbeskrivelse.");

            Costumer costumer = SearchCustomer(phoneNumber);
            if (costumer == null)
                throw new Exception("Find kunden på telefonnummer. Findes kunden ikke, så opret den først under Opret kunde.");
            
            int serviceId = serviceRepository.GetAll().Count + 1;

            Service service = serviceRepository.Add(serviceId, DateTime.Now, brand, model,
                errorType, description, ServiceStatus.Open, costumer.PhoneNumber);

            return service;

        }
    }
}
