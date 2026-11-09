# Navigationsdiagram

Hvilke skærme kan brugeren gå mellem? Kasserne er skærme. Pilene viser navigation, og teksten beskriver det valg eller den handling, der fører videre.

![Navigationsdiagram for Vekto værkstedssystem](navigationsdiagram.png)

*Figur: Hele programmet – fra menuen i hovedvinduet til de ni sider og kvitteringsdialogen.*

- **Kasse:** Skærmbillede.
- **Stiplet kasse:** Dialog, der åbner oven på siden.
- **Pil:** Navigation.
- **Tekst:** Brugerens valg.
- **Løkke:** Brugeren bliver på samme skærm.

## Sådan hænger skærmene sammen

- Programmet starter i hovedvinduet og viser siden Opret service.
- Menuen i venstre side er altid synlig. Brugeren vælger en side i menuen, og siden vises. Pilene tilbage til hovedvinduet betyder, at brugeren vælger et andet punkt i menuen.
- På Opret service fører **Opret** til kvitteringen, som åbner som en dialog. **Luk** fører tilbage til Opret service.
- På Service kvittering fører **Vis kvittering** (eller dobbeltklik på en række) til den samme dialog. **Luk** fører tilbage til Service kvittering.
- **Opret**, **Gem**, **Tilføj**, **Fjern** og **Modtag** bliver på samme skærm og viser en besked.
- Lager og bestilling har ingen knapper. Varer, der skal bestilles, registreres under Reservedele modtagelse, som brugeren vælger i menuen.

## Designbeslutninger

Det er designbeslutninger, som skal afstemmes med use casene og afprøves:

- Der er ingen Tilbage-knap. Brugeren skifter side via menuen, som altid er synlig.
- **Luk** i kvitteringen fører tilbage til den side, dialogen blev åbnet fra.
- Efter **Opret**, **Gem** og **Modtag** bliver brugeren på siden og får en besked i stedet for at blive sendt videre.
- Ved fejl, fx hvis et felt mangler, bliver brugeren også på siden og får en rød besked. Intet gemmes.

## Relaterede artefakter

- [Navigationsmodeller](../Navigationsmodeller/) – én aktivitetsmodel pr. use case
- [Tegninger af sider](../Tegninger%20af%20sider.pdf) og [wireframes](../Wireframes.pdf)
- Diagrammet kan redigeres i [navigationsdiagram.drawio](navigationsdiagram.drawio), fx med Draw.io-udvidelsen i VS Code. PNG'en skal laves igen efter ændringer.
