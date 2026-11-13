using System.Windows;

namespace Vekto
{
    // Dialog 04: åbnes fra Opret service, når man trykker Opret, med ShowDialog() (Pr25)
    public partial class ServiceReceiptDialog : Window
    {
        public ServiceReceiptDialog(Service service)
        {
            InitializeComponent();

            tbServiceId.Text = "Service nr. " + service.ServiceId;
            tbCreated.Text = "Oprettet " + service.DropOffDate.ToString();

            if (service.Status == ServiceStatus.Closed)
            {
                lblStatus.Content = "Lukket";
            }
            else
            {
                lblStatus.Content = "Åben";
            }

            lblCustomerName.Content = service.Customer.Name;
            lblCustomerPhone.Content = service.Customer.PhoneNumber;
            lblBrandModel.Content = service.Brand + " - " + service.Model;
            lblErrorType.Content = service.ErrorType;
            lblDescription.Content = service.Description;
        }

        // Luk: samme som OK-knappen i Pr25
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
