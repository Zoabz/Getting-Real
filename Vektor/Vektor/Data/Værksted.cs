using Vektor.Models;

namespace Vektor.Data;

public class Værksted
{
    internal List<Medarbejder> medarbejdere = new List<Medarbejder>();
    internal List<Kunde> kunder = new List<Kunde>();
    internal List<Reparation> reparationer = new List<Reparation>();
    internal List<Reservedel> reservedele = new List<Reservedel>();
    internal List<Modtagelse> modtagelser = new List<Modtagelse>();
    internal int næsteReparationsnummer = 1001;
    private Datafil datafil;

    public Værksted(Datafil datafil)
    {
        this.datafil = datafil;
        datafil.Indlæs(this);
    }

    // UC1
    public Medarbejder OpretMedarbejder(string navn, string initialer)
    {
        navn = navn.Trim();
        initialer = initialer.Trim().ToUpper();

        if (navn == "")
            throw new ArgumentException("Skriv medarbejderens navn.");
        if (initialer == "")
            throw new ArgumentException("Skriv medarbejderens initialer.");
        if (medarbejdere.Any(m => m.Initialer == initialer))
            throw new ArgumentException($"Initialerne {initialer} findes allerede.");

        Medarbejder medarbejder = new Medarbejder(medarbejdere.Count + 1, navn, initialer);
        medarbejdere.Add(medarbejder);
        Gem();
        return medarbejder;
    }

    public List<Medarbejder> HentMedarbejdere()
    {
        return medarbejdere.ToList();
    }

    // UC2
    public Kunde OpretKunde(string navn, string telefonnummer)
    {
        navn = navn.Trim();
        telefonnummer = telefonnummer.Replace(" ", "");

        if (navn == "")
            throw new ArgumentException("Skriv kundens navn.");
        if (telefonnummer == "")
            throw new ArgumentException("Skriv kundens telefonnummer.");
        if (!telefonnummer.TrimStart('+').All(char.IsDigit))
            throw new ArgumentException("Telefonnummeret må kun indeholde tal.");
        if (kunder.Any(k => k.Telefonnummer == telefonnummer))
            throw new ArgumentException($"Der findes allerede en kunde med {telefonnummer}.");

        Kunde kunde = new Kunde(kunder.Count + 1, navn, telefonnummer);
        kunder.Add(kunde);
        Gem();
        return kunde;
    }

    public List<Kunde> HentKunder()
    {
        return kunder.ToList();
    }

    // UC3
    public List<Kunde> SøgKunder(string søgetekst)
    {
        return kunder.Where(k => k.Matcher(søgetekst)).ToList();
    }

    public Reparation OpretService(Kunde kunde, string mærke, string model, string fejltype, string fejlbeskrivelse)
    {
        if (kunde == null)
            throw new ArgumentException("Vælg en kunde.");
        if (string.IsNullOrWhiteSpace(mærke))
            throw new ArgumentException("Skriv cyklens mærke.");
        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Skriv cyklens model.");
        if (string.IsNullOrWhiteSpace(fejltype))
            throw new ArgumentException("Vælg en fejltype.");
        if (string.IsNullOrWhiteSpace(fejlbeskrivelse))
            throw new ArgumentException("Skriv en fejlbeskrivelse.");

        Reparation reparation = new Reparation(næsteReparationsnummer, kunde, mærke.Trim(), model.Trim(), fejltype, fejlbeskrivelse.Trim());
        næsteReparationsnummer++;
        reparationer.Add(reparation);
        Gem();
        return reparation;
    }

    // UC4
    public List<Reparation> SøgServices(string søgetekst, ReparationStatus? status)
    {
        return reparationer
            .Where(r => r.Matcher(søgetekst))
            .Where(r => status == null || r.Status == status)
            .OrderByDescending(r => r.Reparationsnummer)
            .ToList();
    }

