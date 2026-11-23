namespace Vekto.ViewModels
{
    // Én række i tabellen "Alle services" og i listen "Vælg service" på Service oversigt.
    // Indeholder også de oplysninger, der vises under "Vælg service"
    public class ServiceRow
    {
        public int Nr { get; set; }
        public string Kunde { get; set; } = "";
        public string Telefon { get; set; } = "";
        public string Cykel { get; set; } = "";
        public string Fejltype { get; set; } = "";
        public string Beskrivelse { get; set; } = "";
        public string Status { get; set; } = "";

        // Det er den tekst, der vises i "Vælg service"
        public override string ToString()
        {
            return Nr + " · " + Kunde + " · " + Cykel;
        }
    }
}
