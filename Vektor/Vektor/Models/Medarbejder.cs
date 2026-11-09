namespace Vektor.Models;

public class Medarbejder
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public string Initialer { get; set; }

    public Medarbejder()
    {
    }

    public Medarbejder(int id, string navn, string initialer)
    {
        Id = id;
        Navn = navn;
        Initialer = initialer;
    }

    public override string ToString()
    {
        return $"{Navn} ({Initialer})";
    }
}
