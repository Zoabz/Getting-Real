# CO3 – opretService

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO3 |
| Operation | opretService(kundeID: String, mærke: String, model: String, fejltype: String, fejlbeskrivelse: String) |
| Krydsreferencer | UC3 Opret Service |
| Forudsætninger | Programmet er startet. Der findes en Kunde med kundeID (valgt via søgning på telefonnummer, evt. oprettet via UC2). Mærke, model, fejltype og fejlbeskrivelse er udfyldt. |
| Slutbetingelser | En Reparationsordre-instans r blev oprettet. r.ordrenummer blev sat til et nyt, unikt ordrenummer. r.status blev sat til Åben. r.indleveringsdato blev sat til dags dato. [Antagelse] r.fejltype blev sat til fejltype. r.fejlbeskrivelse blev sat til fejlbeskrivelse. En Cykel-instans c blev oprettet med c.mærke sat til mærke og c.model sat til model. r blev associeret med den valgte Kunde. r blev associeret med c. r blev tilføjet til systemets reparationsordrer, så den kan følges fra indlevering til afhentning. |
