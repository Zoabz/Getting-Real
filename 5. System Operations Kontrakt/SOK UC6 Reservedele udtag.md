# Systemoperationskontrakter – UC6 Reservedele udtag

Kontrakter for to af systemoperationerne i [SSD'et for UC6](../4.%20System%20Sekvens%20Diagram/SSD%20UC6%20Reservedele%20udtag.md). Begreber og klasser kommer fra [domænemodellen](../2.%20Domænemodel/domænemodel.md). Postbetingelserne er skrevet som tilstandsændringer i domænemodellen (oprettede objekter, nye relationer, ændrede attributter), ikke som programkode.

## Kontrakt 1: tilføjReservedel

| Felt | Beskrivelse |
| :---- | :---- |
| **Operation** | tilføjReservedel(reservedelsnavn, antal) |
| **Krydsreference** | UC6 Reservedele udtag, trin 3–4 |
| **Præbetingelser** | En *Reparation* og en *Medarbejder* er valgt for udtaget. En *Reservedel* med navnet reservedelsnavn findes. |
| **Postbetingelser** | Reservedelen og antallet er tilføjet udtagslisten (en liste, der kun findes, indtil udtaget gemmes). Hvis reservedelen allerede stod på listen, er antallet lagt til den eksisterende linje. \[Antagelse\] *Reservedel.beholdning* er uændret. Der er ikke oprettet nogen *Udtag*. |
| **Fejlbetingelser** | Antal er ikke et positivt helt tal (UC6 3a): intet er tilføjet, og brugeren får besked. |

## Kontrakt 2: gemUdtag

| Felt | Beskrivelse |
| :---- | :---- |
| **Operation** | gemUdtag() |
| **Krydsreference** | UC6 Reservedele udtag, trin 6–7 |
| **Præbetingelser** | En *Reparation* og en *Medarbejder* er valgt. Udtagslisten indeholder mindst én linje. For hver linje er *Reservedel.beholdning* større end eller lig med antallet på linjen. |
| **Postbetingelser** | For hver linje på udtagslisten:<br>• Et nyt *Udtag* u er oprettet.<br>• u er knyttet til den valgte *Reparation*, den valgte *Medarbejder* og linjens *Reservedel*.<br>• u.dato er sat til dags dato.<br>• u.antalTaget er sat til linjens antal.<br>• *Reservedel.beholdning* er nedskrevet med linjens antal.<br>Udtagslisten er tømt. Udtagene og de nye beholdninger er gemt i tekstfilerne. |
| **Fejlbetingelser** | Beholdningen er utilstrækkelig for mindst én linje (UC6 7a): intet *Udtag* er oprettet, ingen *Reservedel.beholdning* er ændret, og brugeren får besked om den aktuelle beholdning. Gemning i tekstfilerne fejler: intet er ændret. \[Antagelse\] |

## Noter

- Efter `gemUdtag` kan en *Reservedel* være kommet på eller under *minimumsbeholdning*. Den vises så på bestillingslisten i UC7, uden at systemet gør noget ekstra.
- Betingelsen "alle linjer eller ingen" er en bevidst regel: et udtag gemmes enten helt eller slet ikke, så beholdning og forbrug aldrig kommer ud af trit.
