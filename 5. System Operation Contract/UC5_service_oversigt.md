# CO5 – Service oversigt over reparationer

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO5 |
| Operation | registrerUdfoertArbejde(reparationsnummer: String, medarbejderInitialer: String, beskrivelse: String) |
| Krydsreferencer | UC5 Service oversigt over reparationer |
| Forudsætninger | Programmet er startet. Der findes en åben Reparationsordre med reparationsnummer (UC3). Der findes en Medarbejder med medarbejderInitialer (UC1). Beskrivelsen er udfyldt. |
| Slutbetingelser | Reparationsordre.udførtArbejde blev sat til beskrivelse. Reparationsordren blev associeret med den valgte Medarbejder. Reparationsordre.status blev ændret fra Åben til Lukket. |
