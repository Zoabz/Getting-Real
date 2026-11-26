**# CO5 – registrerUdførtArbejde**

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO5 |
| Operation | registrerUdførtArbejde(reparationsnummer: String, medarbejderInitialer: String, beskrivelse: String) |
| Krydsreferencer | UC5 Udført Arbejde |
| Forudsætninger | Programmet er startet. Der findes en åben Reparationsordre med reparationsnummer. Der findes en Medarbejder med medarbejderInitialer. Beskrivelsen er udfyldt. |
| Slutbetingelser | En UdførtArbejde-instans u blev oprettet.<br>u.beskrivelse blev sat til beskrivelse.<br>u blev associeret med den valgte Reparationsordre.<br>u blev associeret med den valgte Medarbejder.<br>Reparationsordre.status blev ændret fra Åben til Lukket. |