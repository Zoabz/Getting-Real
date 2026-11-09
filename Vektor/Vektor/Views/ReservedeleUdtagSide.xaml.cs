using System.Windows;
using System.Windows.Controls;
using Vektor.Data;
using Vektor.Models;

namespace Vektor.Views;

public partial class ReservedeleUdtagSide : UserControl
{
    private readonly Værksted værksted;
    private List<Udtag> udtagsliste = new List<Udtag>();

    public ReservedeleUdtagSide(Værksted værksted)
    {
        InitializeComponent();
        this.værksted = værksted;

        cmbService.ItemsSource = værksted.SøgServices("", ReparationStatus.Åben);
        cmbMedarbejder.ItemsSource = værksted.HentMedarbejdere();
        cmbReservedel.ItemsSource = værksted.HentLageroversigt();
    }

    private void Service_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbService.SelectedItem is Reparation reparation)
            dgRegistreret.ItemsSource = reparation.HentUdtag();
    }

    private void Tilføj_Click(object sender, RoutedEventArgs e)
    {
        Medarbejder medarbejder = cmbMedarbejder.SelectedItem as Medarbejder;
        Reservedel reservedel = cmbReservedel.SelectedItem as Reservedel;

        if (medarbejder == null)
        {
            besked.VisFejl("Vælg en medarbejder.");
            return;
        }
        if (reservedel == null)
        {
            besked.VisFejl("Vælg en reservedel.");
            return;
        }
        if (!int.TryParse(txtAntal.Text, out int antal) || antal <= 0)
        {
            besked.VisFejl("Antal skal være et positivt helt tal.");
            return;
        }

        // Er reservedelen allerede på listen, lægges antallet sammen
        Udtag påListen = udtagsliste.FirstOrDefault(u => u.Reservedel == reservedel);
        int iAlt = antal;
        if (påListen != null)
            iAlt += påListen.AntalTaget;

        if (!reservedel.HarNokPåLager(iAlt))
        {
            besked.VisFejl($"Der er kun {reservedel.AntalPåLager} stk. {reservedel.Navn} på lager.");
            return;
        }

        if (påListen != null)
            påListen.AntalTaget = iAlt;
        else
            udtagsliste.Add(new Udtag(reservedel, antal, medarbejder, DateTime.Now));

        besked.Skjul();
        txtAntal.Text = "1";
        VisListe();
    }

    private void Fjern_Click(object sender, RoutedEventArgs e)
    {
        Udtag udtag = (Udtag)((Button)sender).DataContext;
        udtagsliste.Remove(udtag);
        VisListe();
    }

    private void Gem_Click(object sender, RoutedEventArgs e)
    {
        Reparation reparation = cmbService.SelectedItem as Reparation;
        Medarbejder medarbejder = cmbMedarbejder.SelectedItem as Medarbejder;

        try
        {
            foreach (Udtag udtag in udtagsliste)
                udtag.Medarbejder = medarbejder;

            værksted.RegistrerUdtag(reparation, medarbejder, udtagsliste);

            int skalBestilles = værksted.HentBestillingsliste().Count;
            besked.VisOk($"{udtagsliste.Count} reservedel(e) er registreret på service {reparation.Reparationsnummer}. " +
                         $"{skalBestilles} reservedel(e) skal nu bestilles.");

            udtagsliste = new List<Udtag>();
            VisListe();
            dgRegistreret.ItemsSource = reparation.HentUdtag();
            cmbReservedel.ItemsSource = værksted.HentLageroversigt();
        }
        catch (Exception fejl)
        {
            besked.VisFejl(fejl.Message);
        }
    }

    private void VisListe()
    {
        dgListe.ItemsSource = udtagsliste.ToList();
    }
}
