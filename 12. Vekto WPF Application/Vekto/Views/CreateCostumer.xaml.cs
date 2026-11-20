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

        // Når man klikker i telefonfeltet, skjules den grå tekst
        private void tbPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            tbPhoneHint.Visibility = Visibility.Hidden;
        }

        // Når man forlader feltet, og det er tomt, vises den grå tekst igen
        private void tbPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbPhone.Text == "")
                tbPhoneHint.Visibility = Visibility.Visible;
        }
    }
}

