using System.Windows;
using System.Windows.Controls;
using Vekto.Models;
using Vekto.ViewModels;

namespace Vekto.Views
{
    public partial class CreatePart : UserControl
    {
        private CreatePartController controller = new CreatePartController();

        public CreatePart()
        {
            InitializeComponent();
            DataContext = controller;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                Part part = controller.CreatePart(tbName.Text, tbSupplier.Text, tbMinQuantity.Text);

                tbSuccess.Text = part.Name + " er oprettet!";

                tbName.Text = "";
                tbSupplier.Text = "";
                tbMinQuantity.Text = "";
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }

    }
}
