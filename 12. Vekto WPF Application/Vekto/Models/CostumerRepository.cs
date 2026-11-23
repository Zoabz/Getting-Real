using System.IO;

namespace Vekto.Models
{
    public class CostumerRepository
    {
        private string fileName = "Costumer.csv";
        private List<Costumer> costumers = new List<Costumer>();

        public CostumerRepository()
        {
            Load();
        }

        private void Load()
        {
            if (!File.Exists(fileName))
                return;

            using (StreamReader sr = new StreamReader(fileName))
            {
                string? line = sr.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                        costumers.Add(new Costumer(parts[0], parts[1]));

                    line = sr.ReadLine();
                }
            }
        }

        private void Save()
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Costumer c in costumers)
                    sw.WriteLine(c.Name + "," + c.PhoneNumber);
            }
        }

        public void Add(Costumer costumer)
        {
            costumers.Add(costumer);
            Save();
        }

        public Costumer? Get(string phoneNumber)
        {
            foreach (Costumer c in costumers)
            {
                if (c.PhoneNumber == phoneNumber)
                    return c;
            }
            return null;
        }

        public List<Costumer> GetAll()
        {
            return costumers;
        }
    }
}
