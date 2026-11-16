using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vekto.Models
{
    class ServiceRepository
    {
        private List<Service> services;

        public ServiceRepository()
        {
            services = new List<Service>();
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("Service.csv"))
                {
                    // Read the stream to a string, and instantiate a Service object
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');

                        // parts[0] = serviceId, parts[1] = dropOffDate, parts[2] = brand, parts[3] = model,
                        // parts[4] = errorType, parts[5] = description, parts[6] = status, parts[7] = customer
                        this.Add(int.Parse(parts[0]), DateTime.Parse(parts[1]), parts[2], parts[3], parts[4], parts[5], parts[6], parts[7]);

                        //Read the next line
                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        public Service Add(int serviceId, DateTime dropOffDate, string brand, string model, string errorType, string description, string status, string service)
        {
            Service result = null;

            if (!string.IsNullOrEmpty(brand) &&
                !string.IsNullOrEmpty(model) &&
                !string.IsNullOrEmpty(errorType))
            {
                result = new Service()
                {
                    ServiceId = serviceId,
                    DropOffDate = dropOffDate,
                    Brand = brand,
                    Model = model,
                    ErrorType = errorType,
                    Description = description,
                    Status = status,
                    Customer = service
                };

                // Add to services list
                services.Add(result);
            }
            else
                throw (new ArgumentException("Not all arguments are valid"));

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

        public void Update(int serviceId, string status, string description)
        {
            // Find the service in the internal services list with same Id as the 'serviceId'-parameter
            Service foundService = this.Get(serviceId);

            if (foundService != null)
            {
                if (!string.IsNullOrEmpty(status))
                {
                    // Update only changed properties for this service
                    if (foundService.Status != status)
                        foundService.Status = status;
                    if (foundService.Description != description)
                        foundService.Description = description;
                }
                else
                    throw (new ArgumentException("Not all arguments for service are valid"));
            }
            else
                throw (new ArgumentException("Service with id = " + serviceId + " not found"));
        }

        public void Remove(int serviceId)
        {
            // Find the service in the internal services list with same Id as the 'serviceId'-parameter
            Service foundService = this.Get(serviceId);

            if (foundService != null)
                services.Remove(foundService);
            else
                throw (new ArgumentException("Service with id = " + serviceId + " not found"));
        }
    }
}
