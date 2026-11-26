using System.Collections.ObjectModel;
using System.ComponentModel;
using Vekto.Models;
using static Vekto.ViewModels.StockOverviewController;

namespace Vekto.ViewModels
{
    public class PartsReceiveController : INotifyPropertyChanged
    {
        private PartRepository partRepository = new PartRepository();
        private DeliveryRepository deliveryRepository = new DeliveryRepository();

        public ObservableCollection<StockRow> OrderList { get; } = new ObservableCollection<StockRow>();
        public ObservableCollection<Delivery> Deliveries { get; } = new ObservableCollection<Delivery>();

        private StockRow? selectedPart;
        public StockRow? SelectedPart
        {
            get { return selectedPart; }
            set
            {
                selectedPart = value;
                OnPropertyChanged(nameof(SelectedPart));

                if (value != null)
                    Amount = value.Missing.ToString();
            }
        }

        private string amount = "";
        public string Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged(nameof(Amount)); }
        }

        public PartsReceiveController()
        {
            LoadOrderList();

            foreach (Delivery d in deliveryRepository.GetAll())
                Deliveries.Insert(0, d);
        }

        private void LoadOrderList()
        {
            OrderList.Clear();
            foreach (Part p in partRepository.GetAll())
            {
                if (p.Quantity >= p.MinQuantity)
                    continue;

                StockRow row = new StockRow();
                row.Name = p.Name;
                row.Supplier = p.Supplier;
                row.Quantity = p.Quantity;
                row.MinQuantity = p.MinQuantity;
                row.Missing = p.MinQuantity - p.Quantity;
                OrderList.Add(row);
            }
        }

        public Delivery Receive(string amountText, DateTime? date)
        {
            if (SelectedPart == null)
                throw new Exception("Vælg en reservedel.");

            if (!int.TryParse(amountText.Trim(), out int received) || received < 1)
                throw new Exception("Antal modtaget skal være et tal større end 0.");

            if (date == null)
                throw new Exception("Vælg en dato.");

            if (date.Value.Date > DateTime.Today)
                throw new Exception("Datoen må ikke ligge i fremtiden.");

            partRepository.Receive(SelectedPart.Name, received);

            Delivery delivery = new Delivery(date.Value.Date, SelectedPart.Name, SelectedPart.Supplier, received);
            deliveryRepository.Add(delivery);
            Deliveries.Insert(0, delivery);

            SelectedPart = null;
            Amount = "";
            LoadOrderList();

            return delivery;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
