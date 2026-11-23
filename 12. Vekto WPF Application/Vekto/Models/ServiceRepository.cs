using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vekto.Models
{
    public class ServiceRepository
    {
        private string fileName = "Service.csv";
        private List<Service> services;

        public ServiceRepository()
        {
            services = new List<Service>();
            InitializeRepository();
        }

        // Henter services fra csv-filen. Én service pr. linje:
        // id,dato,mærke,model,fejltype,beskrivelse,status,kundens tlf,udført arbejde,medarbejder,lukket dato
        // Ældre linjer har kun de første 8 felter
        private void InitializeRepository()
        {
            if (!File.Exists(fileName))
                return;

            using (StreamReader sr = new StreamReader(fileName))
            {
                string? line = sr.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 8 || parts.Length == 11)
                    {
                        Service service = new Service(int.Parse(parts[0]), DateTime.Parse(parts[1]),
                            parts[2], parts[3], parts[4], parts[5], parts[7]);

                        // Status står som tekst i filen ("Open" eller "Closed")
                        if (parts[6] == "Closed")
                            service.Status = ServiceStatus.Closed;

                        if (parts.Length == 11)
                        {
                            service.CompletedWork = parts[8];
                            service.Employee = parts[9];
                            if (parts[10] != "")
                                service.ClosedDate = DateTime.Parse(parts[10]);
                        }

                        services.Add(service);
                    }

                    line = sr.ReadLine();
                }
            }
        }

        // Gemmer alle services i csv-filen.
        // ClosedDate er tom tekst, så længe servicen ikke er lukket (null)
        private void Save()
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Service s in services)
                {
                    sw.WriteLine(s.ServiceId + "," + s.DropOffDate + "," + s.Brand + "," + s.Model + "," +
                                 s.ErrorType + "," + s.Description + "," + s.Status + "," + s.Customer + "," +
                                 s.CompletedWork + "," + s.Employee + "," + s.ClosedDate);
                }
            }
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

            Service result = new Service(serviceId, dropOffDate, brand, model, errorType, description, costumer);
            result.Status = status;

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

        // UC5: gem det udførte arbejde og luk servicen
        public void RegisterCompletedWork(int serviceId, string employeeInitials, string completedWork)
        {
            Service? foundService = this.Get(serviceId);

            if (foundService != null)
            {
                foundService.CompletedWork = completedWork;
                foundService.Employee = employeeInitials;
                foundService.ClosedDate = DateTime.Now;
                foundService.Status = ServiceStatus.Closed;
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
