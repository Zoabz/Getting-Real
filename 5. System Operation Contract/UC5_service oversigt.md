# CO5 – Service oversigt over reparationer

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO5 |
| Operation | Service oversigt(reparationsnummer: String, medarbejderInitialer: String, beskrivelse: String) |
| Krydsreferencer | UC5 Service oversigt over Reparationer |
| Forudsætninger | Programmet er startet. Der findes en åben Reparationsordre med reparationsnummer (UC3). Der findes en Medarbejder med medarbejderInitialer (UC1). Beskrivelsen er udfyldt. |
| Slutbetingelser | En service oversigt-instans s blev oprettet. s.beskrivelse blev sat til beskrivelse. s blev associeret med den valgte Reparationsordre. s blev associeret med den valgte Medarbejder. Reparationsordre.status blev ændret fra Åben til Lukket. |
