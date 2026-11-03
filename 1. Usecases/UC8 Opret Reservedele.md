# UC8 – Opret Reservedele

| Felt | Beskrivelse |
| :---- | :---- |
| **Nummer** | UC8 |
| **Use case navn** | Opret Reservedele |
| **Virkefelt** | Vekto værkstedssystem (WPF-prototype) |
| **Niveau** | Brugermål |
| **Primær aktør** | Ejer (Peter) eller medarbejder |
| **Mål** | At oprette en ny reservedel med navn, leverandør og minimumsantal, så den kan indgå i lageroversigten og i listen over reservedele, der skal bestilles. |
| **Interessenter** | **Peter:** Vil kunne oprette de reservedele, værkstedet bruger, og bestemme, hvornår de skal bestilles. **Mekanikerne:** Vil kunne vælge reservedelen, når de bruger den ([UC6](UC6%20Reservedele%20udtag.md)). |
| **Før-tilstand** | Programmet er startet. |
| **Efter-tilstand** | Reservedelen er gemt med navn, leverandør og minimumsantal og vises i lageroversigten ([UC7](UC7%20Lager%20og%20bestilling.md)). |

## Hovedscenarie

1. Brugeren vælger *Opret reservedele*.
2. Systemet viser en formular med felterne *Reservedele navn*, *Leverandør* og *Minimum antal*.
3. Brugeren indtaster reservedelens navn.
4. Brugeren vælger eller indtaster leverandør. \[Antagelse\]
5. Brugeren indtaster minimumsantal, dvs. det antal på lager, hvor reservedelen skal bestilles.
6. Brugeren trykker **Opret**.
7. Systemet kontrollerer felterne, gemmer reservedelen med antal på lager 0 og viser en bekræftelse. \[Antagelse\]

## Udvidelser

- **3a. Navn mangler eller findes allerede:** Systemet afviser og beder om et unikt navn, så samme reservedel ikke får to navne. \[Antagelse\]
- **4a. Leverandør mangler:** Systemet markerer feltet og gemmer ikke, før det er udfyldt.
- **5a. Minimumsantal er ikke et helt tal på 0 eller derover:** Systemet afviser værdien og beder om et gyldigt tal.

## Specielle krav

- Data gemmes i tekstfiler.
- Hver reservedel har ét fast navn, som bruges ens på lager, bestillingsliste og i forbrug og modtagelse (UC6, UC7, UC9).
- Leverandørens varenummer står ikke i To-Do Listen, men indgår i domænemodellen. \[Antagelse\]

## Skærmbillede (fane: Opret Reservedele)

Felter: **Reservedele navn**, **Leverandør**, **Minimum antal**, knap **Opret**.

## Relaterede begreber og artefakter

- Begreber: Reservedel, Leverandør, Minimumsbeholdning, Varenummer (se [ordliste](../0.%20Ordliste/ordliste.md))
- Bruges af: UC6, UC7, UC9
