using System.Windows;
using System.Windows.Controls;
using Vektor.Data;
using Vektor.Models;

namespace Vektor.Views;

public partial class LagerOgBestillingSide : UserControl
{
    public LagerOgBestillingSide(Værksted værksted)
    {
        InitializeComponent();

        List<Reservedel> lager = værksted.HentLageroversigt();
        List<Reservedel> bestilling = værksted.HentBestillingsliste();

        dgLager.ItemsSource = lager.Select(r => new
        {
            r.Navn,
            Leverandør = r.Leverandør.Navn,
            PåLager = r.AntalPåLager,
            Minimum = r.MinimumAntal,
            Status = r.SkalBestilles() ? "Skal bestilles" : "OK"
        }).ToList();

        dgBestilling.ItemsSource = bestilling.Select(r => new
        {
            r.Navn,
            Leverandør = r.Leverandør.Navn,
            PåLager = r.AntalPåLager,
            Minimum = r.MinimumAntal,
            Mangler = r.Mangler()
        }).ToList();

        txtOpsummering.Text = $"{lager.Count} reservedele · {bestilling.Count} skal bestilles";

        if (bestilling.Count == 0)
        {
            dgBestilling.Visibility = Visibility.Collapsed;
            txtIngen.Visibility = Visibility.Visible;
        }
    }
}
