# UC2 – Opret Kunde I Butikken

| Felt | Beskrivelse |
| :---- | :---- |
| **Nummer** | UC2 |
| **Use case navn** | Opret Kunde I Butikken |
| **Virkefelt** | Vekto værkstedssystem (WPF-prototype) |
| **Niveau** | Brugermål |
| **Primær aktør** | Medarbejder (mekaniker eller ejer) |
| **Mål** | At få en ny kunde oprettet med navn og telefonnummer, så kunden kan findes igen og knyttes til en reparationsordre (UC3). |
| **Interessenter** | **Mekanikerne:** Vil kunne oprette en kunde hurtigt, mens kunden står i værkstedet, og siden finde kunden igen på telefonnummer. **Kunderne:** Vil have deres navn og telefonnummer registreret korrekt, så reparationen bliver knyttet til den rigtige person. |
| **Før-tilstand** | Programmet er startet. |
| **Efter-tilstand** | Kunden er gemt med navn og telefonnummer og kan vælges, når en reparationsordre oprettes (UC3). |

## Hovedscenarie

1. Brugeren vælger at oprette en ny kunde.
2. Systemet viser en formular med felterne *Navn* og *Tlf nr*.
3. Brugeren indtaster kundens navn.
4. Brugeren indtaster kundens telefonnummer (fx +45 12 34 56 78).
5. Brugeren trykker **Opret**.
6. Systemet kontrollerer felterne, gemmer kunden og viser en bekræftelse.

## Udvidelser

- **3a. Navn mangler:** Systemet markerer feltet og gemmer ikke, før det er udfyldt.
- **4a. Telefonnummer mangler eller er ugyldigt:** Systemet markerer feltet og gemmer ikke, før der er indtastet et gyldigt nummer. \[Antagelse\]
- **5a. En kunde med samme telefonnummer findes allerede:** Systemet viser den eksisterende kunde og spørger, om den skal bruges i stedet for at oprette en ny. \[Antagelse\]

## Specielle krav

- Data gemmes i tekstfiler.
- Telefonnummeret bruges som søgenøgle, når en kunde vælges i UC3 (søgningen viser navn og telefonnummer).

## Skærmbillede (fane: Opret Kunde)

Felter: **Navn**, **Tlf nr.**, knap **Opret**. Eksempel: *Frederik Eriksen, +4523129428*.

## Relaterede begreber og artefakter

- Begreber: Kunde (se [ordliste](../0.%20Ordliste/ordliste.md))
- Bruges af: UC3 Opret Service
