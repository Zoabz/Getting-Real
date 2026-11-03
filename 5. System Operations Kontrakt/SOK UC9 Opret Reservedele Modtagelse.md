# Systemoperationskontrakt – UC9 Opret Reservedele Modtagelse

Kontrakt for systemoperationen `modtagReservedel` i [SSD'et for UC9](../4.%20System%20Sekvens%20Diagram/UC9_opret_reservedele_modtagelse.puml). Begreber og klasser kommer fra [domænemodellen](../2.%20Domænemodel/domænemodel.md).

Objektmodel med præbetingelser (blå) og postbetingelser (pink): [SOK UC9 Opret Reservedele Modtagelse - objektmodel.puml](SOK%20UC9%20Opret%20Reservedele%20Modtagelse%20-%20objektmodel.puml).

## Kontrakt: modtagReservedel

| Felt | Beskrivelse |
| :---- | :---- |
| **Operation** | modtagReservedel(reservedel, antal, dato) |
| **Krydsreference** | UC9 Opret Reservedele Modtagelse, trin 3–7 |
| **Præbetingelser** | En *Reservedel* med navnet reservedel findes og er valgt med `vælgReservedel` (den står på bestillingslisten, dvs. beholdning er på eller under minimumsbeholdning). antal er et positivt helt tal. dato er en gyldig dato, der ikke ligger i fremtiden. |
| **Postbetingelser** | • *Reservedel.beholdning* er øget med antal.<br>• Modtagelsen med antal og dato er registreret og gemt i tekstfilerne. \[Antagelse: modtagelsesdatoen gemmes sammen med modtagelsen\]<br>Brugeren får den nye beholdning og status: *OK*, hvis beholdningen nu er over *minimumsbeholdning*, ellers *Skal bestilles*. |
| **Fejlbetingelser** | Oplysninger mangler, antal er ikke et positivt helt tal, eller datoen ligger i fremtiden (UC9 4a og 5a): intet er ændret, og brugeren får en fejlbesked. Gemning fejler (UC9 7a): *Reservedel.beholdning* er uændret. \[Antagelse\] |

## Noter

- Domænemodellen har ikke et begreb for en modtagelse. Postbetingelsen bruger derfor en "registrering" af modtagelsen. Den kan blive en ny klasse, eller *Bestillingslinje.modtagetAntal* kan bruges, hvis bestillinger oprettes i systemet. Se åbne punkter i domænemodellen.
- Modtagelse af reservedele, der ikke står på bestillingslisten, er ikke dækket. \[Antagelse\]
- `vælgReservedel` har ingen kontrakt, fordi den kun læser data.
