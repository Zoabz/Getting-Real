using System.Collections.ObjectModel;
using System.ComponentModel;
using Vekto.Models;

namespace Vekto.ViewModels
{
    // UC5: Service oversigt. Registrér det udførte arbejde og luk servicen (følger SD UC5)
    public class ServiceOverviewController : INotifyPropertyChanged
    {
        private ServiceRepository serviceRepository = new ServiceRepository();
        private CostumerRepository costumerRepository = new CostumerRepository();
        private EmployeeRepository employeeRepository = new EmployeeRepository();

        // Tabellen og "Vælg service" er bundet til Services
        public ObservableCollection<ServiceRow> Services { get; }

        // "Vælg medarbejder" er bundet til Employees
        public List<Employee> Employees { get; }

        // Den valgte service. Både tabellen og "Vælg service" er bundet til den,
        // så vælger man i den ene, bliver den også valgt i den anden
        private ServiceRow? selectedService;
        public ServiceRow? SelectedService
        {
            get { return selectedService; }
            set { selectedService = value; OnPropertyChanged(nameof(SelectedService)); }
        }

        private Employee? selectedEmployee;
        public Employee? SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; OnPropertyChanged(nameof(SelectedEmployee)); }
        }

        public ServiceOverviewController()
        {
            Services = new ObservableCollection<ServiceRow>();
            Employees = employeeRepository.GetAll();
            LoadServices();
        }

        // Fylder Services med alle services fra repository
        private void LoadServices()
        {
            Services.Clear();
            foreach (Service s in serviceRepository.GetAll())
            {
                ServiceRow row = new ServiceRow();
                row.Nr = s.ServiceId;
                row.Kunde = GetCostumerName(s.Customer);
                row.Telefon = s.Customer;
                row.Cykel = s.Brand + " - " + s.Model;
                row.Fejltype = s.ErrorType;
                row.Beskrivelse = s.Description;
                row.Status = "Åben";
                if (s.Status == ServiceStatus.Closed)
                    row.Status = "Lukket";

                Services.Add(row);
            }
        }

        // Servicen gemmer kun kundens telefonnummer, så navnet slås op her
        private string GetCostumerName(string phoneNumber)
        {
            Costumer? costumer = costumerRepository.Get(phoneNumber);
            if (costumer == null)
                return "Ukendt kunde";
            return costumer.Name;
        }

        // Nummeret på den valgte service, fx til kvitteringen
        public int GetSelectedServiceNr()
        {
            if (SelectedService == null)
                throw new Exception("Vælg en service.");

            return SelectedService.Nr;
        }

        // UC5: gem det udførte arbejde. Status ændres til Lukket.
        // Returnerer nummeret på den service, der blev lukket
        public int RegisterCompletedWork(string completedWork)
        {
            completedWork = completedWork.Trim();

            int serviceNr = GetSelectedServiceNr();

            Service? service = serviceRepository.Get(serviceNr);
            if (service == null || service.Status == ServiceStatus.Closed)
                throw new Exception("Service " + serviceNr + " findes ikke eller er allerede lukket.");

            if (SelectedEmployee == null)
                throw new Exception("Vælg en medarbejder.");

            if (completedWork == "")
                throw new Exception("Skriv en beskrivelse af det udførte arbejde.");

            // Komma bruges til at adskille felterne i csv-filen
            if (completedWork.Contains(','))
                throw new Exception("Beskrivelsen må ikke indeholde komma.");

            serviceRepository.RegisterCompletedWork(serviceNr, SelectedEmployee.Initials, completedWork);

            // Hent listen igen, så den nye status vises i tabellen
            LoadServices();
            SelectedService = null;
            SelectedEmployee = null;

            return serviceNr;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
