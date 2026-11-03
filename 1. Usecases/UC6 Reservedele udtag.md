# UC6 – Reservedele udtag

| Felt | Beskrivelse |
| :---- | :---- |
| **Nummer** | UC6 |
| **Use case navn** | Reservedele udtag |
| **Virkefelt** | Vekto værkstedssystem (WPF-prototype) |
| **Niveau** | Brugermål |
| **Primær aktør** | Mekaniker |
| **Mål** | At knytte de reservedele, der bruges, til den rette reparation og automatisk nedskrive lagerbeholdningen, så beholdningen altid er opdateret. |
| **Interessenter** | **Mekanikerne (fx Annette):** Vil have, at registreringen går hurtigt og ikke tager tid fra reparationen, og at delene er på lageret, når de skal bruges. **Peter:** Vil kunne se, hvilke dele en reparation har brugt, og have en pålidelig beholdning at bestille ud fra. |
| **Før-tilstand** | Der findes mindst én reparationsordre (service), mindst én medarbejder og mindst én reservedel på lageret. |
| **Efter-tilstand** | Forbruget er gemt på reparationsordren, og lagerbeholdningen er nedskrevet med det brugte antal. Ved utilstrækkelig beholdning er intet ændret. |

## Hovedscenarie

1. Mekanikeren vælger *Reservedele udtag*.
2. Mekanikeren vælger service (reparationsnummer) og medarbejder fra en dropdown eller via søgning.
3. Mekanikeren vælger en reservedel og indtaster antal.
4. Mekanikeren trykker **Tilføj**, og reservedelen kommer på udtagslisten.
5. Mekanikeren gentager trin 3 og 4 for hver reservedel, der er brugt.
6. Mekanikeren trykker **Gem**.
7. Systemet kontrollerer, at beholdningen er tilstrækkelig, gemmer forbruget på reparationsordren, nedskriver lagerbeholdningen og viser en bekræftelse.

## Udvidelser

- **3a. Antal er ikke et positivt helt tal:** Systemet afviser antallet og beder mekanikeren indtaste et gyldigt antal.
- **7a. Beholdningen er utilstrækkelig:** Systemet afviser registreringen, giver mekanikeren besked om den aktuelle beholdning og gemmer intet. Mekanikeren kan rette antallet eller afbryde.

## Specielle krav

- Data gemmes i tekstfiler.
- Registreringen skal kunne gennemføres hurtigt, så den ikke tager tid fra reparationen.

## Skærmbillede (fane: Reservedele udtag)

- **Øverst:** Vælg Service (reparationsnummer), Vælg medarbejder (dropdown/søgning).
- **Derunder:** Vælg Reservedel (dropdown/søgning), Antal, knap **Tilføj** (tilføjer reservedelen til en liste).
- **Derunder:** Liste over de reservedele, der er tilføjet.
- **Nederst:** Knap **Gem/Opdater** (opdaterer lageret).

## Åbent spørgsmål

- Skal en mekaniker kunne gemme flere udtag på samme service på forskellige tidspunkter? \[Antagelse: Det kan være nødvendigt.\] – spørg Peter.

## Relaterede begreber og artefakter

- Begreber: Udtag, Beholdning, Reparation (se [ordliste](../0.%20Ordliste/ordliste.md))
- Forudsætter: UC1, UC3, UC8
- Påvirker: UC4 (viser forbrug på ordren), UC7 (beholdning og bestillingsliste)
- Første sprint starter med UC3 og UC6.
- Se [SSD for UC6](../4.%20System%20Sekvens%20Diagram/SSD%20UC6%20Reservedele%20udtag.md) og [systemoperationskontrakter](../5.%20System%20Operations%20Kontrakt/SOK%20UC6%20Reservedele%20udtag.md).
