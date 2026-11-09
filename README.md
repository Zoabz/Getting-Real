# Getting Real

Vores 1. semesters projekt for **Vekto Cykelværksted** i Kolding. Vi laver en prototype af et værkstedssystem, der samler reparationer og lager ét sted, så mekanikerne kan registrere, hvilke reservedele de bruger, og Peter kan se, hvad der skal bestilles.

Prototypen bliver en WPF-applikation med lagdelt arkitektur (MVVM). Data gemmes i tekstfiler, ikke i en database. Vi arbejder efter Scrum.

Product owner er Peter Obling. Teamet er Frederik, Mikkel, John, Mads, Kavishan og Majed.

## Dokumentation

Mapperne er nummereret i den rækkefølge, vi arbejder i:

- **0. Ordliste** – de begreber, vi bruger, så vi og Vekto bruger de samme ord.
- **1. Usecases** – en fil for hver use case, UC1–UC9.
- **2. Domænemodel** – domænemodellen som diagram og en tekst med klasser og relationer.
- **3. Objekt Model** – et konkret eksempel (øjebliksbillede) på domænemodellen med objekter fra UC1–UC9.
- **4. System Sekvens Diagram** – SSD for alle ni use cases som PlantUML (`.puml`), samlet i en PDF.
- **5. System Operations Kontrakt** – kontrakter for udvalgte systemoperationer i UC3, UC6 og UC9, med objektmodeller der viser før- og eftertilstand.
- **6. Brugergrænseflade** – navigationsmodeller og tegninger af siderne i programmet, med en PDF af hver.
- **7. Designklassediagram** – klasserne i prototypen med attributter, typer og metoder, lavet ud fra domænemodellen, SSD'erne og kontrakterne.
- **Materiale** – opgaveoplæg, casen fra Vekto og slides fra undervisningen.

Diagrammerne er skrevet i PlantUML (`.puml`). Tekst, fx use cases, ordliste og kontrakter, er skrevet i `.md`.
