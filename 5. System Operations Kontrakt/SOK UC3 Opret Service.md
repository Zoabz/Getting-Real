# Systemoperationskontrakt – UC3 Opret Service

Kontrakt for systemoperationen `opretService` i [SSD'et for UC3](../4.%20System%20Sekvens%20Diagram/UC3_opret_service.puml). Begreber og klasser kommer fra [domænemodellen](../2.%20Domænemodel/domænemodel.md).

Objektmodel med præbetingelser (blå) og postbetingelser (pink): [SOK UC3 Opret Service - objektmodel.puml](SOK%20UC3%20Opret%20Service%20-%20objektmodel.puml).

## Kontrakt: opretService

| Felt | Beskrivelse |
| :---- | :---- |
| **Operation** | opretService(tlfNr, mærke, model, fejltype, fejlbeskrivelse) |
| **Krydsreference** | UC3 Opret Service, trin 3–7 |
| **Præbetingelser** | En *Kunde* med telefonnummeret tlfNr findes (oprettet i UC2). Mærke, model, fejltype og fejlbeskrivelse er udfyldt. |
| **Postbetingelser** | • En ny *Reparation* r er oprettet.<br>• r er knyttet til den *Kunde*, der har telefonnummeret.<br>• r.reparationsnummer (serviceId) er sat til et nyt nummer, der ikke bruges af nogen anden *Reparation*.<br>• r.indleveringsdato er sat til dags dato. \[Antagelse\]<br>• r.cykelbeskrivelse er sat ud fra mærke og model.<br>• r.fejlbeskrivelse er sat ud fra fejltype og fejlbeskrivelse. \[Antagelse: fejltype har ingen egen attribut i modellen\]<br>• r.status er sat til *Åben*.<br>Reparationen er gemt i tekstfilen. Brugeren får serviceId og status *Åben* (servicekvitteringen). |
| **Fejlbetingelser** | Fejltype, mærke, model eller fejlbeskrivelse mangler (UC3 6a): ingen *Reparation* er oprettet, og brugeren får en fejlbesked. Gemning i tekstfilen fejler: ingen *Reparation* er oprettet. \[Antagelse\] |

## Noter

- *aftaltAfhentningsdato* sættes ikke i UC3 og er derfor ikke en del af postbetingelserne. Se åbne punkter i domænemodellen.
- `soegKunde` har ingen kontrakt, fordi den kun læser data og ikke ændrer systemets tilstand.
