using System.Windows;
using System.Windows.Controls;
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
            DataContext = controller;
            ShowCount();
        }

        // UC2: opret kunden
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";

            try
            {
                controller.CreateCostumer(tbName.Text, tbPhone.Text);

                tbName.Text = "";
                tbPhone.Text = "";
                ShowCount();
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }

        // Tæller kunderne i listen
        private void ShowCount()
        {
            lblCustomerCount.Content = "Kunder (" + controller.Costumers.Count + ")";
        }
    }
}
