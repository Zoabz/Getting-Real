# SSD – UC3 Opret Service

Systemsekvensdiagram for [UC3 Opret Service](../1.%20Usecases/UC3%20Opret%20Service.md). Systemet er en sort boks (*Vekto*).

## Hovedscenarie

```mermaid
sequenceDiagram
    actor M as Medarbejder
    participant S as :Vekto

    M->>S: søgKunde(telefonnummer)
    S-->>M: kundens navn og telefonnummer

    M->>S: opretService(telefonnummer, mærke, model, fejltype, fejlbeskrivelse)
    S-->>M: servicekvittering (ordrenummer, status Åben)
```

## Udvidelser

### 3a. Kunden findes ikke

```mermaid
sequenceDiagram
    actor M as Medarbejder
    participant S as :Vekto

    M->>S: søgKunde(telefonnummer)
    S-->>M: ingen kunde fundet
    M->>S: opretKunde(navn, telefonnummer)
    S-->>M: kunde oprettet
    Note over M,S: Fortsætter med opretService (se UC2 Opret Kunde)
```

### 6a. Obligatoriske felter mangler

```mermaid
sequenceDiagram
    actor M as Medarbejder
    participant S as :Vekto

    M->>S: opretService(telefonnummer, mærke, model, fejltype, fejlbeskrivelse)
    S-->>M: fejl – manglende felter markeret
```

## Systemoperationer

| Operation | Parametre | Svar | Kontrakt |
| :---- | :---- | :---- | :---- |
| søgKunde | telefonnummer | Kundens navn og telefonnummer | – (forespørgsel, ændrer intet) |
| opretKunde | navn, telefonnummer | Bekræftelse | Se UC2 |
| opretService | telefonnummer, mærke, model, fejltype, fejlbeskrivelse | Servicekvittering | [SOK](../5.%20System%20Operations%20Kontrakt/SOK%20UC3%20Opret%20Service.md) |

## Noter

- Ordrenummer, status (*Åben*) og indleveringsdato sættes af systemet og er derfor ikke parametre.
- `søgKunde` identificerer kunden på telefonnummer, som er søgenøglen i UC2. Det samme nummer bruges derefter i `opretService`. \[Antagelse\]
