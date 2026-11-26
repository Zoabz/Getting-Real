using System.Collections.ObjectModel;
using System.ComponentModel;
using Vekto.Models;
using static Vekto.ViewModels.ServiceOverviewController;

namespace Vekto.ViewModels
{
    public class PartsGrabController : INotifyPropertyChanged
    {
        public class PartRow
        {
            public string Name { get; set; } = "";
            public string Supplier { get; set; } = "";
            public int InStock { get; set; }
            public int Amount { get; set; }
        }

        private PartRepository partRepository = new PartRepository();
        private ServiceRepository serviceRepository = new ServiceRepository();
        private CostumerRepository costumerRepository = new CostumerRepository();
        private EmployeeRepository employeeRepository = new EmployeeRepository();

        public List<ServiceRow> Services { get; } = new List<ServiceRow>();
        public List<Employee> Employees { get; }
        public List<Part> Parts { get; }
        public ObservableCollection<PartRow> PartsList { get; } = new ObservableCollection<PartRow>();

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

        private Part? selectedPart;
        public Part? SelectedPart
        {
            get { return selectedPart; }
            set { selectedPart = value; OnPropertyChanged(nameof(SelectedPart)); }
        }

        public PartsGrabController()
        {
            Employees = employeeRepository.GetAll();
            Parts = partRepository.GetAll();

            foreach (Service s in serviceRepository.GetAll())
            {
                if (s.Status == ServiceStatus.Closed)
                    continue;

                ServiceRow row = new ServiceRow();
                row.Number = s.ServiceId;
                row.Customer = GetCostumerName(s.Customer);
                row.Bike = s.Brand + " - " + s.Model;
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

        public void AddPart(string amountText)
        {
            if (SelectedPart == null)
                throw new Exception("Vælg en reservedel.");

            if (!int.TryParse(amountText, out int amount) || amount < 1)
                throw new Exception("Amount skal være et tal større end 0.");

            PartRow? existing = null;
            foreach (PartRow r in PartsList)
            {
                if (r.Name == SelectedPart.Name)
                    existing = r;
            }

            if (existing != null)
                amount += existing.Amount;

            if (amount > SelectedPart.Quantity)
                throw new Exception("Der er kun " + SelectedPart.Quantity + " " + SelectedPart.Name + " på lager.");

            PartRow row = new PartRow();
            row.Name = SelectedPart.Name;
            row.Supplier = SelectedPart.Supplier;
            row.InStock = SelectedPart.Quantity;
            row.Amount = amount;

            if (existing == null)
                PartsList.Add(row);
            else
                PartsList[PartsList.IndexOf(existing)] = row;
        }

        public void RemovePart(PartRow row)
        {
            PartsList.Remove(row);
        }

        public int Save()
        {
            if (SelectedService == null)
                throw new Exception("Vælg en service.");

            if (SelectedEmployee == null)
                throw new Exception("Vælg en medarbejder.");

            if (PartsList.Count == 0)
                throw new Exception("Tilføj mindst én reservedel til listen.");

            foreach (PartRow row in PartsList)
                partRepository.TakeOut(row.Name, row.Amount);

            int serviceNr = SelectedService.Number;
            PartsList.Clear();
            return serviceNr;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
