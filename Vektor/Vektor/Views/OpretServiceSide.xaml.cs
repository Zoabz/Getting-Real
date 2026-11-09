using System.Windows;
using System.Windows.Controls;
using Vektor.Data;
using Vektor.Models;

namespace Vektor.Views;

public partial class OpretServiceSide : UserControl
{
    private readonly Værksted værksted;
    private Kunde valgtKunde;

    public OpretServiceSide(Værksted værksted)
    {
        InitializeComponent();
        this.værksted = værksted;

        cmbFejltype.ItemsSource = new List<string> { "Bremser", "Elektrisk", "Gear", "Hjul og dæk", "Kæde", "Lys", "Andet" };
        lstKunder.ItemsSource = værksted.HentKunder();
    }

    private void Søg_TextChanged(object sender, TextChangedEventArgs e)
    {
        List<Kunde> fundne = værksted.SøgKunder(txtSøg.Text);
        lstKunder.ItemsSource = fundne;

        if (fundne.Count == 1)
            lstKunder.SelectedIndex = 0;
    }

    private void Kunde_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (lstKunder.SelectedItem is Kunde kunde)
        {
            valgtKunde = kunde;
            txtValgtKunde.Text = $"{kunde.Navn} ({kunde.Telefonnummer})";
        }
    }

    private void Opret_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Reparation reparation = værksted.OpretService(valgtKunde, txtMærke.Text, txtModel.Text,
                cmbFejltype.SelectedItem as string, txtBeskrivelse.Text);

            besked.VisOk($"Service {reparation.Reparationsnummer} er oprettet med status Åben.");
            Ryd();

            KvitteringVindue kvittering = new KvitteringVindue(reparation);
            kvittering.Owner = Window.GetWindow(this);
            kvittering.ShowDialog();
        }
        catch (Exception fejl)
        {
            besked.VisFejl(fejl.Message);
        }
    }

    private void Ryd()
    {
        txtSøg.Clear();
        txtMærke.Clear();
        txtModel.Clear();
        txtBeskrivelse.Clear();
        cmbFejltype.SelectedIndex = -1;
        lstKunder.SelectedIndex = -1;
        valgtKunde = null;
        txtValgtKunde.Text = "Ingen kunde valgt";
    }
}
