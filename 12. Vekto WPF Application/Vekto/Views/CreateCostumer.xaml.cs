using System.Windows;
using System.Windows.Controls;
using Vekto.Models;
using Vekto.ViewModels;

namespace Vekto.Views
{
    // Side: vises i MainWindow's sideområde
    public partial class CreateCostumer : UserControl
    {
        private CreateCostumerController controller = new CreateCostumerController();

        public CreateCostumer()
        {
            InitializeComponent();
            ShowCostumers();
        }

        // Opretter Kunden
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Costumer costumer = controller.CreateCostumer(tbName.Text, tbPhone.Text);

                tbName.Text = "";
                tbPhone.Text = "";
                tbPhoneHint.Visibility = Visibility.Visible; // Feltet er tomt igen, så den grå tekst vises
                ShowCostumers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Fylder kundelisten og tæller kunderne
        private void ShowCostumers()
        {
            lbCustomers.Items.Clear();
            foreach (Costumer c in controller.GetAllCostumers())
                lbCustomers.Items.Add(c);

            lblCustomerCount.Content = "Kunder (" + lbCustomers.Items.Count + ")";
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
