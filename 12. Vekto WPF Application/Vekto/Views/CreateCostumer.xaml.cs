using System.Windows;
using System.Windows.Controls;
using Vekto.ViewModels;

namespace Vekto.Views
{
    public partial class CreateCostumer : UserControl
    {
        private CreateCostumerController controller = new CreateCostumerController();

        public CreateCostumer()
        {
            InitializeComponent();
            DataContext = controller;
            ShowCount();
        }

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

        private void ShowCount()
        {
            lblCustomerCount.Content = "Kunder (" + controller.Costumers.Count + ")";
        }
    }
}
