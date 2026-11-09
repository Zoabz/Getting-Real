namespace Vektor.Models;

public class Modtagelse
{
    public DateTime Dato { get; set; }
    public int AntalModtaget { get; set; }
    public Reservedel Reservedel { get; set; }

    public Modtagelse()
    {
    }

    public Modtagelse(Reservedel reservedel, int antalModtaget, DateTime dato)
    {
        Reservedel = reservedel;
        AntalModtaget = antalModtaget;
        Dato = dato;
    }
}
