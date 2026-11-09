using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Vektor.Models;

namespace Vektor.Data;

public class Datafil
{
    private string sti;

    private static readonly JsonSerializerOptions indstillinger = new JsonSerializerOptions
    {
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.Preserve,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        Converters = { new JsonStringEnumConverter() }
    };

    public Datafil(string sti)
    {
        this.sti = sti;
    }

    public void Indlæs(Værksted værksted)
    {
        if (!File.Exists(sti))
            return;

        string json = File.ReadAllText(sti);
        Indhold indhold = JsonSerializer.Deserialize<Indhold>(json, indstillinger);
        if (indhold == null)
            return;

        værksted.medarbejdere = indhold.Medarbejdere;
        værksted.kunder = indhold.Kunder;
        værksted.reservedele = indhold.Reservedele;
        værksted.reparationer = indhold.Reparationer;
        værksted.modtagelser = indhold.Modtagelser;
        værksted.næsteReparationsnummer = indhold.NæsteReparationsnummer;
    }

    public void Gem(Værksted værksted)
    {
        Indhold indhold = new Indhold
        {
            Medarbejdere = værksted.medarbejdere,
            Kunder = værksted.kunder,
            Reservedele = værksted.reservedele,
            Reparationer = værksted.reparationer,
            Modtagelser = værksted.modtagelser,
            NæsteReparationsnummer = værksted.næsteReparationsnummer
        };

        Directory.CreateDirectory(Path.GetDirectoryName(sti));
        File.WriteAllText(sti, JsonSerializer.Serialize(indhold, indstillinger));
    }

    // Det, der står i filen
    private class Indhold
    {
        public List<Medarbejder> Medarbejdere { get; set; } = new List<Medarbejder>();
        public List<Kunde> Kunder { get; set; } = new List<Kunde>();
        public List<Reservedel> Reservedele { get; set; } = new List<Reservedel>();
        public List<Reparation> Reparationer { get; set; } = new List<Reparation>();
        public List<Modtagelse> Modtagelser { get; set; } = new List<Modtagelse>();
        public int NæsteReparationsnummer { get; set; } = 1001;
    }
}
