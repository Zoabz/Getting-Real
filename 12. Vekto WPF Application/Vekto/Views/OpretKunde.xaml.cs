using System.Windows;
using System.Windows.Controls;

namespace Vekto.Views
{
    // Side: vises i MainWindow's sideområde
    public partial class OpretKunde : UserControl
    {
        public OpretKunde()
        {
            InitializeComponent();
        }

        // UC2: opret kunden
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            // TODO: opret kunden med CreateCustomerController.CreateCustomer(...)
        }
    }
}
