namespace Vektor.Models;

public class Reservedel
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public int AntalPåLager { get; set; }
    public int MinimumAntal { get; set; }
    public Leverandør Leverandør { get; set; }

    public Reservedel()
    {
    }

    public Reservedel(int id, string navn, Leverandør leverandør, int minimumAntal)
    {
        Id = id;
        Navn = navn;
        Leverandør = leverandør;
        MinimumAntal = minimumAntal;
        AntalPåLager = 0;
    }

    public bool HarNokPåLager(int antal)
    {
        return antal <= AntalPåLager;
    }

    public void NedskrivLager(int antal)
    {
        AntalPåLager -= antal;
    }

    public void OpskrivLager(int antal)
    {
        AntalPåLager += antal;
    }

    public bool SkalBestilles()
    {
        return AntalPåLager <= MinimumAntal;
    }

    public int Mangler()
    {
        return Math.Max(MinimumAntal - AntalPåLager, 0);
    }
}
