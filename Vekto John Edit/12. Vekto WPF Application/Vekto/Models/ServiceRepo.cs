using System.IO;

namespace Vekto.Models
{
    public class ServiceRepo
    {
        private List<Service> services;
        private string fileName = "Service.csv";

        public ServiceRepo()
        {
            services = new List<Service>();
            Load();
        }

        public Service GetById(int serviceId)
        {
            foreach (Service service in services)
            {
                if (service.ServiceId == serviceId)
                    return service;
            }

            return null;
        }

        // Det næste servicenummer er det højeste nummer + 1. Den første service får nr. 1001
        public int GetNextId()
        {
            int nextId = 1001;

            foreach (Service service in services)
            {
                if (service.ServiceId >= nextId)
                    nextId = service.ServiceId + 1;
            }

            return nextId;
        }

        public void Add(Service service)
        {
            services.Add(service);
            Save();
        }

        // Henter services fra tekstfilen. Én service pr. linje:
        // id;dato;mærke;model;fejltype;beskrivelse;status;kundens tlf
        private void Load()
        {
            if (!File.Exists(fileName))
                return;

            // Kunden findes ud fra telefonnummeret, som står sidst i linjen
            CustomerRepo customerRepo = new CustomerRepo();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(';');

                    if (parts.Length == 8)
                    {
                        Customer customer = customerRepo.GetById(parts[7]);
                        Service service = new Service(int.Parse(parts[0]), customer, parts[2], parts[3], parts[4], parts[5]);
                        service.DropOffDate = DateTime.Parse(parts[1]);

                        if (parts[6] == "Closed")
                            service.Status = ServiceStatus.Closed;

                        services.Add(service);
                    }

                    line = reader.ReadLine();
                }
            }
        }

        // Gemmer alle services i tekstfilen
        private void Save()
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Service service in services)
                {
                    writer.WriteLine(service.ServiceId + ";" + service.DropOffDate + ";" + service.Brand + ";" +
                                     service.Model + ";" + service.ErrorType + ";" + service.Description + ";" +
                                     service.Status + ";" + service.Customer.PhoneNumber);
                }
            }
        }
    }
}
