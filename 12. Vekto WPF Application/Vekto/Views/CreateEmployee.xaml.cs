using System.Windows;
using System.Windows.Controls;
using Vekto.Models;
using Vekto.ViewModels;

namespace Vekto.Views
{
    // Side: vises i MainWindow's sideområde
    public partial class CreateEmployee : UserControl
    {
        private CreateEmployeeController controller = new CreateEmployeeController();

        public CreateEmployee()
        {
            InitializeComponent();
            ShowEmployees();
        }

        // UC1: opret medarbejderen
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = controller.CreateEmployee(tbName.Text, tbInitials.Text);

                tbName.Text = "";
                tbInitials.Text = "";
                ShowEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Fylder medarbejderlisten og tæller medarbejderne
        private void ShowEmployees()
        {
            lbEmployees.Items.Clear();
            foreach (Employee em in controller.GetAllEmployees())
                lbEmployees.Items.Add(em);

            lblEmployeeCount.Content = "Medarbejdere (" + lbEmployees.Items.Count + ")";
        }
    }
}
