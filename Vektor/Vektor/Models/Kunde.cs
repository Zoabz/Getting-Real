namespace Vektor.Models;

public class Kunde
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public string Telefonnummer { get; set; }

    public Kunde()
    {
    }

    public Kunde(int id, string navn, string telefonnummer)
    {
        Id = id;
        Navn = navn;
        Telefonnummer = telefonnummer;
    }

    public bool Matcher(string søgetekst)
    {
        if (string.IsNullOrWhiteSpace(søgetekst))
        {
            return true;
        }

        string tekst = søgetekst.Trim().ToLower();
        return Navn.ToLower().Contains(tekst) || Telefonnummer.Contains(tekst.Replace(" ", ""));
    }
}
