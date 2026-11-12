# CO2 – opretKunde

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO2 |
| Operation | opretKunde(navn: String, telefonnummer: String) |
| Krydsreferencer | UC2 Opret Kunde I Butikken |
| Forudsætninger | Programmet er startet. Navn er udfyldt. Telefonnummer er udfyldt og gyldigt. [Antagelse] Der findes ikke allerede en Kunde med samme telefonnummer, eller brugeren har valgt at oprette en ny alligevel. |
| Slutbetingelser | En Kunde-instans k blev oprettet. k.navn blev sat til navn. k.telefonnummer blev sat til telefonnummer. k blev tilføjet til systemets kunder, så k kan findes på telefonnummer og vælges på en reparationsordre. |
