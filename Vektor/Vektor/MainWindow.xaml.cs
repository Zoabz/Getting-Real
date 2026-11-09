using System.Windows;
using System.Windows.Controls;
using Vektor.Data;
using Vektor.Views;

namespace Vektor;

public partial class MainWindow : Window
{
    private readonly Værksted værksted;

    public MainWindow(Værksted værksted)
    {
        InitializeComponent();
        this.værksted = værksted;

        MenuOpretService.IsChecked = true;
        VisSide(MenuOpretService);
    }

    private void Menu_Click(object sender, RoutedEventArgs e)
    {
        VisSide((RadioButton)sender);
    }

    private void VisSide(RadioButton menu)
    {
        if (menu == MenuOpretMedarbejder)
            Indhold.Content = new OpretMedarbejderSide(værksted);
        else if (menu == MenuOpretKunde)
            Indhold.Content = new OpretKundeSide(værksted);
        else if (menu == MenuOpretService)
            Indhold.Content = new OpretServiceSide(værksted);
        else if (menu == MenuServiceKvittering)
            Indhold.Content = new ServiceKvitteringSide(værksted);
        else if (menu == MenuReservedeleUdtag)
            Indhold.Content = new ReservedeleUdtagSide(værksted);
        else if (menu == MenuUdførtArbejde)
            Indhold.Content = new UdførtArbejdeSide(værksted);
        else if (menu == MenuLagerOgBestilling)
            Indhold.Content = new LagerOgBestillingSide(værksted);
        else if (menu == MenuOpretReservedel)
            Indhold.Content = new OpretReservedelSide(værksted);
        else if (menu == MenuReservedeleModtagelse)
            Indhold.Content = new ReservedeleModtagelseSide(værksted);
    }
}
