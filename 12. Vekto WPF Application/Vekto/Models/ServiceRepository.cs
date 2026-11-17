using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vekto.Models
{
    public class ServiceRepository
    {
        private List<Service> services;

        public ServiceRepository()
        {
            services = new List<Service>();
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            using (StreamReader sr = new StreamReader("Service.csv"))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(',');

                    // Status står som tekst i filen ("Open" eller "Closed")
                    ServiceStatus status = ServiceStatus.Open;
                    if (parts[6] == "Closed")
                        status = ServiceStatus.Closed;

                    this.Add(int.Parse(parts[0]), DateTime.Parse(parts[1]),
                        parts[2], parts[3], parts[4], parts[5], status, parts[7]);

                    line = sr.ReadLine();
                }
            }
        }

        public Service Add(int serviceId, DateTime dropOffDate, string brand, string model,
                           string errorType, string description, ServiceStatus status, string costumer)
        {
            if (string.IsNullOrEmpty(brand) ||
                string.IsNullOrEmpty(model) ||
                string.IsNullOrEmpty(errorType))
                throw (new ArgumentException("Not all arguments are valid"));

            Service result = new Service()
            {
                ServiceId = serviceId,
                DropOffDate = dropOffDate,
                Brand = brand,
                Model = model,
                ErrorType = errorType,
                Description = description,
                Status = status,
                Customer = costumer
            };

            services.Add(result);
            return result;
        }

        public Service Get(int serviceId)
        {
            Service result = null;

            foreach (Service s in services)
            {
                if (s.ServiceId == serviceId)
                {
                    result = s;
                    break;
                }
            }

            return result;
        }

        public List<Service> GetAll()
        {
            return services;
        }

        public void Update(int serviceId, ServiceStatus status, string description)
        {
            Service foundService = this.Get(serviceId);

            if (foundService != null)
            {
                foundService.Status = status;
                foundService.Description = description;
            }
            else
                throw (new ArgumentException("Service with id = " + serviceId + " not found"));
        }

        public void Remove(int serviceId)
        {
            Service foundService = this.Get(serviceId);

            if (foundService != null)
                services.Remove(foundService);
            else
                throw (new ArgumentException("Service with id = " + serviceId + " not found"));
        }
    }
}