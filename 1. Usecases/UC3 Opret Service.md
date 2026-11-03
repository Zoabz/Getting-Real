# UC3 – Opret Service

| Felt | Beskrivelse |
| :---- | :---- |
| **Nummer** | UC3 |
| **Use case navn** | Opret Service |
| **Virkefelt** | Vekto værkstedssystem (WPF-prototype) |
| **Niveau** | Brugermål |
| **Primær aktør** | Medarbejder (mekaniker eller ejer) |
| **Mål** | At få en indleveret cykel registreret som en reparationsordre, der er knyttet til den rette kunde og cykel, så reparationen kan følges fra indlevering til afhentning. |
| **Interessenter** | **Mekanikerne:** Vil kunne se, hvilke cykler der skal repareres, uden at gå efter håndskrevne mærker. **Peter:** Vil have overblik over alle reparationer og deres status. **Kunderne:** Vil have, at cyklen er registreret korrekt, så den bliver færdig til den aftalte tid. |
| **Før-tilstand** | Programmet er startet, og en cykel med fejl er afleveret til reparation. |
| **Efter-tilstand** | Der er gemt en reparationsordre (service) med ordrenummer og status *Åben*, knyttet til kunden og cyklen, og en servicekvittering er vist for medarbejderen. Indleveringsdatoen er sat automatisk til dags dato. \[Antagelse\] |

## Hovedscenarie

1. Medarbejderen vælger at oprette en ny reparationsordre (*Opret Service*).
2. Medarbejderen søger efter kunden på telefonnummer, og systemet viser kundens navn og telefonnummer.
3. Medarbejderen vælger kunden.
4. Medarbejderen indtaster cyklens mærke og model og vælger fejltype fra en dropdown.
5. Medarbejderen indtaster en fejlbeskrivelse.
6. Medarbejderen trykker **Opret**.
7. Systemet tildeler et ordrenummer, sætter status til *Åben*, gemmer ordren og viser en servicekvittering i en dialogboks.

## Udvidelser

- **3a. Kunden findes ikke:** Medarbejderen opretter en ny kunde med navn og telefonnummer (se [UC2](UC2%20Opret%20Kunde.md)) og fortsætter ved trin 3.
- **6a. Fejltype, mærke, model eller fejlbeskrivelse mangler:** Systemet markerer de manglende felter og gemmer ikke ordren, før de er udfyldt.

## Specielle krav

- Data gemmes i tekstfiler.
- Hver reparationsordre får et unikt ordrenummer.

## Skærmbillede (fane: Opret Service)

- **Vælg kunde:** Tlf nr. (søgning), viser *navn (tlf)*.
- **Produktinfo:** Mærke, Model, Fejltype (dropdown), Fejlbeskrivelse.
- Knap **Opret**. Når der trykkes, vises en servicekvittering (dialogboks).
- Servicens status er *Åben*, når den er oprettet.

## Relaterede begreber og artefakter

- Begreber: Reparation, Servicekvittering, Fejltype (se [ordliste](../0.%20Ordliste/ordliste.md))
- Forudsætter: [UC2 Opret Kunde](UC2%20Opret%20Kunde.md)
- Bruges af: UC4, UC5, UC6
- Første sprint starter med UC3 og UC6.
