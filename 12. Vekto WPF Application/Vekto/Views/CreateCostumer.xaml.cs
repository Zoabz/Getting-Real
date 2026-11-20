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
                ShowCostumers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowCostumers()
        {
            lbCustomers.Items.Clear();
            foreach (Costumer c in controller.GetAllCostumers())
                lbCustomers.Items.Add(c);

            lblCustomerCount.Content = "Kunder (" + lbCustomers.Items.Count + ")";
        }
    }
}