    // UC5
    public void RegistrerUdførtArbejde(Reparation reparation, Medarbejder medarbejder, string beskrivelse)
    {
        if (reparation == null)
            throw new ArgumentException("Vælg en service.");
        if (medarbejder == null)
            throw new ArgumentException("Vælg en medarbejder.");
        if (string.IsNullOrWhiteSpace(beskrivelse))
            throw new ArgumentException("Beskriv det udførte arbejde.");
        if (reparation.Status == ReparationStatus.Lukket)
            throw new ArgumentException("Servicen er allerede lukket.");

        reparation.Luk(medarbejder, beskrivelse.Trim());
        Gem();
    }

    // UC6
    public void RegistrerUdtag(Reparation reparation, Medarbejder medarbejder, List<Udtag> udtagsliste)
    {
        if (reparation == null)
            throw new ArgumentException("Vælg en service.");
        if (medarbejder == null)
            throw new ArgumentException("Vælg en medarbejder.");
        if (udtagsliste.Count == 0)
            throw new ArgumentException("Tilføj mindst én reservedel til listen.");

        foreach (Udtag udtag in udtagsliste)
        {
            if (!udtag.Reservedel.HarNokPåLager(udtag.AntalTaget))
                throw new InvalidOperationException($"Der er kun {udtag.Reservedel.AntalPåLager} stk. {udtag.Reservedel.Navn} på lager.");
        }

        foreach (Udtag udtag in udtagsliste)
        {
            reparation.TilføjUdtag(udtag);
            udtag.Reservedel.NedskrivLager(udtag.AntalTaget);
        }
        Gem();
    }

    // UC7
    public List<Reservedel> HentLageroversigt()
    {
        return reservedele.OrderBy(r => r.Navn).ToList();
    }

    public List<Reservedel> HentBestillingsliste()
    {
        return reservedele
            .Where(r => r.SkalBestilles())
            .OrderByDescending(r => r.Mangler())
            .ToList();
    }

    // UC8
    public Reservedel OpretReservedel(string navn, string leverandørNavn, int minimumAntal)
    {
        navn = navn.Trim();
        leverandørNavn = leverandørNavn.Trim();

        if (navn == "")
            throw new ArgumentException("Skriv reservedelens navn.");
        if (leverandørNavn == "")
            throw new ArgumentException("Skriv leverandørens navn.");
        if (minimumAntal < 0)
            throw new ArgumentException("Minimum antal skal være 0 eller mere.");
        if (reservedele.Any(r => r.Navn.ToLower() == navn.ToLower()))
            throw new ArgumentException($"{navn} findes allerede.");

        Reservedel eksisterende = reservedele.FirstOrDefault(r => r.Leverandør.Navn.ToLower() == leverandørNavn.ToLower());
        Leverandør leverandør;
        if (eksisterende != null)
            leverandør = eksisterende.Leverandør;
        else
            leverandør = new Leverandør(leverandørNavn);

        Reservedel reservedel = new Reservedel(reservedele.Count + 1, navn, leverandør, minimumAntal);
        reservedele.Add(reservedel);
        Gem();
        return reservedel;
    }

    // UC9
    public Modtagelse RegistrerModtagelse(Reservedel reservedel, int antal, DateTime dato)
    {
        if (reservedel == null)
            throw new ArgumentException("Vælg en reservedel.");
        if (antal <= 0)
            throw new ArgumentException("Antal skal være et positivt tal.");
        if (dato.Date > DateTime.Today)
            throw new ArgumentException("Datoen må ikke ligge i fremtiden.");
        if (!reservedel.SkalBestilles())
            throw new InvalidOperationException($"{reservedel.Navn} står ikke på bestillingslisten.");

        Modtagelse modtagelse = new Modtagelse(reservedel, antal, dato.Date);
        modtagelser.Add(modtagelse);
        reservedel.OpskrivLager(antal);
        Gem();
        return modtagelse;
    }

    public List<Modtagelse> HentModtagelser()
    {
        return modtagelser.OrderByDescending(m => m.Dato).ToList();
    }

    private void Gem()
    {
        datafil.Gem(this);
    }
}
