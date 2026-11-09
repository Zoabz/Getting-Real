using System.Windows;
using System.Windows.Controls;
using Vektor.Data;
using Vektor.Models;

namespace Vektor.Views;

public partial class ServiceKvitteringSide : UserControl
{
    private readonly Værksted værksted;

    public ServiceKvitteringSide(Værksted værksted)
    {
        InitializeComponent();
        this.værksted = værksted;

        cmbStatus.ItemsSource = new List<string> { "Alle", "Åben", "Lukket" };
        cmbStatus.SelectedIndex = 0;
    }

    private void Filter_Changed(object sender, RoutedEventArgs e)
    {
        if (værksted == null)
            return;

        ReparationStatus? status = null;
        if (cmbStatus.SelectedIndex == 1)
            status = ReparationStatus.Åben;
        if (cmbStatus.SelectedIndex == 2)
            status = ReparationStatus.Lukket;

        dgServices.ItemsSource = værksted.SøgServices(txtSøg.Text, status);

        List<Reparation> alle = værksted.SøgServices("", null);
        int åbne = alle.Count(r => r.Status == ReparationStatus.Åben);
        txtAntal.Text = $"{alle.Count} i alt · {åbne} åbne · {alle.Count - åbne} lukkede";
    }

    private void VisKvittering_Click(object sender, RoutedEventArgs e)
    {
        if (dgServices.SelectedItem is not Reparation reparation)
        {
            besked.VisFejl("Vælg en service i tabellen.");
            return;
        }

        besked.Skjul();
        KvitteringVindue kvittering = new KvitteringVindue(reparation);
        kvittering.Owner = Window.GetWindow(this);
        kvittering.ShowDialog();
    }
}
