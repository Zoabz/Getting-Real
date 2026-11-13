using System.Windows;
using System.Windows.Controls;

namespace Vekto
{
    public partial class MainWindow : Window
    {
        private CreateServiceController controller = new CreateServiceController();
        private string foundPhone = "";

        public MainWindow()
        {
            InitializeComponent();

            lbErrorType.Items.Add("Bremser");
            lbErrorType.Items.Add("Motor");
            lbErrorType.Items.Add("Elektronik");
            lbErrorType.Items.Add("Dæk");
            lbErrorType.Items.Add("Andet");
        }

        // Sidebar: åbn Opret medarbejder og luk dette vindue
        private void btnOpretMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            EmployeeView employeeView = new EmployeeView();
            employeeView.Show();
            this.Close();
        }

        // Sidebar: åbn Opret kunde og luk dette vindue
        private void btnOpretKunde_Click(object sender, RoutedEventArgs e)
        {
            CustomerView customerView = new CustomerView();
            customerView.Show();
            this.Close();
        }

        // UC3 trin 2-3: søg efter kunden, hver gang teksten i Tlf. nr. ændres
        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            Customer customer = controller.SearchCustomer(tbPhone.Text);

            if (customer != null)
            {
                foundPhone = customer.PhoneNumber;
                lblCustomer.Content = customer.Name + " (" + customer.PhoneNumber + ")";
            }
            else
            {
                foundPhone = "";
                lblCustomer.Content = "Ingen kunde fundet";
            }
        }

        // UC3 trin 6-7: opret servicen
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tbSuccess.Text = "";

            // UC3 6a: tjek at alt er udfyldt
            if (foundPhone == "")
            {
                tbMessage.Text = "Find en kunde på telefonnummer.";
            }
            else if (tbBrand.Text == "")
            {
                tbMessage.Text = "Skriv bilens mærke, fx Hyundai.";
            }
            else if (tbModel.Text == "")
            {
                tbMessage.Text = "Skriv bilens model, fx I30.";
            }
            else if (lbErrorType.SelectedItem == null)
            {
                tbMessage.Text = "Vælg en fejltype.";
            }
            else if (tbDescription.Text == "")
            {
                tbMessage.Text = "Skriv en fejlbeskrivelse.";
            }
            else
            {
                tbMessage.Text = "";

                Service service = controller.CreateService(foundPhone, tbBrand.Text, tbModel.Text,
                    lbErrorType.SelectedItem.ToString(), tbDescription.Text);

                // UC3 trin 7: vis kvitteringen i dialog 04 (Pr25)
                ServiceReceiptDialog dialog = new ServiceReceiptDialog(service);
                dialog.ShowDialog();

                // Userflow UC3: efter Luk vises beskeden øverst på siden
                tbSuccess.Text = "Service " + service.ServiceId + " er oprettet med status Åben.";
            }
        }
    }
}
