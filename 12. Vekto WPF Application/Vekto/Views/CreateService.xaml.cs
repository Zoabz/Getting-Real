using System.Windows;
using System.Windows.Controls;

namespace Vekto.Views
{
    // Side: vises i MainWindow's sideområde
    public partial class CreateService : UserControl
    {
        public CreateService()
        {
            InitializeComponent();
        }

        // UC3: søg efter kunden
        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TODO: søg efter kunden med CreateServiceController.SearchCustomer(...)
        }

        // UC3: opret servicen
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            // TODO: opret servicen med CreateServiceController.CreateService(...)
            // og vis kvitteringen bagefter:
             CreateReceipt receipt = new CreateReceipt();
            receipt.ShowDialog();
        }
    }
}
