# UC1 – Opret Medarbejder

| Felt | Beskrivelse |
| :---- | :---- |
| **Nummer** | UC1 |
| **Use case navn** | Opret Medarbejder |
| **Virkefelt** | Vekto værkstedssystem (WPF-prototype) |
| **Niveau** | Brugermål |
| **Primær aktør** | Ejer (Peter) eller medarbejder |
| **Mål** | At få en ny medarbejder oprettet med navn og initialer, så medarbejderen kan vælges på reparationsordrer og reservedelsforbrug. |
| **Interessenter** | **Peter:** Vil kunne se, hvem der har oprettet ordrer og brugt reservedele. **Mekanikerne:** Vil have deres navn og initialer i systemet, så medarbejder og dato sættes automatisk og ikke skal skrives hver gang. |
| **Før-tilstand** | Programmet er startet. |
| **Efter-tilstand** | Medarbejderen er gemt med navn og initialer og kan vælges i de øvrige funktioner (UC5 og UC6). |

## Hovedscenarie

1. Brugeren vælger at oprette en ny medarbejder.
2. Systemet viser en formular med felterne *Navn* og *Navn kort* (initialer).
3. Brugeren indtaster navn (fx John Pedersen).
4. Brugeren indtaster initialer (fx JP).
5. Brugeren trykker **Opret**.
6. Systemet kontrollerer felterne, gemmer medarbejderen og viser en bekræftelse.

## Udvidelser

- **3a. Navn mangler:** Systemet markerer feltet og gemmer ikke, før det er udfyldt.
- **4a. Initialer mangler:** Systemet markerer feltet og gemmer ikke, før det er udfyldt.
- **5a. Initialerne findes allerede:** Systemet afviser og beder om unikke initialer. \[Antagelse\]

## Specielle krav

- Data gemmes i tekstfiler.
- Initialerne vises på ordrer og skal derfor være unikke. \[Antagelse\]

## Skærmbillede (fane: Opret Medarbejder)

Felter: **Navn**, **Initialer**, knap **Opret**. Eksempel: *John Pedersen, JP*.

## Relaterede begreber og artefakter

- Begreber: Medarbejder, Initialer (se [ordliste](../0.%20Ordliste/ordliste.md))
- Bruges af: UC5 Udført Arbejde, UC6 Reservedele udtag
