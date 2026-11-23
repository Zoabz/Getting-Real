using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

            foreach (string errorType in controller.GetErrorTypes())
                lbErrorType.Items.Add(errorType);
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
            try
            {
                Service service = controller.CreateService(tbPhone.Text, tbBrand.Text, tbModel.Text,
                                                           (string?)lbErrorType.SelectedItem, tbDescription.Text);

                ShowMessage("", Brushes.Black);

                // Vis servicekvitteringen i en dialogboks (Pr25)
                CreateReceipt receipt = new CreateReceipt(service.ServiceId);
                receipt.Owner = Window.GetWindow(this);
                receipt.ShowDialog();

                ShowMessage("Service nr. " + service.ServiceId + " er oprettet.", Brushes.Green);

                // Tøm felterne, så den næste service kan oprettes
                tbPhone.Text = "";
                tbBrand.Text = "";
                tbModel.Text = "";
                lbErrorType.SelectedItem = null;
                tbDescription.Text = "";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, Brushes.Red);
            }
        }

        private void ShowMessage(string text, Brush color)
        {
            tbMessage.Text = text;
            tbMessage.Foreground = color;
        }
    }
}
