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
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("Costumer.csv"))
                {
                    // Read the stream to a string, and instantiate a Person object
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');

                        // parts[0] contains first name, parts[1] contains last name, parts[2] contains age as text, parts[3] contains phone

                        this.Add(parts[0], parts[1]);

                        //Read the next line
                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        public Costumer Add(string name, string phoneNumber)
        {
            Costumer result = null;

            if (!string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(phoneNumber))
            {
                result = new Costumer()
                {
                    Name = name,
                    PhoneNumber = phoneNumber
                };

                // Add to persons list
                costumer.Add(result);
            }
            else
                throw (new ArgumentException("Not all arguments are valid"));

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
            // Find the person in the internal persons list with same Id as the 'id'-parameter
            Costumer foundCostumer = this.Get(phoneNumber);

            if (foundCostumer != null)
            {
                if (!string.IsNullOrEmpty(name) &&
                    !string.IsNullOrEmpty(phoneNumber))
                {
                    // Update only changed properties for this person
                    if (foundCostumer.Name != name)
                        foundCostumer.Name = name;
                    if (foundCostumer.PhoneNumber != phoneNumber)
                        foundCostumer.PhoneNumber = phoneNumber;
                }
                else
                    throw (new ArgumentException("Not all arguments for costumer are valid"));
            }
            else
                throw (new ArgumentException("Costumer with phonenumber = " + phoneNumber + " not found"));
        }

        public void Remove(string phoneNumber)
        {
            // Find the person in the internal persons list with same Id as the 'id'-parameter
            Costumer foundCostumer = this.Get(phoneNumber);

            if (foundCostumer != null)
                costumer.Remove(foundCostumer);
            else
                throw (new ArgumentException("Costumer with phonenumber = " + phoneNumber + " not found"));
        }
    }
}

