using System.Windows;
using System.Windows.Controls;
using Vekto.Models;
using Vekto.ViewModels;

namespace Vekto.Views
{
    // Side: vises i MainWindow's sideområde
    public partial class CreateEmployee : UserControl
    {
        CreateEmployeeController createEmployee = new CreateEmployeeController();
        public CreateEmployee()
        {
            InitializeComponent();
            ShowEmployee();
        }

        // UC1: opret medarbejderen
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            createEmployee.CreateEmployee(tbName.ToString(), tbInitials.ToString());

        }

        private void ShowEmployee()
        {
            List<Employee> employees = createEmployee.GetAllEmployees();
            foreach (Employee employee in employees)
            {
                lbEmployees.Items.Add(employee.Name + " (" + employee.Initials + ")");
            }
            lblEmployeeCount.Content = "Medarbejdere (" + employees.Count + ")";

        }
    }
}
