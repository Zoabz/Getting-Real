using System.Windows;
using System.Windows.Controls;
using Vekto.Controllers;
using Vekto.Models;

namespace Vekto.Views
{
    // UC2 Opret Kunde. Siden vises i MainWindow's sideområde
    public partial class CustomerView : UserControl
    {
        private CreateCustomerController controller = new CreateCustomerController();

        public CustomerView()
        {
            InitializeComponent();
            ShowCustomers();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                Customer customer = controller.CreateCustomer(tbName.Text.Trim(), tbPhone.Text);

                tbSuccess.Text = "Kunden " + customer.Name + " (" + customer.PhoneNumber + ") er oprettet.";
                tbName.Text = "";
                tbPhone.Text = "";
                ShowCustomers();
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }

        // Viser alle kunder i listen til højre
        private void ShowCustomers()
        {
            List<Customer> customers = controller.GetAllCustomers();

            lbCustomers.Items.Clear();
            foreach (Customer customer in customers)
            {
                lbCustomers.Items.Add(customer.Name + " (" + customer.PhoneNumber + ")");
            }

            lblCustomerCount.Content = "Kunder (" + customers.Count + ")";
        }
    }
}
