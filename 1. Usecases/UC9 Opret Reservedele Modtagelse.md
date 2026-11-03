# UC9 – Opret Reservedele Modtagelse

| Felt | Beskrivelse |
| :---- | :---- |
| **Nummer** | UC9 |
| **Use case navn** | Opret Reservedele Modtagelse |
| **Virkefelt** | Vekto værkstedssystem (WPF-prototype) |
| **Niveau** | Brugermål |
| **Primær aktør** | Medarbejder (fx Kasper ved modtagelse af varer) |
| **Mål** | At registrere modtagne reservedele fra leverandøren, så lagerbeholdningen opdateres. |
| **Interessenter** | **Kasper:** Vil have en hurtig og nem måde at registrere modtagne varer på. **Peter:** Vil kunne stole på lagerbeholdningen og se, hvilke reservedele der stadig mangler. **Mekanikerne:** Vil have, at delene er på lageret og kan findes, når de skal bruges. |
| **Før-tilstand** | Mindst én reservedel står på listen over reservedele, der skal bestilles ([UC7](UC7%20Lager%20og%20bestilling.md)), og leveringen er ankommet. |
| **Efter-tilstand** | Det modtagne antal er lagt til lagerbeholdningen med modtagelsesdato, og lageroversigten er opdateret (UC7). |

## Hovedscenarie

1. Brugeren vælger *Opret reservedele modtagelse*.
2. Systemet viser en formular med felterne *Reservedele*, *Antal modtaget* og *Dato*.
3. Brugeren vælger en reservedel. Systemet viser kun reservedele fra listen over reservedele, der skal bestilles (UC7).
4. Brugeren indtaster antal modtaget.
5. Brugeren indtaster dato for modtagelsen. \[Antagelse: dagens dato kan være forudfyldt\]
6. Brugeren trykker **Modtag**.
7. Systemet lægger det modtagne antal til lagerbeholdningen, opdaterer lageroversigten og viser en bekræftelse.

## Udvidelser

- **2a. Listen over reservedele, der skal bestilles, er tom:** Systemet viser en besked om, at der ikke er noget at modtage.
- **4a. Antal modtaget er ikke et positivt helt tal:** Systemet afviser antallet og beder om et gyldigt antal.
- **5a. Datoen mangler eller ligger i fremtiden:** Systemet beder om en gyldig dato. \[Antagelse\]
- **7a. Gem fejler:** Systemet viser en fejlbesked og ændrer ikke lageret. \[Antagelse\]

## Specielle krav

- Data gemmes i tekstfiler.
- Kun reservedele fra bestillingslisten (UC7) kan vælges.
- Navnet på reservedelen er det samme på lageret og i bestillingslisten.
- Modtagelse af reservedele, der ikke står på listen, er ikke beskrevet i To-Do Listen. \[Antagelse\]

## Skærmbillede (fane: Opret Reservedele Modtagelse)

Felter: **Vælg Reservedele** (viser kun reservedele fra den sorterede liste over reservedele, som skal bestilles), **Antal modtaget**, **Dato**. Knap **Modtag** (opdaterer lagerlisten over reservedele).

## Relaterede begreber og artefakter

- Begreber: Modtagelse, Antal modtaget, Beholdning (se [ordliste](../0.%20Ordliste/ordliste.md))
- Forudsætter: UC7, UC8
- Påvirker: UC7 (beholdning)
