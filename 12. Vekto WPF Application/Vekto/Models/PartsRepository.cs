using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vekto.Models
{
    public class PartRepository
    {
        private string fileName = "Parts.csv";
        private List<Part> Parts = new List<Part>();

        public PartRepository()
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
                    string[] Part = line.Split(',');
                    if (Part.Length == 4)
                        Parts.Add(new Part(Part[0], Part[1], int.Parse(Part[2]), int.Parse(Part[3])));

                    line = sr.ReadLine();
                }
            }
        }

        private void Save()
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Part p in Parts)
                    sw.WriteLine(p.Name + "," + p.Supplier + "," + p.Quantity + "," + p.MinQuantity);
            }
        }

        public void Add(Part Part)
        {
            Parts.Add(Part);
            Save();
        }

        public Part? Get(string Name)
        {
            foreach (Part p in Parts)
            {
                if (p.Name == Name)
                    return p;
            }
            return null;
        }

        public void TakeOut(string name, int amount)
        {
            Part? part = Get(name);
            if (part == null || part.Quantity < amount)
                throw new Exception("Der er ikke nok " + name + " på lager.");

            part.Quantity -= amount;
            Save();
        }

        public List<Part> GetAll()
        {
            return Parts;
        }
    }
}
