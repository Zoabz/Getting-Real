using System.Windows;
using System.Windows.Controls;
using Vektor.Data;
using Vektor.Models;

namespace Vektor.Views;

public partial class OpretMedarbejderSide : UserControl
{
    private readonly Værksted værksted;

    public OpretMedarbejderSide(Værksted værksted)
    {
        InitializeComponent();
        this.værksted = værksted;
        VisListe();
    }

    private void VisListe()
    {
        dgMedarbejdere.ItemsSource = værksted.HentMedarbejdere();
    }

    private void Opret_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Medarbejder medarbejder = værksted.OpretMedarbejder(txtNavn.Text, txtInitialer.Text);
            besked.VisOk($"{medarbejder.Navn} er oprettet.");

            txtNavn.Clear();
            txtInitialer.Clear();
            txtNavn.Focus();
            VisListe();
        }
        catch (Exception fejl)
        {
            besked.VisFejl(fejl.Message);
        }
    }
}
