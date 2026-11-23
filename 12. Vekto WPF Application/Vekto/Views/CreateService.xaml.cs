using System.Windows;
using System.Windows.Controls;
using Vekto.Models;
using Vekto.ViewModels;

namespace Vekto.Views
{
    // Side: vises i MainWindow's sideområde
    public partial class CreateService : UserControl
    {
        private CreateServiceController controller = new CreateServiceController();

        public CreateService()
        {
            InitializeComponent();
            DataContext = controller;
        }

        // UC3: søg efter kunden, hver gang teksten i Tlf. nr. ændres
        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            Costumer? costumer = controller.SearchCustomer(tbPhone.Text);

            if (costumer != null)
                lblCustomer.Content = costumer.ToString();
            else
                lblCustomer.Content = "Ingen kunde fundet";
        }

        // UC3: opret servicen. Lykkes det, vises kvitteringen i en dialogboks.
        // Fejl vises som rød tekst under Opret-knappen (ingen dialogboks)
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                // SelectedItem er null, hvis der ikke er valgt en fejltype
                string? errorType = lbErrorType.SelectedItem?.ToString();

                Service service = controller.CreateService(tbPhone.Text, tbBrand.Text, tbModel.Text,
                                                           errorType, tbDescription.Text);

                // Vis servicekvitteringen i en dialogboks (Pr25)
                CreateReceipt receipt = new CreateReceipt();
                receipt.ShowService(service.ServiceId);
                receipt.ShowDialog();

                tbSuccess.Text = "Service nr. " + service.ServiceId + " er oprettet.";

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
