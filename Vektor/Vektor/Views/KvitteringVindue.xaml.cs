using System.Windows;
using System.Windows.Media;
using Vektor.Models;

namespace Vektor.Views;

public partial class KvitteringVindue : Window
{
    public KvitteringVindue(Reparation reparation)
    {
        InitializeComponent();

        txtNummer.Text = $"Service nr. {reparation.Reparationsnummer}";
        txtOprettet.Text = $"Oprettet {reparation.Indleveringsdato:dd.MM.yyyy}";
        txtStatus.Text = reparation.Status.ToString();

        if (reparation.Status == ReparationStatus.Lukket)
        {
            statusRamme.Background = Brushes.Black;
            txtStatus.Foreground = Brushes.White;
        }

        txtKunde.Text = reparation.Kunde.Navn;
        txtTelefon.Text = reparation.Kunde.Telefonnummer;
        txtCykel.Text = $"{reparation.Mærke} {reparation.Model}";
        txtFejltype.Text = reparation.Fejltype;
        txtBeskrivelse.Text = reparation.Fejlbeskrivelse;

        if (reparation.Status == ReparationStatus.Lukket)
        {
            txtUdført.Text = reparation.UdførtArbejde;
            txtUdførtAf.Text = $"Udført af {reparation.UdførtAf} · {reparation.LukketDato:dd.MM.yyyy}";
        }
        else
        {
            txtUdført.Text = "Ikke udført endnu.";
        }

        List<Udtag> udtag = reparation.HentUdtag();
        dgReservedele.ItemsSource = udtag;
        if (udtag.Count == 0)
        {
            dgReservedele.Visibility = Visibility.Collapsed;
            txtIngenReservedele.Visibility = Visibility.Visible;
        }
    }

    private void Luk_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
