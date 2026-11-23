using Vekto.Models;

namespace Vekto.ViewModels
{
    // UC5: Service oversigt. Registrér det udførte arbejde og luk servicen (følger SD UC5)
    public class ServiceOverviewController
    {
        private ServiceRepository serviceRepository = new ServiceRepository();
        private CostumerRepository costumerRepository = new CostumerRepository();
        private EmployeeRepository employeeRepository = new EmployeeRepository();

        // Alle services, til tabellen "Alle services"
        public List<ServiceRow> GetAllServices()
        {
            List<ServiceRow> rows = new List<ServiceRow>();
            foreach (Service s in serviceRepository.GetAll())
            {
                ServiceRow row = new ServiceRow();
                row.Nr = s.ServiceId;
                row.Kunde = GetCostumerName(s.Customer);
                row.Cykel = s.Brand + " - " + s.Model;
                row.Status = "Åben";
                if (s.Status == ServiceStatus.Closed)
                    row.Status = "Lukket";

                rows.Add(row);
            }
            return rows;
        }

        public Service? GetService(int serviceId)
        {
            return serviceRepository.Get(serviceId);
        }

        // Servicen gemmer kun kundens telefonnummer, så navnet slås op her
        public string GetCostumerName(string phoneNumber)
        {
            Costumer? costumer = costumerRepository.Get(phoneNumber);
            if (costumer == null)
                return "Ukendt kunde";
            return costumer.Name;
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAll();
        }

        // UC5: gem det udførte arbejde. Status ændres til Lukket
        public void RegisterCompletedWork(ServiceRow? row, Employee? employee, string completedWork)
        {
            completedWork = completedWork.Trim();

            if (row == null)
                throw new Exception("Vælg en service.");

            Service? service = serviceRepository.Get(row.Nr);
            if (service == null || service.Status == ServiceStatus.Closed)
                throw new Exception("Service " + row.Nr + " findes ikke eller er allerede lukket.");

            if (employee == null)
                throw new Exception("Vælg en medarbejder.");

            if (completedWork == "")
                throw new Exception("Skriv en beskrivelse af det udførte arbejde.");

            // Komma bruges til at adskille felterne i csv-filen
            if (completedWork.Contains(','))
                throw new Exception("Beskrivelsen må ikke indeholde komma.");

            serviceRepository.RegisterCompletedWork(service.ServiceId, employee.Initials, completedWork);
        }
    }
}
