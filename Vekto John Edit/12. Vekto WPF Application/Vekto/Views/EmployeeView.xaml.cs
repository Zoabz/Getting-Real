using System.Windows;
using System.Windows.Controls;
using Vekto.Controllers;
using Vekto.Models;

namespace Vekto.Views
{
    // UC1 Opret Medarbejder. Siden vises i MainWindow's sideområde
    public partial class EmployeeView : UserControl
    {
        private CreateEmployeeController controller = new CreateEmployeeController();

        public EmployeeView()
        {
            InitializeComponent();
            ShowEmployees();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                Employee employee = controller.CreateEmployee(tbName.Text.Trim(), tbInitials.Text.Trim());

                tbSuccess.Text = "Medarbejderen " + employee.Name + " (" + employee.Initials + ") er oprettet.";
                tbName.Text = "";
                tbInitials.Text = "";
                ShowEmployees();
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }

        // Viser alle medarbejdere i listen til højre
        private void ShowEmployees()
        {
            List<Employee> employees = controller.GetAllEmployees();

            lbEmployees.Items.Clear();
            foreach (Employee employee in employees)
            {
                lbEmployees.Items.Add(employee.Name + " (" + employee.Initials + ")");
            }

            lblEmployeeCount.Content = "Medarbejdere (" + employees.Count + ")";
        }
    }
}
