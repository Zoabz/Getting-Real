**# CO9 – registrerModtagelse**

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO9 |
| Operation | registrerModtagelse(reservedelNavn: String, antalModtaget: Integer, modtagelsesdato: Date) |
| Krydsreferencer | UC9 Opret Reservedele Modtagelse |
| Forudsætninger | Programmet er startet. Der findes en Reservedel med reservedelNavn, og den står på listen over reservedele, der skal bestilles. antalModtaget er et positivt helt tal. modtagelsesdato er udfyldt og ikke i fremtiden. |
| Slutbetingelser | En Modtagelse-instans m blev oprettet.<br>m.antal blev sat til antalModtaget.<br>m.modtagelsesdato blev sat til modtagelsesdato.<br>m blev associeret med den valgte Reservedel.<br>Reservedel.lagerbeholdning blev forøget med antalModtaget. |