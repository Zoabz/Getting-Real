using System.Windows;
using System.Windows.Controls;
using Vekto.ViewModels;

namespace Vekto.Views
{
    // Side: vises i MainWindow's sideområde (UC5 Service oversigt)
    public partial class ServiceOverview : UserControl
    {
        private ServiceOverviewController controller = new ServiceOverviewController();

        public ServiceOverview()
        {
            InitializeComponent();
            DataContext = controller;
            lblServiceCount.Content = "Alle services (" + controller.Services.Count + ")";
        }

        // UC5: gem det udførte arbejde og luk servicen
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                int serviceNr = controller.RegisterCompletedWork(tbCompletedWork.Text);

                tbSuccess.Text = "Service " + serviceNr + " er gemt, og status er ændret til Lukket.";
                tbCompletedWork.Text = "";
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }

        // Viser kvitteringen for den valgte service i en dialogboks (Pr25)
        private void btnShowReceipt_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";
            tbSuccess.Text = "";

            try
            {
                int serviceNr = controller.GetSelectedServiceNr();

                CreateReceipt receipt = new CreateReceipt();
                receipt.ShowService(serviceNr);
                receipt.ShowDialog();
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
            }
        }
    }
}
