using Vekto.Models;

namespace Vekto.ViewModels
{
    public class StockOverviewController
    {
        private PartRepository partRepository = new PartRepository();

        public List<StockRow> Parts { get; } = new List<StockRow>();
        public List<StockRow> OrderList { get; } = new List<StockRow>();
        public string Summary { get; }
        public string OrderTitle { get; }

        public StockOverviewController()
        {
            foreach (Part p in partRepository.GetAll())
            {
                StockRow row = new StockRow();
                row.Name = p.Name;
                row.Supplier = p.Supplier;
                row.Quantity = p.Quantity;
                row.MinQuantity = p.MinQuantity;
                row.Missing = p.MinQuantity - p.Quantity;
                row.Status = "OK";

                if (row.Missing > 0)
                {
                    row.Status = "Skal bestilles";

                    int index = 0;
                    while (index < OrderList.Count && OrderList[index].Missing >= row.Missing)
                        index++;
                    OrderList.Insert(index, row);
                }

                Parts.Add(row);
            }

            Summary = Parts.Count + " reservedele · " + OrderList.Count + " skal bestilles";
            OrderTitle = "Skal bestilles (" + OrderList.Count + ")";
        }
    }
}
