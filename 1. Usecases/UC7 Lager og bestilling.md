# UC7 – Lager Og Bestilling Af Reservedele

| Felt | Beskrivelse |
| :---- | :---- |
| **Nummer** | UC7 |
| **Use case navn** | Lager Og Bestilling Af Reservedele |
| **Virkefelt** | Vekto værkstedssystem (WPF-prototype) |
| **Niveau** | Brugermål |
| **Primær aktør** | Ejer (Peter) eller medarbejder |
| **Mål** | At give overblik over lageret og en sorteret liste over de reservedele, der skal bestilles, så en bestilling kan forberedes uden manuel optælling. |
| **Interessenter** | **Peter:** Vil have et pålideligt grundlag at bestille ud fra uden at tælle op og samle sedler. **Mekanikerne:** Vil have de reservedele på lager, de skal bruge. |
| **Før-tilstand** | Reservedelene er oprettet med minimumsantal ([UC8](UC8%20Opret%20Reservedele.md)), og lageret er opdateret efter forbrug og modtagelse ([UC6](UC6%20Reservedele%20udtag.md), [UC9](UC9%20Opret%20Reservedele%20Modtagelse.md)). |
| **Efter-tilstand** | Lageroversigten og bestillingslisten er vist. Ingen data er ændret. |

## Hovedscenarie

1. Brugeren vælger *Lager og bestilling*.
2. Systemet viser en tabel over lageret med kolonnerne *Reservedele navn*, *Antal på lager*, *Minimum antal før det skal bestilles* og *Status* om det skal bestilles.
3. Systemet viser under tabellen en sorteret liste over de reservedele, der skal bestilles.
4. Brugeren gennemgår listen og bruger den som grundlag for en bestilling hos leverandøren.

## Udvidelser

- **2a. Der er ingen reservedele på lageret:** Systemet viser en tom tabel og en besked om, at der ikke er oprettet reservedele endnu.
- **3a. Ingen reservedele skal bestilles:** Systemet viser en besked om, at der ikke er noget at bestille.

## Specielle krav

- Data læses fra tekstfiler.
- En reservedel skal bestilles, når antal på lager er **på eller under** minimumsantallet.
- Systemet bestiller ikke hos leverandøren. Listen bruges som grundlag.
- Sorteringen er ikke fastlagt i To-Do Listen (fx mest kritiske først). \[Antagelse\]

## Skærmbillede (fane: Lager og bestilling)

- Tabel over lageret: Reservedele navn, Antal på lager, Minimum antal før det skal bestilles, Status om det skal bestilles.
- Under tabellen: sorteret liste over de reservedele, som skal bestilles.

## Relaterede begreber og artefakter

- Begreber: Lageroversigt, Bestillingsliste, Minimumsbeholdning (se [ordliste](../0.%20Ordliste/ordliste.md))
- Forudsætter: UC6, UC8, UC9
- Danner grundlag for: UC9 (kun reservedele på listen kan modtages)
