# Designklassediagram – Vekto værkstedssystem

Designklassediagrammet viser de klasser, vi vil programmere i prototypen, med attributter, typer og metoder. Det bygger på [domænemodellen](../2.%20Domænemodel/domænemodel.md) (klasser og relationer), [systemsekvensdiagrammerne](../4.%20System%20Sekvens%20Diagram/) (systemoperationer) og [systemoperationskontrakterne](../5.%20System%20Operation%20Kontrakt/Systemoperationskontrakter.pdf) (hvad operationerne ændrer).

![Designklassediagram](designklassediagram.png)

- [designklassediagram.png](designklassediagram.png) – billedet af diagrammet.
- [designklassediagram.drawio](designklassediagram.drawio) – samme diagram, som kan redigeres i draw.io (diagrams.net eller Draw.io-udvidelsen i VS Code).
- [designklassediagram.puml](designklassediagram.puml) – samme klasser og relationer i PlantUML.

## Sådan læses diagrammet

- Hver kasse har tre sektioner: **klassenavn** øverst, **attributter** i midten og **operationer/metoder** nederst.
- Synlighed: `+` public, `-` private, `#` protected, `~` package (i C# `internal`, synlig i samme projekt). `#` bruges ikke, fordi der ikke er arv i designet.
- `«constructor»` markerer konstruktøren.
- `Type[0..*]` er en liste. `Type[0..1]` betyder, at værdien kan mangle (fx er `UdførtAf` tom, indtil reparationen er lukket).
- Pilen viser, hvilken vej man kan navigere. Fx kender en Reparation sin Kunde, men en Kunde kender ikke sine reparationer.
- Tallene ved linjerne er multipliciteter, som i domænemodellen.

## Klasserne

| Klasse | Ansvar |
| :---- | :---- |
| **Værksted** | Controller for hele systemet. Modtager systemoperationerne fra SSD'erne, holder listerne over alle objekter og gemmer efter hver ændring (`- Gem()`). |
| **Datafil** | Gemmer og indlæser alle data i én tekstfil. Listerne i Værksted er `~` (package), så Datafil kan læse og skrive dem, uden at de er public. |
| **Kunde** | Navn og telefonnummer. `Matcher` bruges, når der søges på telefonnummer eller navn (UC3). |
| **Medarbejder** | Navn og initialer. `ToString` giver fx *John Pedersen (JP)* til dropdowns. |
| **Reparation** | Kaldes *Service* i brugergrænsefladen. `Luk` sætter UdførtArbejde, UdførtAf, LukketDato og Status til Lukket (UC5). Kender sine udtag (UC4, UC6). |
| **Udtag** | Et antal af én reservedel, som en medarbejder har taget til en reparation (UC6). |
| **Reservedel** | Kender sit eget lager: `HarNokPåLager` og `NedskrivLager` (UC6), `OpskrivLager` (UC9), `SkalBestilles` og `Mangler` (UC7). |
| **Leverandør** | Oprettes sammen med reservedelen (UC8). |
| **Modtagelse** | En levering af en reservedel med dato og antal (UC9). |
| **ReparationStatus** | Åben eller Lukket. |

## Fra systemoperation til metode

| UC | SSD | Kontrakt | Metode i designet |
| :---- | :---- | :---- | :---- |
| UC1 | opretMedarbejder | CO1 opretMedarbejder | `Værksted.OpretMedarbejder` |
| UC2 | opretKunde | CO2 opretKunde | `Værksted.OpretKunde` |
| UC3 | soegKunde, opretService | CO3 opretService | `Værksted.SøgKunder`, `Værksted.OpretService` |
| UC4 | soegServices, visKvittering | CO4 visServiceKvittering | `Værksted.SøgServices`, `Reparation.HentUdtag` |
| UC5 | vaelgService, registrerUdfoertArbejde | CO5 registrerUdførtArbejde | `Værksted.RegistrerUdførtArbejde` → `Reparation.Luk` |
| UC6 | tilfoejReservedel, fjernReservedel, gemUdtag | CO6 registrerReservedeludtag | `Reservedel.HarNokPåLager` ved Tilføj. `Værksted.RegistrerUdtag` → `Reparation.TilføjUdtag` og `Reservedel.NedskrivLager` |
| UC7 | visLager | CO7 visLagerOgBestilling | `Værksted.HentLageroversigt`, `Værksted.HentBestillingsliste` |
| UC8 | opretReservedel | CO8 opretReservedel | `Værksted.OpretReservedel` |
| UC9 | vaelgReservedel, modtagReservedel | CO9 registrerModtagelse | `Værksted.RegistrerModtagelse` → `Reservedel.OpskrivLager` |

Tilføj og Fjern i UC6 ændrer kun udtagslisten i skærmbilledet. Intet gemmes, før brugeren trykker Gem, og så kaldes `RegistrerUdtag` med hele listen.

## Designbeslutninger

- **Én controller.** Værksted modtager alle systemoperationer, fordi systemet er lille, og alle sider bruger de samme data.
- **Én datafil.** Alt gemmes i én fil efter hver ændring, som vist i tegningen af hovedvinduet.
- **Id på Medarbejder, Kunde og Reservedel**, fordi SSD'erne returnerer medarbejderId, kundeId og reservedelId, og listerne i programmet viser et nummer.
- **LukketDato er tilføjet** i forhold til domænemodellen, fordi SSD'en for UC5 returnerer lukketidspunktet, og kvitteringen viser datoen.
- **Leverandør har ingen egen liste.** `OpretReservedel` genbruger en leverandør med samme navn fra en eksisterende reservedel eller opretter en ny.
- **Validering** (fx unikke initialer, telefonnummer og reservedelsnavn) sker i Værksted, før objektet oprettes.

## Afvigelser fra systemoperationskontrakterne

Kontrakterne bruger andre navne end domænemodellen. Designet følger domænemodellen, så kontrakterne bør rettes, så alle dokumenter bruger de samme navne.

| I kontrakterne | I domænemodellen og designet |
| :---- | :---- |
| Reparationsordre, ordrenummer | Reparation, Reparationsnummer |
| Cykel med mærke og model | Mærke og Model er attributter på Reparation |
| UdførtArbejde-instans | UdførtArbejde (tekst) og UdførtAf (medarbejder) på Reparation |
| Reservedelsforbrug | Udtag |
| lagerbeholdning, minimumsantal | AntalPåLager, MinimumAntal |
| r.leverandør sættes til en tekst | Reservedel peger på et Leverandør-objekt |
| m.antal, m.modtagelsesdato | AntalModtaget, Dato |
