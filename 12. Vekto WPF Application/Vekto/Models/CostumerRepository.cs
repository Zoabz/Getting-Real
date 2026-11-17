using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vekto.Models
{
    class CostumerRepository
    {
        private List<Costumer> costumer;

        public CostumerRepository()
        {
            costumer = new List<Costumer>();
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            using (StreamReader sr = new StreamReader("Costumer.csv"))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(',');


                    this.Add(parts[0], parts[1]);

                    line = sr.ReadLine();
                }
            }
        }

        public Costumer Add(string name, string phoneNumber)
        {
            if (!string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(phoneNumber))
            throw (new ArgumentException("Not all arguments are valid"));
            
                Costumer result = new Costumer()
                {
                    Name = name,
                    PhoneNumber = phoneNumber
                };

                costumer.Add(result);
                return result;
     
        }

        public Costumer Get(string phoneNumber)
        {
            Costumer result = null;

            foreach (Costumer c in costumer)
            {
                if (c.PhoneNumber == phoneNumber)
                {
                    result = c;
                    break;
                }
            }

            return result;
        }


        public List<Costumer> GetAll()
        {
            return costumer;
        }

        public void Update(string name, string phoneNumber)
        {
            Costumer foundCustomer = Get(phoneNumber);

            if (foundCustomer == null)
                throw new ArgumentException("Customer with phonenumber = " + phoneNumber + " not found");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Not all arguments for customer are valid");

            foundCustomer.Name = name;
        }

        public void Remove(string phoneNumber)
        {
            Costumer foundCustomer = this.Get(phoneNumber);

            if (foundCustomer != null)
                throw new ArgumentException("Customer with phonenumber = " + phoneNumber + " not found");

            costumer.Remove(foundCustomer);
        }
    }
}

