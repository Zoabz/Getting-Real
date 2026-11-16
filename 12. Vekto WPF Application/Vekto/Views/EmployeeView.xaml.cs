using System.Windows;
using System.Windows.Controls;

namespace Vekto.Views
{
    // Side: vises i MainWindow's sideområde
    public partial class OpretMedarbejder : UserControl
    {
        public OpretMedarbejder()
        {
            InitializeComponent();
        }

        // UC1: opret medarbejderen
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            // TODO: opret medarbejderen med CreateEmployeeController.CreateEmployee(...)
        }
    }
}
