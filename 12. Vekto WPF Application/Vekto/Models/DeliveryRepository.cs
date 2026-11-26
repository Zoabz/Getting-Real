using System.IO;

namespace Vekto.Models
{
    public class DeliveryRepository
    {
        private string fileName = "Deliveries.csv";
        private List<Delivery> deliveries = new List<Delivery>();

        public DeliveryRepository()
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
                    if (parts.Length == 4)
                        deliveries.Add(new Delivery(DateTime.Parse(parts[0]), parts[1], parts[2], int.Parse(parts[3])));

                    line = sr.ReadLine();
                }
            }
        }

        private void Save()
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Delivery d in deliveries)
                    sw.WriteLine(d.Date + "," + d.PartName + "," + d.Supplier + "," + d.Amount);
            }
        }

        public void Add(Delivery delivery)
        {
            deliveries.Add(delivery);
            Save();
        }

        public List<Delivery> GetAll()
        {
            return deliveries;
        }
    }
}
