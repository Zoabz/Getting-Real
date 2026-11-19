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
        CreateEmployeeController cec = new CreateEmployeeController();


        public CreateEmployee()
        {
            InitializeComponent();
            DataContext = cec;
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
