using System.Collections.ObjectModel;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreateCostumerController
    {
        private CostumerRepository costumerRepository = new CostumerRepository();

        // Listen, som ListBox'en er bundet til (ItemsSource="{Binding Costumers}")
        public ObservableCollection<Costumer> costumers { get; }

        public CreateCostumerController()
        {
            costumers = new ObservableCollection<Costumer>(costumerRepository.GetAll());
        }

        // UC2: opret kunden (følger SD UC2)
        public Costumer CreateCostumer(string name, string phoneNumber)
        {
            name = name.Trim();
            phoneNumber = phoneNumber.Trim();

            if (name == "" || phoneNumber == "")
                throw new Exception("Udfyld navn og telefonnummer.");

            // Komma bruges til at adskille felterne i csv-filen
            if (name.Contains(',') || phoneNumber.Contains(','))
                throw new Exception("Navn og telefonnummer må ikke indeholde komma.");

            if (costumerRepository.Get(phoneNumber) != null)
                throw new Exception("Telefonnummer " + phoneNumber + " findes allerede. Indtast et andet telefonnummer.");

            Costumer costumer = new Costumer(name, phoneNumber);
            costumerRepository.Add(costumer);
            costumers.Add(costumer); // ListBox'en opdateres selv
            return costumer;
        }
    }
}
