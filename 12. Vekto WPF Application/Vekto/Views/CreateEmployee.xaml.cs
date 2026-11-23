using System.Windows;
using System.Windows.Controls;
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
            DataContext = controller;
            ShowCount();
        }

        // UC1: opret medarbejderen
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";

            try
            {
                controller.CreateEmployee(tbName.Text, tbInitials.Text);

                tbName.Text = "";
                tbInitials.Text = "";
                ShowCount();
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }

        // Tæller medarbejderne i listen
        private void ShowCount()
        {
            lblEmployeeCount.Content = "Medarbejdere (" + controller.Employees.Count + ")";
        }
    }
}
