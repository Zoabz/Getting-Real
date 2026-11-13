using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Vekto.Views
{
    public partial class MainWindow : Window
    {
        // Farverne på knapperne i sidebaren
        private SolidColorBrush normalColor = new SolidColorBrush(Color.FromRgb(0xEB, 0xEB, 0xEB));
        private SolidColorBrush activeColor = new SolidColorBrush(Color.FromRgb(0xC4, 0xA6, 0x9A));

        public MainWindow()
        {
            InitializeComponent();

            // Programmet starter på Opret service
            ShowPage(new OpretService(), btnOpretService);
        }

        // Viser en side i sideområdet og markerer knappen i sidebaren
        private void ShowPage(UserControl page, Button activeButton)
        {
            PageArea.Content = page;

            // Alle knapper bliver normale ...
            Button[] buttons = { btnOpretMedarbejder, btnOpretKunde, btnOpretService, btnReservedeleUdtag,
                                 btnServiceOversigt, btnLagerOgBestilling, btnOpretReservedel, btnReservedeleModtagelse };
            foreach (Button button in buttons)
            {
                button.Background = normalColor;
                button.FontWeight = FontWeights.Normal;
            }

            // ... og den valgte bliver markeret
            activeButton.Background = activeColor;
            activeButton.FontWeight = FontWeights.Bold;
        }

        // ---------- Sider, der er lavet ----------
        private void btnOpretMedarbejder_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new OpretMedarbejder(), btnOpretMedarbejder);
        }

        private void btnOpretKunde_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new OpretKunde(), btnOpretKunde);
        }

        private void btnOpretService_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new OpretService(), btnOpretService);
        }

        // ---------- Sider, der ikke er lavet endnu ----------
        private void btnReservedeleUdtag_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new KommerSenere("Reservedele udtag"), btnReservedeleUdtag);
        }

        private void btnServiceOversigt_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new KommerSenere("Service oversigt"), btnServiceOversigt);
        }

        private void btnLagerOgBestilling_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new KommerSenere("Lager og bestilling"), btnLagerOgBestilling);
        }

        private void btnOpretReservedel_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new KommerSenere("Opret reservedel"), btnOpretReservedel);
        }

        private void btnReservedeleModtagelse_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(new KommerSenere("Reservedele modtagelse"), btnReservedeleModtagelse);
        }
    }
}
