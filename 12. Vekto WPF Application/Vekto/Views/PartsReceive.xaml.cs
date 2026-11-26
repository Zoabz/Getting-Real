using System.Windows;
using System.Windows.Controls;
using Vekto.Models;
using Vekto.ViewModels;

namespace Vekto.Views
{
    public partial class PartsReceive : UserControl
    {
        private PartsReceiveController controller = new PartsReceiveController();

        public PartsReceive()
        {
            InitializeComponent();
            DataContext = controller;
            dpDate.SelectedDate = DateTime.Today;
        }

        private void btnReceive_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                Delivery delivery = controller.Receive(tbAmount.Text, dpDate.SelectedDate);

                tbSuccess.Text = delivery.Amount + " " + delivery.PartName + " er lagt på lager.";
                dpDate.SelectedDate = DateTime.Today;
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }
    }
}
