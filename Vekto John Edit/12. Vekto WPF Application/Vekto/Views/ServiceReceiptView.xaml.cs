using System.Windows;
using Vekto.Controllers;
using Vekto.Models;

namespace Vekto.Views
{
    // UC4 Service Kvittering. Dialog, der åbnes med ShowDialog() fra Opret service (Pr25)
    public partial class ServiceReceiptView : Window
    {
        private ServiceReceiptController controller = new ServiceReceiptController();

        public ServiceReceiptView(int serviceId)
        {
            InitializeComponent();

            Service service = controller.GetService(serviceId);

            tbServiceId.Text = "Service nr. " + service.ServiceId;
            tbCreated.Text = "Oprettet " + service.DropOffDate.ToString("dd.MM.yyyy HH:mm");

            if (service.Status == ServiceStatus.Open)
                lblStatus.Content = "Åben";
            else
                lblStatus.Content = "Lukket";

            lblCustomerName.Content = service.Customer.Name;
            lblCustomerPhone.Content = service.Customer.PhoneNumber;
            lblBrandModel.Content = service.Brand + " - " + service.Model;
            lblErrorType.Content = service.ErrorType;
            tbDescription.Text = service.Description;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
