using System.Windows;
using System.Windows.Controls;
using Vekto.Models;
using Vekto.ViewModels;

namespace Vekto.Views
{
    public partial class CreateService : UserControl
    {
        private CreateServiceController controller = new CreateServiceController();

        public CreateService()
        {
            InitializeComponent();
            DataContext = controller;
        }

        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            Costumer? costumer = controller.SearchCustomer(tbPhone.Text);

            if (costumer != null)
                lblCustomer.Content = costumer.ToString();
            else
                lblCustomer.Content = "Ingen kunde fundet";
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                string? errorType = cbErrorType.SelectedItem?.ToString();

                Service service = controller.CreateService(tbPhone.Text, tbBrand.Text, tbModel.Text,
                                                           errorType, tbDescription.Text);

                CreateReceipt receipt = new CreateReceipt();
                receipt.ShowService(service.ServiceId);
                receipt.ShowDialog();

                tbSuccess.Text = "Service nr. " + service.ServiceId + " er oprettet.";

                tbPhone.Text = "";
                tbBrand.Text = "";
                tbModel.Text = "";
                cbErrorType.SelectedItem = null;
                tbDescription.Text = "";
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }
    }
}
