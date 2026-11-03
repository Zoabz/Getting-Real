# Systemoperationskontrakter – UC6 Reservedele udtag

Kontrakter for to af systemoperationerne i [SSD'et for UC6](../4.%20System%20Sekvens%20Diagram/UC6_reservedele_udtag.puml). Begreber og klasser kommer fra [domænemodellen](../2.%20Domænemodel/domænemodel.md). Postbetingelserne er skrevet som tilstandsændringer i domænemodellen (oprettede objekter, nye relationer, ændrede attributter), ikke som programkode.

SSD'ets operationer er `vaelgService(serviceId)`, `tilfoejReservedel(reservedel, antal)`, `fjernReservedel(reservedel)` og `gemUdtag(serviceId, medarbejder)`. Kontrakterne her gælder `tilføjReservedel` og `gemUdtag`.

Objektmodel med præbetingelser (blå) og postbetingelser (pink): [SOK UC6 Reservedele udtag - objektmodel.puml](SOK%20UC6%20Reservedele%20udtag%20-%20objektmodel.puml).

## Kontrakt 1: tilføjReservedel

| Felt | Beskrivelse |
| :---- | :---- |
| **Operation** | tilføjReservedel(reservedel, antal) |
| **Krydsreference** | UC6 Reservedele udtag, trin 3–4 |
| **Præbetingelser** | En *Reparation* er valgt med `vælgService`. En *Reservedel* med navnet reservedel findes. antal er et positivt helt tal. |
| **Postbetingelser** | Reservedelen og antallet er tilføjet udtagslisten (en liste, der kun findes, indtil udtaget gemmes). Hvis reservedelen allerede stod på listen, er antallet lagt til den eksisterende linje. \[Antagelse\] Den opdaterede liste er vist. *Reservedel.beholdning* er uændret. Der er ikke oprettet nogen *Udtag*. |
| **Fejlbetingelser** | Reservedel eller antal mangler, eller antallet på listen ville blive større end *Reservedel.beholdning* (UC6 3a og 4a): intet er tilføjet, og brugeren får en fejlbesked. |

## Kontrakt 2: gemUdtag

| Felt | Beskrivelse |
| :---- | :---- |
| **Operation** | gemUdtag(serviceId, medarbejder) |
| **Krydsreference** | UC6 Reservedele udtag, trin 6–7 |
| **Præbetingelser** | En *Reparation* med serviceId og en *Medarbejder* findes. Udtagslisten indeholder mindst én linje. For hver linje er *Reservedel.beholdning* større end eller lig med antallet på linjen. |
| **Postbetingelser** | For hver linje på udtagslisten:<br>• Et nyt *Udtag* u er oprettet.<br>• u er knyttet til den valgte *Reparation*, den valgte *Medarbejder* og linjens *Reservedel*.<br>• u.dato er sat til dags dato.<br>• u.antalTaget er sat til linjens antal.<br>• *Reservedel.beholdning* er nedskrevet med linjens antal.<br>Udtagslisten er tømt. Udtagene og de nye beholdninger er gemt i tekstfilerne. Brugeren får de registrerede reservedele på servicen og de reservedele, der nu skal bestilles. |
| **Fejlbetingelser** | Service, medarbejder eller reservedele på listen mangler (UC6 6a), eller beholdningen er blevet for lille (UC6 7a): intet *Udtag* er oprettet, og ingen *Reservedel.beholdning* er ændret. Gemning i tekstfilerne fejler: intet er ændret. \[Antagelse\] |

## Noter

- `vælgService` og `fjernReservedel` har ingen kontrakt. `vælgService` læser kun data, og `fjernReservedel` ændrer kun udtagslisten, som ikke er en del af domænemodellen.
- Medarbejderen angives først ved `gemUdtag`, ikke i et eget trin, som SSD'et viser.
- Beholdningen kontrolleres både ved `tilføjReservedel` (for hurtig besked) og som præbetingelse for `gemUdtag`, fordi en anden kan nå at tage samme reservedel imellem. \[Antagelse\]
- Efter `gemUdtag` kan en *Reservedel* være kommet på eller under *minimumsbeholdning*. Den vises så på bestillingslisten (UC7) og returneres som en del af svaret.
- "Alle linjer eller ingen" er en bevidst regel: et udtag gemmes enten helt eller slet ikke, så beholdning og forbrug aldrig kommer ud af trit.
