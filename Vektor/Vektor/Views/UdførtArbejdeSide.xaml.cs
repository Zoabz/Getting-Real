using System.Windows;
using System.Windows.Controls;
using Vektor.Data;
using Vektor.Models;

namespace Vektor.Views;

public partial class UdførtArbejdeSide : UserControl
{
    private readonly Værksted værksted;

    public UdførtArbejdeSide(Værksted værksted)
    {
        InitializeComponent();
        this.værksted = værksted;

        cmbService.ItemsSource = værksted.SøgServices("", ReparationStatus.Åben);
        cmbMedarbejder.ItemsSource = værksted.HentMedarbejdere();
    }

    private void Service_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbService.SelectedItem is Reparation reparation)
        {
            txtKunde.Text = $"{reparation.Kunde.Navn} ({reparation.Kunde.Telefonnummer})";
            txtCykel.Text = $"{reparation.Mærke} {reparation.Model}";
            txtFejltype.Text = reparation.Fejltype;
            txtFejlbeskrivelse.Text = reparation.Fejlbeskrivelse;
            txtReservedele.Text = $"{reparation.HentUdtag().Count} linje(r) registreret";
        }
        else
        {
            txtKunde.Text = "–";
            txtCykel.Text = "–";
            txtFejltype.Text = "–";
            txtFejlbeskrivelse.Text = "–";
            txtReservedele.Text = "–";
        }
    }

    private void Gem_Click(object sender, RoutedEventArgs e)
    {
        Reparation reparation = cmbService.SelectedItem as Reparation;
        Medarbejder medarbejder = cmbMedarbejder.SelectedItem as Medarbejder;

        try
        {
            værksted.RegistrerUdførtArbejde(reparation, medarbejder, txtBeskrivelse.Text);
            besked.VisOk($"Service {reparation.Reparationsnummer} er lukket.");

            txtBeskrivelse.Clear();
            cmbService.ItemsSource = værksted.SøgServices("", ReparationStatus.Åben);
        }
        catch (Exception fejl)
        {
            besked.VisFejl(fejl.Message);
        }
    }
}
