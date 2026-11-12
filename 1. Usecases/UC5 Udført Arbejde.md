# UC5 – Udført Arbejde På Reparationen

| Felt | Beskrivelse |
| :---- | :---- |
| **Nummer** | UC5 |
| **Use case navn** | Udført Arbejde På Reparationen |
| **Virkefelt** | Vekto værkstedssystem (WPF-prototype) |
| **Niveau** | Brugermål |
| **Primær aktør** | Mekaniker |
| **Mål** | At registrere, hvilket arbejde en medarbejder har udført på en reparationsordre, så ordren viser, hvad der er gjort. |
| **Interessenter** | **Mekanikerne:** Vil hurtigt kunne skrive, hvad de har lavet, uden at gå efter papir. **Peter:** Vil kunne se, hvad der er udført på hver reparation, og af hvem. |
| **Før-tilstand** | Der findes mindst én åben reparationsordre ([UC3](UC3%20Opret%20Service.md)), og medarbejderen er oprettet ([UC1](UC1%20Opret%20Medarbejder.md)). |
| **Efter-tilstand** | Det udførte arbejde er gemt på reparationsordren sammen med medarbejderen og kan ses i serviceoversigten ([UC4](UC4%20Service%20Kvittering.md)). Reparationsordren har status *Lukket*. |

## Hovedscenarie

1. Brugeren vælger *Udført arbejde*.
2. Systemet viser en formular med felterne *Service* (reparationsnummer), *Medarbejder* og *Beskrivelse af udført arbejde*.
3. Brugeren vælger service (reparationsnummer) i en dropdown eller via søgning.
4. Brugeren vælger medarbejder i en dropdown eller via søgning.
5. Brugeren skriver en beskrivelse af det udførte arbejde.
6. Brugeren trykker **Gem**, og systemet gemmer arbejdet på reparationsordren, sætter status til *Lukket* og viser en bekræftelse.

## Udvidelser

- **3a. Servicen findes ikke eller er lukket:** Systemet viser en besked og gemmer ikke. \[Antagelse\]
- **5a. Beskrivelsen mangler:** Systemet markerer feltet og gemmer ikke, før den er udfyldt.

## Specielle krav

- Data gemmes i tekstfiler.
- Service og medarbejder vælges i lister med søgning, så nummer og navn ikke skal skrives i hånden.

## Skærmbillede (fane: Udført Arbejde)

Felter: **Vælg Service (reparationsnummer)**, **Vælg medarbejder** (dropdown/søgning), **Beskrivelse for udført arbejde**, knap **Gem** (status ændres til *Lukket*).

## Relaterede begreber og artefakter

- Begreber: Udført arbejde, Status (se [ordliste](../0.%20Ordliste/ordliste.md))
- Forudsætter: UC1, UC3
- Vises i: UC4
