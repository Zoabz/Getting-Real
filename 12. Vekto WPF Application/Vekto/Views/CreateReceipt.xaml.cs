using System.Windows;

namespace Vekto.Views
{
    // Dialog: åbnes fra Opret service med ShowDialog(), når man trykker Opret (Pr25)
    public partial class CreateReceipt : Window
    {
        public CreateReceipt()
        {
            InitializeComponent();
            // TODO: vis servicens oplysninger, når Service-klassen findes
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
