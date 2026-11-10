# CO9 – registrerModtagelse

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO9 |
| Operation | registrerModtagelse(reservedelNavn: String, antalModtaget: Integer, modtagelsesdato: Date) |
| Krydsreferencer | UC9 Opret Reservedele Modtagelse |
| Forudsætninger | Programmet er startet. Der findes en Reservedel med reservedelNavn, og den står på listen over reservedele, der skal bestilles (UC7). antalModtaget er et positivt helt tal. modtagelsesdato er udfyldt og ikke i fremtiden. |
| Slutbetingelser | En Modtagelse-instans m blev oprettet. m.antal blev sat til antalModtaget. m.modtagelsesdato blev sat til modtagelsesdato. m blev associeret med den valgte Reservedel. Reservedel.lagerbeholdning blev forøget med antalModtaget. |
