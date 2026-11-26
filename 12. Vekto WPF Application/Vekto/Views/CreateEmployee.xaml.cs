using System.Windows;
using System.Windows.Controls;
using Vekto.ViewModels;

namespace Vekto.Views
{
    public partial class CreateEmployee : UserControl
    {
        private CreateEmployeeController controller = new CreateEmployeeController();

        public CreateEmployee()
        {
            InitializeComponent();
            DataContext = controller;
            ShowCount();
        }

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

        private void ShowCount()
        {
            lblEmployeeCount.Content = "Medarbejdere (" + controller.Employees.Count + ")";
        }
    }
}
