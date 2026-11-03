# UC4 – Service Kvittering

| Felt | Beskrivelse |
| :---- | :---- |
| **Nummer** | UC4 |
| **Use case navn** | Service Kvittering |
| **Virkefelt** | Vekto værkstedssystem (WPF-prototype) |
| **Niveau** | Brugermål |
| **Primær aktør** | Medarbejder (mekaniker eller ejer) |
| **Mål** | At give overblik over alle reparationsordrer og deres status, så medarbejderne kan se, hvilke cykler der skal repareres, uden at gå efter håndskrevne mærker. |
| **Interessenter** | **Peter:** Vil have overblik over alle reparationer og deres status. **Mekanikerne:** Vil kunne se, hvilke cykler der skal repareres, og hvad fejlen er. **Kunderne:** Vil have cyklen færdig til den aftalte tid. |
| **Før-tilstand** | Programmet er startet. Der findes mindst én reparationsordre ([UC3](UC3%20Opret%20Service.md)). |
| **Efter-tilstand** | Oversigten er vist. Ingen data er ændret. |

## Hovedscenarie

1. Brugeren vælger *Service Kvittering*.
2. Systemet viser en tabel med alle reparationsordrer og kolonnerne *Service-id*, *Kundenavn*, *Kunde tlf*, *Model/mærke* (fx Hyundai i30), *Fejltype*, *Beskrivelse*, *Udført* (det udførte arbejde, UC5) og *Status*.
3. Brugeren sorterer eller filtrerer listen på status. \[Antagelse\]
4. Brugeren vælger en reparationsordre.
5. Systemet viser ordrens detaljer, herunder de reservedele der er brugt på den (UC6). \[Antagelse\]
6. Brugeren lukker detaljerne og vender tilbage til oversigten.

## Udvidelser

- **2a. Der findes ingen reparationsordrer:** Systemet viser en tom oversigt med en besked om, at der ikke er oprettet nogen ordrer endnu.
- **3a. Ingen ordrer passer til filteret:** Systemet viser en besked og tilbyder at nulstille filteret. \[Antagelse\]

## Specielle krav

- Data læses fra tekstfiler.
- Oversigten opdateres, når en ny reparationsordre oprettes (UC3), og når udført arbejde (UC5) og reservedelsforbrug (UC6) registreres.
- Kolonnerne følger To-Do Listen.

## Skærmbillede (fane: Service Kvittering)

Tabel med kolonnerne: Service Id, Kunde Navn, Kunde tlf, Model/mærke (fx Hyundai – I30), Fejltype, Beskrivelse, Udført, Status.

## Relaterede begreber og artefakter

- Begreber: Servicekvittering, Status, Udført arbejde (se [ordliste](../0.%20Ordliste/ordliste.md))
- Viser data fra: UC3, UC5, UC6
