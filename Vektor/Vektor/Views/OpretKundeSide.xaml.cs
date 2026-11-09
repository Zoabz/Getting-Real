using System.Windows;
using System.Windows.Controls;
using Vektor.Data;
using Vektor.Models;

namespace Vektor.Views;

public partial class OpretKundeSide : UserControl
{
    private readonly Værksted værksted;

    public OpretKundeSide(Værksted værksted)
    {
        InitializeComponent();
        this.værksted = værksted;
        VisListe();
    }

    private void VisListe()
    {
        dgKunder.ItemsSource = værksted.HentKunder();
    }

    private void Opret_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Kunde kunde = værksted.OpretKunde(txtNavn.Text, txtTelefon.Text);
            besked.VisOk($"{kunde.Navn} er oprettet.");

            txtNavn.Clear();
            txtTelefon.Clear();
            txtNavn.Focus();
            VisListe();
        }
        catch (Exception fejl)
        {
            besked.VisFejl(fejl.Message);
        }
    }
}
