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

            foreach (string line in File.ReadAllLines(fileName))
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                    costumers.Add(new Costumer(parts[0], parts[1]));
            }
        }
        private void Save()
        {
            List<string> lines = new List<string>();
            foreach (Costumer c in costumers)
                lines.Add(c.Name + "," + c.PhoneNumber);

            File.WriteAllLines(fileName, lines);
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
