using System.Collections.ObjectModel;
using System.ComponentModel;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class ServiceOverviewController : INotifyPropertyChanged
    {
        public class ServiceRow
        {
            public int Number { get; set; }
            public string Customer { get; set; } = "";
            public string Phone { get; set; } = "";
            public string Bike { get; set; } = "";
            public string ErrorType { get; set; } = "";
            public string Description { get; set; } = "";
            public string Status { get; set; } = "";

            // Det er den tekst, der vises i "Vælg service"
            public override string ToString()
            {
                return Number + " · " + Customer + " · " + Bike;
            }
        }

        private ServiceRepository serviceRepository = new ServiceRepository();
        private CostumerRepository costumerRepository = new CostumerRepository();
        private EmployeeRepository employeeRepository = new EmployeeRepository();

        public ObservableCollection<ServiceRow> Services { get; }

        public List<Employee> Employees { get; }

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

        private void LoadServices()
        {
            Services.Clear();
            foreach (Service s in serviceRepository.GetAll())
            {
                ServiceRow row = new ServiceRow();
                row.Number = s.ServiceId;
                row.Customer = GetCostumerName(s.Customer);
                row.Phone = s.Customer;
                row.Bike = s.Brand + " - " + s.Model;
                row.ErrorType = s.ErrorType;
                row.Description = s.Description;
                row.Status = "Åben";
                if (s.Status == ServiceStatus.Closed)
                    row.Status = "Lukket";

                Services.Add(row);
            }
        }

        private string GetCostumerName(string phoneNumber)
        {
            Costumer? costumer = costumerRepository.Get(phoneNumber);
            if (costumer == null)
                return "Ukendt kunde";
            return costumer.Name;
        }

        public int GetSelectedServiceNr()
        {
            if (SelectedService == null)
                throw new Exception("Vælg en service.");

            return SelectedService.Number;
        }

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
