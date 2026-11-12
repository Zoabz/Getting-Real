# CO6 – registrerReservedeludtag

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO6 |
| Operation | registrerReservedeludtag(reparationsnummer: String, medarbejderInitialer: String, udtagsliste: Liste af (reservedelID: String, antal: Integer)) |
| Krydsreferencer | UC6 Reservedele Udtag Fra Lageret |
| Forudsætninger | Programmet er startet. Der findes en Reparationsordre med reparationsnummer (UC3). Der findes en Medarbejder med medarbejderInitialer (UC1). Udtagslisten indeholder mindst én linje. Hvert antal er et positivt helt tal. Lagerbeholdningen for hver Reservedel på listen er tilstrækkelig til det ønskede antal. |
| Slutbetingelser | For hver linje i udtagslisten blev en Reservedelsforbrug-instans f oprettet. f.antal blev sat til linjens antal. f blev associeret med den valgte Reparationsordre. f blev associeret med den valgte Medarbejder. f blev associeret med den valgte Reservedel. Reservedel.lagerbeholdning blev nedskrevet med det brugte antal. |
