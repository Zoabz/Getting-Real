**# CO3 – opretService**

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO3 |
| Operation | opretService(kundeID: String, mærke: String, model: String, fejltype: String, fejlbeskrivelse: String) |
| Krydsreferencer | UC3 Opret Service |
| Forudsætninger | Programmet er startet. Der findes en Kunde med kundeID (valgt via søgning på telefonnummer). Mærke, model, fejltype og fejlbeskrivelse er udfyldt. |
| Slutbetingelser | En Reparationsordre-instans r blev oprettet.<br>r.ordrenummer blev sat til et nyt, unikt ordrenummer.<br>r.status blev sat til Åben.<br>r.indleveringsdato blev sat til dags dato.<br>r.fejltype blev sat til fejltype.<br>r.fejlbeskrivelse blev sat til fejlbeskrivelse.<br>En Cykel-instans c blev oprettet med c.mærke sat til mærke og c.model sat til model.<br>r blev associeret med den valgte Kunde.<br>r blev associeret med c.<br>r blev tilføjet til systemets reparationsordrer, så den kan følges fra indlevering til afhentning. |