using System.Windows;
using System.Windows.Controls;
using Vektor.Data;
using Vektor.Models;

namespace Vektor.Views;

public partial class ReservedeleModtagelseSide : UserControl
{
    private readonly Værksted værksted;

    public ReservedeleModtagelseSide(Værksted værksted)
    {
        InitializeComponent();
        this.værksted = værksted;

        dpDato.SelectedDate = DateTime.Today;
        dpDato.DisplayDateEnd = DateTime.Today;
        VisLister();
    }

    private void VisLister()
    {
        cmbReservedel.ItemsSource = værksted.HentBestillingsliste();
        dgModtagelser.ItemsSource = værksted.HentModtagelser();
    }

    private void Reservedel_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbReservedel.SelectedItem is Reservedel reservedel)
        {
            txtLeverandør.Text = reservedel.Leverandør.Navn;
            txtPåLager.Text = reservedel.AntalPåLager.ToString();
            txtMinimum.Text = reservedel.MinimumAntal.ToString();
            txtMangler.Text = reservedel.Mangler().ToString();
            txtAntal.Text = Math.Max(reservedel.Mangler(), 1).ToString();
        }
        else
        {
            txtLeverandør.Text = "–";
            txtPåLager.Text = "–";
            txtMinimum.Text = "–";
            txtMangler.Text = "–";
            txtAntal.Clear();
        }
    }

    private void Modtag_Click(object sender, RoutedEventArgs e)
    {
        Reservedel reservedel = cmbReservedel.SelectedItem as Reservedel;

        if (!int.TryParse(txtAntal.Text, out int antal))
        {
            besked.VisFejl("Antal skal være et helt tal.");
            return;
        }

        try
        {
            DateTime dato = dpDato.SelectedDate ?? DateTime.Today;
            værksted.RegistrerModtagelse(reservedel, antal, dato);
            besked.VisOk($"{antal} stk. {reservedel.Navn} er lagt på lager. Der er nu {reservedel.AntalPåLager}.");
            VisLister();
        }
        catch (Exception fejl)
        {
            besked.VisFejl(fejl.Message);
        }
    }
}
