namespace Vektor.Models;

public class Udtag
{
    public DateTime Dato { get; set; }
    public int AntalTaget { get; set; }
    public Reservedel Reservedel { get; set; }
    public Medarbejder Medarbejder { get; set; }

    public Udtag()
    {
    }

    public Udtag(Reservedel reservedel, int antalTaget, Medarbejder medarbejder, DateTime dato)
    {
        Reservedel = reservedel;
        AntalTaget = antalTaget;
        Medarbejder = medarbejder;
        Dato = dato;
    }
}
