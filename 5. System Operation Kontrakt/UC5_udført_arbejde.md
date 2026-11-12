# CO5 – registrerUdførtArbejde

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO5 |
| Operation | registrerUdførtArbejde(reparationsnummer: String, medarbejderInitialer: String, beskrivelse: String) |
| Krydsreferencer | UC5 Udført Arbejde på Reparation|
| Forudsætninger | Programmet er startet. Der findes en åben Reparationsordre med reparationsnummer (UC3). Der findes en Medarbejder med medarbejderInitialer (UC1). Beskrivelsen er udfyldt. |
| Slutbetingelser | En UdførtArbejde-instans u blev oprettet. u.beskrivelse blev sat til beskrivelse. u blev associeret med den valgte Reparationsordre. u blev associeret med den valgte Medarbejder. Reparationsordre.status blev ændret fra Åben til Lukket. |
