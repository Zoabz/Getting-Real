using System.Windows;
using System.Windows.Controls;
using Vekto.Controllers;
using Vekto.Models;

namespace Vekto.Views
{
    // UC3 Opret Service. Siden vises i MainWindow's sideområde
    public partial class ServiceView : UserControl
    {
        private CreateServiceController controller = new CreateServiceController();

        public ServiceView()
        {
            InitializeComponent();

            lbErrorType.Items.Add("Bremser");
            lbErrorType.Items.Add("Motor");
            lbErrorType.Items.Add("Elektronik");
            lbErrorType.Items.Add("Dæk");
            lbErrorType.Items.Add("Andet");
        }

        // Søg efter kunden, hver gang teksten i Tlf. nr. ændres
        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            Customer customer = controller.SearchCustomer(tbPhone.Text);

            if (customer != null)
                lblCustomer.Content = customer.Name + " (" + customer.PhoneNumber + ")";
            else
                lblCustomer.Content = "Ingen kunde fundet";
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                Service service = controller.CreateService(tbPhone.Text, tbBrand.Text.Trim(), tbModel.Text.Trim(),
                                                           (string)lbErrorType.SelectedItem, tbDescription.Text.Trim());

                // Vis servicekvitteringen i en dialogboks (Pr25)
                ServiceReceiptView receiptView = new ServiceReceiptView(service.ServiceId);
                receiptView.Owner = Window.GetWindow(this);
                receiptView.ShowDialog();

                tbSuccess.Text = "Service " + service.ServiceId + " er oprettet med status Åben.";

                // Tøm felterne, så den næste service kan oprettes
                tbPhone.Text = "";
                tbBrand.Text = "";
                tbModel.Text = "";
                lbErrorType.SelectedItem = null;
                tbDescription.Text = "";
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }
    }
}
