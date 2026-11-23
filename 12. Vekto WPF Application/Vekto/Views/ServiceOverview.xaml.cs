using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Vekto.Models;
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

            foreach (Employee em in controller.GetAllEmployees())
                cbEmployee.Items.Add(em);

            ShowServices();
        }

        // Fylder tabellen og "Vælg service" med alle services
        private void ShowServices()
        {
            List<ServiceRow> rows = controller.GetAllServices();

            dgServices.ItemsSource = rows;
            cbService.ItemsSource = rows;
            lblServiceCount.Content = "Alle services (" + rows.Count + ")";
        }

        // Klik på en række i tabellen vælger servicen i "Vælg service"
        private void dgServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbService.SelectedItem = dgServices.SelectedItem;
        }

        // Når en service vælges, vises dens oplysninger
        private void cbService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgServices.SelectedItem = cbService.SelectedItem;

            tbDetailCustomer.Text = "";
            tbDetailBike.Text = "";
            tbDetailErrorType.Text = "";
            tbDetailDescription.Text = "";

            ServiceRow? row = cbService.SelectedItem as ServiceRow;
            if (row == null)
                return;

            Service? service = controller.GetService(row.Nr);
            if (service == null)
                return;

            tbDetailCustomer.Text = row.Kunde + " (" + service.Customer + ")";
            tbDetailBike.Text = row.Cykel;
            tbDetailErrorType.Text = service.ErrorType;
            tbDetailDescription.Text = service.Description;
        }

        // Dobbeltklik på en række åbner kvitteringen (Pr25)
        private void dgServices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ServiceRow? row = dgServices.SelectedItem as ServiceRow;
            if (row == null)
                return;

            CreateReceipt receipt = new CreateReceipt(row.Nr);
            receipt.Owner = Window.GetWindow(this);
            receipt.ShowDialog();
        }

        // UC5: gem det udførte arbejde og luk servicen
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceRow? row = cbService.SelectedItem as ServiceRow;
                controller.RegisterCompletedWork(row, cbEmployee.SelectedItem as Employee, tbCompletedWork.Text);

                ShowMessage("Service " + row!.Nr + " er gemt, og status er ændret til Lukket.", Brushes.Green);

                tbCompletedWork.Text = "";
                cbEmployee.SelectedItem = null;
                ShowServices(); // Opdaterer status i tabellen
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, Brushes.Red);
            }
        }

        private void ShowMessage(string text, Brush color)
        {
            tbMessage.Text = text;
            tbMessage.Foreground = color;
        }
    }
}
