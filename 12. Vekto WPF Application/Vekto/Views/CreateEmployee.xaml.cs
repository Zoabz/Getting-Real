using System.Windows;
using System.Windows.Controls;
using Vekto.Models;
using Vekto.ViewModels;
using System.Windows.Media;

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

        private void tbInitials_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void tbInitials_GotFocus(object sender, RoutedEventArgs e)
        {
            // Gray betyder, at det stadig er pladsholderteksten
            if (tbInitials.Foreground == Brushes.Gray)
            {
                tbInitials.Text = "";
                tbInitials.Foreground = Brushes.Black;
            }
        }
        private void tbInitials_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbInitials.Text))
            {
                tbInitials.Text = "Initialerne skal være unikke";
                tbInitials.Foreground = Brushes.Gray;
            }
        }
    }
}
