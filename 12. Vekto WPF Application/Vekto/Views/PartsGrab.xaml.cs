using System.Windows;
using System.Windows.Controls;
using Vekto.ViewModels;

namespace Vekto.Views
{
    // Side: vises i MainWindow's sideområde (UC6 Reservedele udtag)
    public partial class PartsGrab : UserControl
    {
        private PartsGrabController controller = new PartsGrabController();

        public PartsGrab()
        {
            InitializeComponent();
            DataContext = controller;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                controller.AddPart(tbAmount.Text);
                tbAmount.Text = "1";
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            PartRow row = (PartRow)button.DataContext;
            controller.RemovePart(row);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                int serviceNr = controller.Save();
                tbSuccess.Text = "Reservedelene er trukket fra lageret og registreret på service " + serviceNr + ".";
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }
    }
}
