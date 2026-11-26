using System.Collections.ObjectModel;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreateCostumerController
    {
        private CostumerRepository costumerRepository = new CostumerRepository();

        public ObservableCollection<Costumer> Costumers { get; }

        public CreateCostumerController()
        {
            Costumers = new ObservableCollection<Costumer>(costumerRepository.GetAll());
        }

        public Costumer CreateCostumer(string name, string phoneNumber)
        {
            name = name.Trim();
            phoneNumber = phoneNumber.Trim();

            if (name == "" || phoneNumber == "")
                throw new Exception("Udfyld navn og telefonnummer.");

            if (name.Contains(',') || phoneNumber.Contains(','))
                throw new Exception("Navn og telefonnummer må ikke indeholde komma.");

            if (costumerRepository.Get(phoneNumber) != null)
                throw new Exception("Telefonnummer " + phoneNumber + " findes allerede. Indtast et andet telefonnummer.");

            Costumer costumer = new Costumer(name, phoneNumber);
            costumerRepository.Add(costumer);
            Costumers.Add(costumer); 
            return costumer;
        }
    }
}
