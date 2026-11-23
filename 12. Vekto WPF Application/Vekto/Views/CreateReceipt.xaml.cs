using System.Windows;
using System.Windows.Media;
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

            // Åben = gul, Lukket = grøn (wireframe 04)
            if (service.Status == ServiceStatus.Open)
            {
                lblStatus.Content = "Åben";
                lblStatus.Background = new SolidColorBrush(Color.FromRgb(0xFF, 0xF1, 0xC2));
            }
            else
            {
                lblStatus.Content = "Lukket";
                lblStatus.Background = new SolidColorBrush(Color.FromRgb(0xD4, 0xED, 0xDA));
            }

            // Udført arbejde (UC5)
            if (service.Status == ServiceStatus.Closed)
            {
                tbCompletedWork.Text = service.CompletedWork;
                tbCompletedWork.Foreground = Brushes.Black;

                Employee? employee = controller.GetEmployee(service.Employee);
                string employeeText = service.Employee;
                if (employee != null)
                    employeeText = employee.ToString();

                tbCompletedBy.Text = "Udført af " + employeeText;
                if (service.ClosedDate != null)
                    tbCompletedBy.Text += " · " + service.ClosedDate.Value.ToString("dd-MM-yyyy HH:mm");
            }

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
