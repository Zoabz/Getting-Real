namespace Vektor.Models;

public class Leverandør
{
    public string Navn { get; set; }

    public Leverandør()
    {
    }

    public Leverandør(string navn)
    {
        Navn = navn;
    }
}
