# Systemoperationskontrakt – UC9 Opret Reservedele Modtagelse

Kontrakt for systemoperationen `modtagReservedel` i [SSD'et for UC9](../4.%20System%20Sekvens%20Diagram/SSD%20UC9%20Opret%20Reservedele%20Modtagelse.md). Begreber og klasser kommer fra [domænemodellen](../2.%20Domænemodel/domænemodel.md).

## Kontrakt: modtagReservedel

| Felt | Beskrivelse |
| :---- | :---- |
| **Operation** | modtagReservedel(reservedelsnavn, antalModtaget, dato) |
| **Krydsreference** | UC9 Opret Reservedele Modtagelse, trin 3–7 |
| **Præbetingelser** | En *Reservedel* med navnet reservedelsnavn findes og står på bestillingslisten (beholdning er på eller under minimumsbeholdning). antalModtaget er et positivt helt tal. dato er en gyldig dato, der ikke ligger i fremtiden. |
| **Postbetingelser** | • *Reservedel.beholdning* er øget med antalModtaget.<br>• Modtagelsen med antal og dato er registreret og gemt i tekstfilerne. \[Antagelse: modtagelsesdatoen gemmes sammen med modtagelsen\]<br>Lageroversigten er opdateret. Hvis beholdningen nu er over *minimumsbeholdning*, står reservedelen ikke længere på bestillingslisten (UC7). |
| **Fejlbetingelser** | antalModtaget er ikke et positivt helt tal (UC9 4a), eller datoen mangler eller ligger i fremtiden (UC9 5a): intet er ændret, og brugeren får besked. Gemning fejler (UC9 7a): *Reservedel.beholdning* er uændret. \[Antagelse\] |

## Noter

- Domænemodellen har ikke et begreb for en modtagelse. Postbetingelsen bruger derfor en "registrering" af modtagelsen. Den kan blive en ny klasse, eller *Bestillingslinje.modtagetAntal* kan bruges, hvis bestillinger oprettes i systemet. Se åbne punkter i domænemodellen.
- Modtagelse af reservedele, der ikke står på bestillingslisten, er ikke dækket. \[Antagelse\]
- `hentBestillingsliste` har ingen kontrakt, fordi den kun læser data.
