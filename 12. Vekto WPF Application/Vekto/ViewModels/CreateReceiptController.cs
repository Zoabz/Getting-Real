using System;
using System.Collections.Generic;
using System.Text;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreateReceiptController
    {
        private ServiceRepository servicerepository;

        public CreateReceiptController()
        {
            servicerepository = new ServiceRepository();
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

        public Service GetService(int serviceId)
        {
            return servicerepository.Get(serviceId);
        }
    }
}
