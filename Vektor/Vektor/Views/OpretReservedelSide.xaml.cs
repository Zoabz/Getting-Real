using System.Windows;
using System.Windows.Controls;
using Vektor.Data;
using Vektor.Models;

namespace Vektor.Views;

public partial class OpretReservedelSide : UserControl
{
    private readonly Værksted værksted;

    public OpretReservedelSide(Værksted værksted)
    {
        InitializeComponent();
        this.værksted = værksted;
        VisListe();
    }

    private void VisListe()
    {
        dgReservedele.ItemsSource = værksted.HentLageroversigt();
    }

    private void Opret_Click(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(txtMinimum.Text, out int minimum))
        {
            besked.VisFejl("Minimum antal skal være et helt tal.");
            return;
        }

        try
        {
            Reservedel reservedel = værksted.OpretReservedel(txtNavn.Text, txtLeverandør.Text, minimum);
            besked.VisOk($"{reservedel.Navn} er oprettet med 0 på lager.");

            txtNavn.Clear();
            txtLeverandør.Clear();
            txtMinimum.Clear();
            txtNavn.Focus();
            VisListe();
        }
        catch (Exception fejl)
        {
            besked.VisFejl(fejl.Message);
        }
    }
}
