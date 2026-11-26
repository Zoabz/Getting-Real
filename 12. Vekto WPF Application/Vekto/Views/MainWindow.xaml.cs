using System.Windows;

namespace Vekto.Views
{
    // Hovedvindue: menuen til venstre. Den valgte side vises i PageArea til højre
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PageArea.Content = new CreateService(); // Her starter den på siden Opret service
        }

        private void btnOpretMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            PageArea.Content = new CreateEmployee();
        }

        private void btnOpretKunde_Click(object sender, RoutedEventArgs e)
        {
            PageArea.Content = new CreateCostumer();
        }

        private void btnOpretService_Click(object sender, RoutedEventArgs e)
        {
            PageArea.Content = new CreateService();
        }

        private void btnServiceOversigt_Click(object sender, RoutedEventArgs e)
        {
            PageArea.Content = new ServiceOverview();
        }

        private void btnReservedeleUdtag_Click(object sender, RoutedEventArgs e)
        {
            PageArea.Content = new PartsGrab();
        }
    }
}
