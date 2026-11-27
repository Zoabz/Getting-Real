using System.Collections.ObjectModel;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreatePartController
    {
        private PartRepository partRepository = new PartRepository();

        // Listen, som DataGrid'en er bundet til (ItemsSource="{Binding Parts}")
        public ObservableCollection<Part> Parts { get; }

        public CreatePartController()
        {
            Parts = new ObservableCollection<Part>(partRepository.GetAll());
        }

        public Part CreatePart(string name, string supplier, string minQuantityText)
        {
            name = name.Trim();
            supplier = supplier.Trim();

            if (name == "" || supplier == "" || minQuantityText.Trim() == "")
                throw new Exception("Udfyld navn, leverandør og minimum antal.");

            if (name.Contains(',') || supplier.Contains(','))
                throw new Exception("Navn og leverandør må ikke indeholde komma.");

            if (!int.TryParse(minQuantityText.Trim(), out int minQuantity) || minQuantity < 0)
                throw new Exception("Minimum antal skal være et tal på 0 eller mere.");

            if (partRepository.Get(name) != null)
                throw new Exception("Reservedelen " + name + " findes allerede. Indtast et andet navn.");

            Part part = new Part(name, supplier, 0, minQuantity);
            partRepository.Add(part);
            Parts.Add(part); // DataGrid'en opdateres selv
            return part;
        }
    }
}
