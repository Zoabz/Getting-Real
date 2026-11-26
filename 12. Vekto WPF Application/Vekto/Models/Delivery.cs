namespace Vekto.Models
{
    public class Delivery
    {
        public DateTime Date { get; set; }
        public string PartName { get; set; }
        public string Supplier { get; set; }
        public int Amount { get; set; }

        public Delivery(DateTime date, string partName, string supplier, int amount)
        {
            Date = date;
            PartName = partName;
            Supplier = supplier;
            Amount = amount;
        }
    }
}
