# Sekvensdiagrammer – Vekto værkstedssystem

Der er ét sekvensdiagram (SD) for hver use case. Et SD viser, hvad der sker **inde i systemet**, når en systemoperation fra [SSD'en](../4.%20System%20Sekvens%20Diagram/) bliver kaldt: hvilke objekter der samarbejder, og hvilke metoder de kalder. Der er ingen aktør. Kaldet kommer fra UI-laget (pilen fra venstre kant).

Objekterne og metoderne er de samme som i [designklassediagrammet](../7.%20Designklassediagram/designklassediagram.md).

| Use case | Diagram | Kilde |
| :---- | :---- | :---- |
| UC1 Opret Medarbejder | [UC1_opret_medarbejder.png](UC1_opret_medarbejder.png) | [.puml](UC1_opret_medarbejder.puml) |
| UC2 Opret Kunde | [UC2_opret_kunde.png](UC2_opret_kunde.png) | [.puml](UC2_opret_kunde.puml) |
| UC3 Opret Service | [UC3_opret_service.png](UC3_opret_service.png) | [.puml](UC3_opret_service.puml) |
| UC4 Service Kvittering | [UC4_service_kvittering.png](UC4_service_kvittering.png) | [.puml](UC4_service_kvittering.puml) |
| UC5 Udført Arbejde | [UC5_udfoert_arbejde.png](UC5_udfoert_arbejde.png) | [.puml](UC5_udfoert_arbejde.puml) |
| UC6 Reservedele udtag | [UC6_reservedele_udtag.png](UC6_reservedele_udtag.png) | [.puml](UC6_reservedele_udtag.puml) |
| UC7 Lager og bestilling | [UC7_lager_og_bestilling.png](UC7_lager_og_bestilling.png) | [.puml](UC7_lager_og_bestilling.puml) |
| UC8 Opret Reservedele | [UC8_opret_reservedele.png](UC8_opret_reservedele.png) | [.puml](UC8_opret_reservedele.puml) |
| UC9 Opret Reservedele Modtagelse | [UC9_opret_reservedele_modtagelse.png](UC9_opret_reservedele_modtagelse.png) | [.puml](UC9_opret_reservedele_modtagelse.puml) |

Alle ni er samlet i [Sekvensdiagrammer.pdf](Sekvensdiagrammer.pdf).

## Sådan læses diagrammerne

- **Pil fra venstre kant:** kald fra UI-laget, fx når brugeren trykker Opret.
- **Fuldt optrukket pil:** metodekald. **Stiplet pil:** returværdi.
- **create(...):** et nyt objekt oprettes med konstruktøren.
- **alt:** enten–eller, fx fejl eller gyldige data. **opt:** sker kun, hvis betingelsen er opfyldt. **loop:** gentages. **ref:** henviser til et andet diagram.
- **== Overskrift ==** deler diagrammet op, når use casen har flere systemoperationer.
- **throw ...:** systemet afviser, og UI-laget viser fejlbeskeden. Intet gemmes.
- **Gem():** kaldes efter hver ændring og gemmer alle data via Datafil.

## Fra SSD til SD

| UC | Systemoperationer i SSD'en | Det vigtigste, der sker i SD'et |
| :---- | :---- | :---- |
| UC1 | opretMedarbejder | Tjek af unikke initialer → `create Medarbejder` → `Add` → `Gem` |
| UC2 | opretKunde | Mellemrum fjernes, tjek af unikt telefonnummer → `create Kunde` → `Add` → `Gem` |
| UC3 | soegKunde, opretService | `Matcher` på hver kunde. `create Reparation` med næste nummer og status Åben → `Add` → `Gem` |
| UC4 | soegServices, visKvittering | `Matcher` på hver reparation. Kvitteringen henter `HentUdtag` |
| UC5 | vaelgService, registrerUdfoertArbejde | `Reparation.Luk` sætter udført arbejde, medarbejder, dato og status Lukket → `Gem` |
| UC6 | tilfoejReservedel, fjernReservedel, gemUdtag | `HarNokPåLager` ved Tilføj og igen ved Gem. `TilføjUdtag` og `NedskrivLager` for hver linje → `Gem` |
| UC7 | visLager | `SkalBestilles` og `Mangler` på hver reservedel. Listen sorteres efter mangler |
| UC8 | opretReservedel | Tjek af unikt navn. Eksisterende leverandør genbruges, ellers `create Leverandør` → `create Reservedel` → `Gem` |
| UC9 | vaelgReservedel, modtagReservedel | `SkalBestilles` tjekkes. `create Modtagelse` → `OpskrivLager` → `Gem` |

## Antagelser

- Fejl sendes til UI-laget som en exception (`ArgumentException` eller `InvalidOperationException`), som vises som en rød besked.
- Id sættes til antal i listen + 1. Det virker, fordi prototypen ikke sletter noget.
- I UC6 bygges udtagslisten i UI-laget. Lageret tjekkes igen ved Gem, så intet gemmes, hvis beholdningen er ændret siden Tilføj (UC6, udvidelse 7a).
- I UC9 kan der kun modtages reservedele, der står på bestillingslisten (CO9).

## Ændre et diagram

Ret i `.puml`-filen og lav PNG'en igen, fx med PlantUML-udvidelsen i VS Code (Alt+D viser diagrammet) eller med:

```bash
java -jar plantuml.jar -charset UTF-8 -tpng *.puml
```
