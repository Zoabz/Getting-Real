using System;
using System.Collections.Generic;
using System.Windows;

namespace Vekto
{
    public partial class EmployeeView : Window
    {
        private CreateEmployeeController controller = new CreateEmployeeController();

        public EmployeeView()
        {
            InitializeComponent();
            ShowEmployees();
        }

        // Sidebar: åbn Opret service og luk dette vindue
        private void btnOpretService_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // Sidebar: åbn Opret kunde og luk dette vindue
        private void btnOpretKunde_Click(object sender, RoutedEventArgs e)
        {
            CustomerView customerView = new CustomerView();
            customerView.Show();
            this.Close();
        }

        // SSD: opretMedarbejder(navn, navnKort)
        // SD:  CreateEmployee(name, initials) på CreateEmployeeController
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                Employee employee = controller.CreateEmployee(tbName.Text, tbInitials.Text);

                // Bekræftelse (UC1 trin 6), tøm felterne og opdatér listen
                tbSuccess.Text = "Medarbejderen " + employee.Name + " (" + employee.Initials + ") er oprettet.";
                tbName.Text = "";
                tbInitials.Text = "";
                ShowEmployees();
            }
            catch (Exception ex)
            {
                // SD: controlleren svarer med en fejl, fx "Initials already in use"
                tbError.Text = ex.Message;
            }
        }

        // SD: GetAllEmployees() på CreateEmployeeController
        private void ShowEmployees()
        {
            List<Employee> employees = controller.GetAllEmployees();
            List<string> lines = new List<string>();

            int number = 1;
            foreach (Employee employee in employees)
            {
                lines.Add(number + ".  " + employee.Name + "  (" + employee.Initials + ")");
                number = number + 1;
            }

            lbEmployees.ItemsSource = lines;
            lblEmployeeCount.Content = "Medarbejdere (" + employees.Count + ")";
        }
    }
}
