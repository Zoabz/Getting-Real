using System.Text.Json.Serialization;

namespace Vektor.Models;

public class Reparation
{
    public int Reparationsnummer { get; set; }
    public DateTime Indleveringsdato { get; set; }
    public string Mærke { get; set; }
    public string Model { get; set; }
    public string Fejltype { get; set; }
    public string Fejlbeskrivelse { get; set; }
    public string UdførtArbejde { get; set; }
    public DateTime? LukketDato { get; set; }
    public ReparationStatus Status { get; set; } = ReparationStatus.Åben;
    public Kunde Kunde { get; set; }
    public Medarbejder UdførtAf { get; set; }

    [JsonInclude]
    private List<Udtag> udtag = new List<Udtag>();

    public Reparation()
    {
    }

    public Reparation(int reparationsnummer, Kunde kunde, string mærke, string model, string fejltype, string fejlbeskrivelse)
    {
        Reparationsnummer = reparationsnummer;
        Kunde = kunde;
        Mærke = mærke;
        Model = model;
        Fejltype = fejltype;
        Fejlbeskrivelse = fejlbeskrivelse;
        Indleveringsdato = DateTime.Today;
        Status = ReparationStatus.Åben;
    }

    public void TilføjUdtag(Udtag nytUdtag)
    {
        udtag.Add(nytUdtag);
    }

    public List<Udtag> HentUdtag()
    {
        return udtag.ToList();
    }

    public void Luk(Medarbejder medarbejder, string beskrivelse)
    {
        UdførtArbejde = beskrivelse;
        UdførtAf = medarbejder;
        LukketDato = DateTime.Now;
        Status = ReparationStatus.Lukket;
    }

    public bool Matcher(string søgetekst)
    {
        if (string.IsNullOrWhiteSpace(søgetekst))
        {
            return true;
        }

        string tekst = søgetekst.Trim().ToLower();
        return Reparationsnummer.ToString().Contains(tekst)
            || Kunde.Matcher(tekst)
            || $"{Mærke} {Model}".ToLower().Contains(tekst);
    }
}
