using System.Windows.Controls;
using Vekto.ViewModels;

namespace Vekto.Views
{
    public partial class StockOverview : UserControl
    {
        private StockOverviewController controller = new StockOverviewController();

        public StockOverview()
        {
            InitializeComponent();
            DataContext = controller;
        }
    }
}
