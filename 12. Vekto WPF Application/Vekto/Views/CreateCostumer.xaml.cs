using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using Vekto.Models;
using Vekto.ViewModels;
using System.Windows.Media;
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

            createCostumer.CreateCostumer(tbName.ToString(), tbPhone.ToString());


        }
    
      private void tbPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            // Gray betyder, at det stadig er pladsholderteksten
            if (tbPhone.Foreground == Brushes.Gray)
            {
                tbPhone.Text = "";
                tbPhone.Foreground = Brushes.Black;
            }
        }
        private void tbPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                tbPhone.Text = "Initialerne skal være unikke";
                tbPhone.Foreground = Brushes.Gray;
            }
        }
    }
}

