using System;
using System.Collections.Generic;
using System.Text;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreateReceiptController
    {
        private ServiceRepository servicerepository;
        private CostumerRepository costumerRepository;
        private EmployeeRepository employeeRepository;

        public CreateReceiptController()
        {
            servicerepository = new ServiceRepository();
            costumerRepository = new CostumerRepository();
            employeeRepository = new EmployeeRepository();
        }

        public List<Service> SearchServices(string searchText, ServiceStatus status)
        {
            List<Service> result = new List<Service>();
            foreach (Service s in servicerepository.GetAll())
            {
                if (s.Status == status)
                {
                    if (searchText == "" || searchText == s.Customer || searchText == s.Brand || searchText == s.Model)
                        result.Add(s);
                }
            }
            return result;
        }

        public Service? GetService(int serviceId)
        {
            return servicerepository.Get(serviceId);
        }

        public Costumer? GetCostumer(string phoneNumber)
        {
            return costumerRepository.Get(phoneNumber);
        }

        public Employee? GetEmployee(string initials)
        {
            return employeeRepository.Get(initials);
        }
    }
}
