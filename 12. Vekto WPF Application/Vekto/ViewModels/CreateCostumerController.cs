using System;
using System.Collections.Generic;
using System.Text;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreateCostumerController
    {
        private CostumerRepository costumerRepository;

        public CreateCostumerController()
        {
            costumerRepository = new CostumerRepository();
        }

        public Costumer CreateCostumer(string name, string phoneNumber)
        {
            if (name == "" || phoneNumber == "")
                throw new Exception("Udfyld navn og telefonnummer.");

            Costumer existing = costumerRepository.Get(phoneNumber);
            if (existing != null)
                throw new Exception($"Telefonnummer {phoneNumber} eksisterer allerede. Indtast et andet telefonnummer.");

            Costumer costumer = costumerRepository.Add(name, phoneNumber);
            return costumer;
        }

        public List<Costumer> GetAllCostumers()
        {
            return costumerRepository.GetAll();
        }
    }
}
