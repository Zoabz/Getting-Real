using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Vekto.Models
{
    public class ServiceRepository
    {
        private string fileName = "Service.csv";
        private List<Service> services;

        // Sådan står datoen i csv-filen. Ældre linjer har kun dato uden klokkeslæt
        private string dateFormat = "dd-MM-yyyy HH:mm";
        private string[] readDateFormats = { "dd-MM-yyyy HH:mm", "dd-MM-yyyy" };

        public ServiceRepository()
        {
            services = new List<Service>();
            InitializeRepository();
        }

        // Henter services fra csv-filen. Én service pr. linje:
        // id,dato,mærke,model,fejltype,beskrivelse,status,kundens tlf
        private void InitializeRepository()
        {
            if (!File.Exists(fileName))
                return;

            foreach (string line in File.ReadAllLines(fileName))
            {
                string[] parts = line.Split(',');
                if (parts.Length != 8)
                    continue;

                // Status står som tekst i filen ("Open" eller "Closed")
                ServiceStatus status = ServiceStatus.Open;
                if (parts[6] == "Closed")
                    status = ServiceStatus.Closed;

                services.Add(new Service()
                {
                    ServiceId = int.Parse(parts[0]),
                    DropOffDate = DateTime.ParseExact(parts[1], readDateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    Brand = parts[2],
                    Model = parts[3],
                    ErrorType = parts[4],
                    Description = parts[5],
                    Status = status,
                    Customer = parts[7]
                });
            }
        }

        // Gemmer alle services i csv-filen
        private void Save()
        {
            List<string> lines = new List<string>();
            foreach (Service s in services)
            {
                lines.Add(s.ServiceId + "," + s.DropOffDate.ToString(dateFormat, CultureInfo.InvariantCulture) + "," +
                          s.Brand + "," + s.Model + "," + s.ErrorType + "," + s.Description + "," +
                          s.Status + "," + s.Customer);
            }

            File.WriteAllLines(fileName, lines);
        }

        // Det næste servicenummer er det højeste nummer + 1. Den første service får nr. 1001
        public int GetNextId()
        {
            int nextId = 1001;
            foreach (Service s in services)
            {
                if (s.ServiceId >= nextId)
                    nextId = s.ServiceId + 1;
            }
            return nextId;
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
            Save();
            return result;
        }

        public Service? Get(int serviceId)
        {
            foreach (Service s in services)
            {
                if (s.ServiceId == serviceId)
                    return s;
            }
            return null;
        }

        public List<Service> GetAll()
        {
            return services;
        }

        public void Update(int serviceId, ServiceStatus status, string description)
        {
            Service? foundService = this.Get(serviceId);

            if (foundService != null)
            {
                foundService.Status = status;
                foundService.Description = description;
                Save();
            }
            else
                throw (new ArgumentException("Service with id = " + serviceId + " not found"));
        }

        public void Remove(int serviceId)
        {
            Service? foundService = this.Get(serviceId);

            if (foundService != null)
            {
                services.Remove(foundService);
                Save();
            }
            else
                throw (new ArgumentException("Service with id = " + serviceId + " not found"));
        }
    }
}
