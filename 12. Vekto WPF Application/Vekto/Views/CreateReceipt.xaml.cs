using System.Windows;
using Vekto.Models;
using Vekto.ViewModels;

namespace Vekto.Views
{
    // Dialog: åbnes fra Opret service med ShowDialog(), når man trykker Opret (Pr25)
    public partial class CreateReceipt : Window
    {
        private CreateReceiptController controller = new CreateReceiptController();

        public CreateReceipt(int serviceId)
        {
            InitializeComponent();

            Service? service = controller.GetService(serviceId);
            if (service == null)
            {
                tbServiceId.Text = "Service nr. " + serviceId + " blev ikke fundet";
                return;
            }

            tbServiceId.Text = "Service nr. " + service.ServiceId;
            tbCreated.Text = "Oprettet " + service.DropOffDate.ToString("dd-MM-yyyy HH:mm");

            if (service.Status == ServiceStatus.Open)
                lblStatus.Content = "Åben";
            else
                lblStatus.Content = "Lukket";

            Costumer? costumer = controller.GetCostumer(service.Customer);
            if (costumer != null)
                lblCustomerName.Content = costumer.Name;

            lblCustomerPhone.Content = service.Customer;
            lblBrandModel.Content = service.Brand + " - " + service.Model;
            lblErrorType.Content = service.ErrorType;
            lblDescription.Content = service.Description;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
