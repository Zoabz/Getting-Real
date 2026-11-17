using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using Vekto.Models;
using Vekto.ViewModels;
namespace Vekto.Views
{
    // Side: vises i MainWindow's sideområde
    public partial class CreateCostumer : UserControl
    {
        public CreateCostumer()
        {
            InitializeComponent();
        }

        // UC2: opret kunden
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateCostumerController createCostumer = new CreateCostumerController();

            createCostumer.CreateCostumer(tbName.ToString(),tbPhone.ToString());
            

        }
    }
}

