using System;
using System.Collections.Generic;
using System.Windows;

namespace Vekto
{
    public partial class CustomerView : Window
    {
        private CreateCustomerController controller = new CreateCustomerController();

        public CustomerView()
        {
            InitializeComponent();
            ShowCustomers();
        }

        // Sidebar: åbn Opret medarbejder og luk dette vindue
        private void btnOpretMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            EmployeeView employeeView = new EmployeeView();
            employeeView.Show();
            this.Close();
        }

        // Sidebar: åbn Opret service og luk dette vindue
        private void btnOpretService_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // SSD: opretKunde(navn, tlfNr)
        // SD:  CreateCustomer(name, phoneNumber) på CreateCustomerController
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                Customer customer = controller.CreateCustomer(tbName.Text, tbPhone.Text);

                // Bekræftelse (UC2 trin 6), tøm felterne og opdatér listen
                tbSuccess.Text = "Kunden " + customer.Name + " (" + customer.PhoneNumber + ") er oprettet.";
                tbName.Text = "";
                tbPhone.Text = "";
                ShowCustomers();
            }
            catch (Exception ex)
            {
                // SD: controlleren svarer med en fejl, fx "Customer already exists"
                tbError.Text = ex.Message;
            }
        }

        // SD: GetAllCustomers() på CreateCustomerController
        private void ShowCustomers()
        {
            List<Customer> customers = controller.GetAllCustomers();
            List<string> lines = new List<string>();

            int number = 1;
            foreach (Customer customer in customers)
            {
                lines.Add(number + ".  " + customer.Name + "  (" + customer.PhoneNumber + ")");
                number = number + 1;
            }

            lbCustomers.ItemsSource = lines;
            lblCustomerCount.Content = "Kunder (" + customers.Count + ")";
        }
    }
}
