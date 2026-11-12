# Domænemodel – Vekto Cykelværksted

Domænemodellen viser de begreber i Vektos forretning, som systemet skal kende, deres egenskaber og relationer. Den er lavet ud fra use casene UC1–UC9 og programmet (de data, programmet gemmer). Begreberne er forklaret i [ordlisten](../0.%20Ordliste/ordliste.md).

![Domænemodel](domænemodel.png)

- [domænemodel.png](domænemodel.png) – billedet af modellen.
- [domænemodel.drawio](domænemodel.drawio) – samme model, som kan redigeres i draw.io (diagrams.net).
- [domænemodel.puml](domænemodel.puml) – samme model i PlantUML.

## Klasser

| Klasse | Attributter | Beskrivelse |
| :---- | :---- | :---- |
| **Kunde** | navn, telefonnummer | Den, der har indleveret cyklen. Telefonnummeret bruges som søgenøgle (UC2, UC3). |
| **Reparation** | reparationsnummer, indleveringsdato, mærke, model, fejltype, fejlbeskrivelse, udførtArbejde, status | Én indleveret cykel og det arbejde, der skal udføres på den. Kaldes *Service* i brugergrænsefladen. Status er *Åben* eller *Lukket*. |
| **Medarbejder** | navn, initialer | En person ansat hos Vekto (UC1). |
| **Udtag** | dato, antalTaget | At en medarbejder har taget et antal af én reservedel til én reparation (UC6). |
| **Reservedel** | navn, antalPåLager, minimumAntal | En del, der bruges ved reparationer og ligger på lager (UC8). Skal bestilles, når antalPåLager er på eller under minimumAntal (UC7). |
| **Leverandør** | navn | Virksomhed, der leverer reservedele (UC8). |
| **Modtagelse** | dato, antalModtaget | At en levering af en reservedel er modtaget og lagt på lager (UC9). |

## Relationer

| Fra | Til | Multiplicitet | Betydning |
| :---- | :---- | :---- | :---- |
| Kunde | Reparation | 1 – 0..\* | En reparation tilhører én kunde. En kunde kan have mange reparationer, men kan også være oprettet uden en (UC2 før UC3). |
| Reparation | Medarbejder | 0..\* – 0..1 | Det udførte arbejde er lavet af én medarbejder. Før UC5 er der ingen (derfor 0..1). |
| Reparation | Udtag | 1 – 0..\* | En reparation kan have mange udtag. Et udtag hører til én reparation. |
| Udtag | Medarbejder | 0..\* – 1 | Et udtag er foretaget af én medarbejder. |
| Udtag | Reservedel | 0..\* – 1 | Et udtag gælder én reservedel. En reservedel kan indgå i mange udtag. |
| Leverandør | Reservedel | 1 – 1..\* | En reservedel har én leverandør. En leverandør oprettes sammen med en reservedel og har derfor mindst én. |
| Reservedel | Modtagelse | 1 – 0..\* | En modtagelse gælder én reservedel. En reservedel kan modtages mange gange. |

## Sammenhæng med use cases

| Klasse | Oprettes / ændres i |
| :---- | :---- |
| Medarbejder | UC1 |
| Kunde | UC2 |
| Reparation | UC3 (oprettes med status Åben), UC4 (vises), UC5 (udførtArbejde og medarbejder sættes, status Lukket) |
| Udtag, Reservedel.antalPåLager | UC6 (udtag nedskriver antal på lager) |
| Reservedel, Leverandør | UC8 (oprettes med navn, leverandør og minimum), UC7 (vises og vurderes mod minimum) |
| Modtagelse, Reservedel.antalPåLager | UC9 (modtaget antal lægges til antal på lager) |

## Ændringer i forhold til den udleverede model

Den udleverede model fra Vekto er tilpasset vores use cases og programmet:

1. **Bestilling og Bestillingslinje er fjernet.** Ingen use case opretter en bestilling. Bestillingslisten i UC7 beregnes ud fra antalPåLager og minimumAntal på Reservedel.
2. **Modtagelse er tilføjet**, fordi UC9 registrerer modtagne reservedele med dato og antal.
3. **Reparation** har fået *mærke*, *model* og *fejltype* (UC3) i stedet for *cykelbeskrivelse*, og *udførtArbejde* (UC5). *aftaltAfhentningsdato* er fjernet, fordi ingen use case sætter den.
4. **Reparation – Medarbejder** er tilføjet, fordi UC5 gemmer, hvem der har udført arbejdet.
5. **Reservedel** bruger *navn* (UC8) i stedet for *varenummer*, *beskrivelse* og *enhed*, som hverken use cases eller programmet bruger.
6. **Kunde – Reparation** er ændret fra 1..\* til 0..\*, fordi en kunde oprettes før reparationen (UC2).
7. **Leverandør** har kun *navn*, fordi adressen ikke bruges i nogen use case.
