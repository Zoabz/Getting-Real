# Ordliste – Vekto Cykelværksted

Ordlisten samler de begreber, vi bruger i projektet, så vi og Vekto bruger de samme ord om de samme ting. Den vedligeholdes løbende og er udgangspunktet for navne i domænemodellen, brugergrænsefladen og koden.

> **Vigtigt – synonymer:** Samme begreb har fået flere navne i vores arbejde. **Reparation**, **reparationsordre** og **service** betyder det samme. Domænemodellen bruger *Reparation*, brugergrænsefladen bruger *Service*. Tilsvarende er **reparationsnummer**, **ordrenummer** og **service-id** det samme nummer.

## Virksomhed og aktører

| Begreb | Forklaring |
| :---- | :---- |
| **Vekto Cykelværksted ApS** | Cykelværksted i Kolding (Industrivej 12, 6000 Kolding, CVR 43215678), der reparerer og vedligeholder cykler. Fem medarbejdere plus ejeren. Åbent mandag–fredag kl. 8–17 og lørdag kl. 10–14. |
| **Product Owner (PO)** | Peter Obling. Den person hos virksomheden, der repræsenterer kundens behov og prioriterer vores Product Backlog. |
| **Ejer** | Peter Obling. Uddannet cykelmekaniker, kender varer og leverandører, bestiller reservedele og beslutter budget. Ressourcepersonale i interessentanalysen. |
| **Medarbejder** | En person ansat hos Vekto, som er oprettet i systemet med navn og initialer, så vedkommende kan vælges på reparationer og udtag (UC1). Bruges som overbegreb for mekanikere og andre ansatte. |
| **Mekaniker** | En medarbejder, der reparerer cykler og tager reservedele fra lageret (fx Annette, Mikkel og Jonas). Primær aktør i UC5 og UC6. |
| **Kasper** | Medarbejder, der modtager varer fra leverandøren og lægger dem på lager. Primær aktør i UC9. |
| **Initialer** | Kort form af en medarbejders navn (fx JP for John Pedersen). Vises på ordrer og skal være unikke (UC1). |
| **Kunde** | Person, der afleverer en cykel til reparation. Registreres med navn og telefonnummer (UC2). Bruger ikke selv systemet. |
| **Leverandør** | Virksomhed, som Vekto køber reservedele hos. Fx Nordic Bike Parts A/S i Vejle. Har navn og adresse. |
| **Nordic Bike Parts A/S** | Vektos leverandør af reservedele, beliggende i Vejle. Leveringstid er ca. en uge fra bestilling. |

## Reparation og service

| Begreb | Forklaring |
| :---- | :---- |
| **Reparation / reparationsordre / service** | Registreringen af én indleveret cykel og det arbejde, der skal udføres på den, fra indlevering til afhentning. Oprettes i UC3 og får ordrenummer og status *Åben*. |
| **Reparationsnummer / ordrenummer / service-id** | Unikt nummer, som systemet tildeler en reparation, når den oprettes. Bruges til at knytte udtag og udført arbejde til den rette reparation. |
| **Indleveringsdato** | Datoen, hvor cyklen blev afleveret. Sættes automatisk til dags dato ved oprettelse (UC3). |
| **Aftalt afhentningsdato** | Den dato, hvor kunden har fået at vide, at cyklen er færdig. Attribut på Reparation i domænemodellen. |
| **Cykelbeskrivelse (mærke og model)** | Beskrivelse af den indleverede cykel, fx *Hyundai i30*. I brugergrænsefladen indtastes mærke og model hver for sig. |
| **Fejltype** | Kategori af fejl, der vælges i en dropdown, når en reparation oprettes (UC3). |
| **Fejlbeskrivelse** | Fritekst om, hvad der er galt med cyklen (UC3). |
| **Status** | Reparationens aktuelle tilstand. Starter som *Åben* (UC3) og bliver *Lukket*, når udført arbejde er gemt (UC5). For en bestilling beskriver status, hvor langt den er. |
| **Åben / Lukket** | De to statusværdier for en reparation i prototypen. |
| **Servicekvittering** | Dialogboks, der vises med reparationens oplysninger, når en reparation er oprettet (UC3). Også navnet på fanen med tabellen over alle reparationer (UC4). |
| **Udført arbejde** | Beskrivelse af det arbejde, en mekaniker har udført på en reparation (UC5). Når det gemmes, lukkes reparationen. |

## Reservedele og lager

| Begreb | Forklaring |
| :---- | :---- |
| **Reservedel** | En del, som bruges til at reparere cykler, fx pedaler, bremseklodser, kæde eller slange. Har ét fast navn, leverandør og minimumsantal (UC8). |
| **Varenummer** | Leverandørens nummer på en reservedel. Fjerner tvivl om, hvorvidt to navne er den samme vare (fx "Bremseklodser (skive)" og "Shimano B05S klodser"). Indgår i domænemodellen, men står ikke i To-Do Listen. |
| **Enhed** | Hvordan en reservedel tælles, fx stk. eller liter. |
| **Lager** | Vektos beholdning af reservedele i værkstedet. |
| **Beholdning / antal på lager** | Det antal af en reservedel, der ifølge systemet er på lager. Nedskrives ved udtag (UC6) og forøges ved modtagelse (UC9). |
| **Cirkatal ("ca.")** | Den usikre beholdning, som står på papirlagerarket i dag. Det problem, løsningen skal fjerne. |
| **Lagerark** | Papirarket, hvor medarbejderne i dag skriver udtag af reservedele. Erstattes af systemet. |
| **Minimumsbeholdning / minimumsantal** | Det antal på lager, hvor en reservedel skal bestilles. Er beholdningen på eller under minimum, kommer reservedelen på bestillingslisten. Sættes af Peter. |
| **Lageroversigt** | Tabel over alle reservedele med navn, antal på lager, minimum og status for, om de skal bestilles (UC7). |
| **Bestillingsliste** | Sorteret liste under lageroversigten over de reservedele, der skal bestilles, fordi beholdningen er på eller under minimum (UC7). Systemet bestiller ikke selv hos leverandøren; listen er grundlag for en bestilling. |
| **Udtag** | Registrering af, at en mekaniker har taget et antal af en reservedel fra lageret til en bestemt reparation (UC6). Har dato og antal taget. |
| **Antal taget** | Antal af en reservedel i ét udtag. |
| **Udtagsliste** | Midlertidig liste i skærmbilledet, hvor mekanikeren tilføjer reservedele og antal, før alt gemmes samlet (UC6). |
| **Bestilling** | Indkøb af reservedele hos en leverandør med købsordrenummer, dato, ønsket leveringsdato, bemærkning og status. |
| **Bestillingslinje** | Én linje på en bestilling: en reservedel med bestillingsantal, forfaldsdato og modtaget antal. |
| **Købsordrenummer** | Nummer på en bestilling hos leverandøren. |
| **Modtagelse** | Registrering af, at en levering fra leverandøren er ankommet. Det modtagne antal lægges til beholdningen (UC9). |
| **Antal modtaget** | Det antal af en reservedel, der er leveret og registreret ved modtagelsen. |

## Projekt og metode

| Begreb | Forklaring |
| :---- | :---- |
| **Getting Real** | Semesterprojektet (uge 43–50), hvor teamet udvikler en prototype for en virksomhed. |
| **Prototype / PoC** | Simpel version af systemet, der viser, om løsningen kan fungere (Proof-of-Concept). Ikke et driftsklart system. |
| **WPF** | Windows Presentation Foundation. Teknologi til grafiske Windows-programmer, som projektet skal bruge. |
| **MVVM** | Model–View–ViewModel. Arkitekturmønster, vi bruger i den lagdelte WPF-applikation. |
| **Lagdelt arkitektur** | Programmet opdeles i lag (fx præsentation, logik og persistens) med bestemte afhængigheder. |
| **Persistens** | At gemme data, så de bevares, når programmet lukkes. I projektet sker det i tekstfiler, ikke i en database. |
| **Scrum** | Agil projektstyringsmetode, vi bruger. |
| **Sprint** | Tidsafgrænset arbejdsperiode i Scrum (to uger i sprint 1 og 2, én uge i sprint 3). |
| **Sprint review** | Møde, hvor teamet viser resultatet af en sprint til Product Owner og andre interessenter. |
| **Product Backlog** | Prioriteret liste over det, systemet skal kunne. |
| **To-Do Liste** | Vores oversigt over felter og funktioner pr. fane i programmet, som use cases er skrevet ud fra. |
| **Use case** | Beskrivelse af, hvordan en aktør bruger systemet til at nå et mål. Vi bruger fully-dressed format. |
| **Primær aktør** | Den, der starter use casen for at opnå et mål. |
| **Hovedscenarie** | Use casens normale forløb, hvor alt går som planlagt. |
| **Udvidelse** | Alternativt forløb i en use case, fx når et felt mangler. Nummereres efter det trin, den afviger fra (fx 3a). |
| **Domænemodel** | Model over de begreber (klasser), deres egenskaber og relationer i Vektos forretning. |
| **Objektmodel** | Model over konkrete objekter og deres værdier på et bestemt tidspunkt, baseret på domænemodellen. |
| **SSD** | Systemsekvensdiagram. Viser samspillet mellem aktør og system for én use case som en række systemoperationer. |
| **Systemoperation** | En hændelse, aktøren sender til systemet i et SSD, fx `gemUdtag`. |
| **SOK** | Systemoperationskontrakt. Beskriver før- og eftertilstand for en systemoperation. |
| **Præbetingelse / postbetingelse** | Hvad der skal være sandt før en systemoperation, og hvad der er sandt efter. |

## Interessentanalyse og mærkater

| Begreb | Forklaring |
| :---- | :---- |
| **Primær interessent** | Interessent, der bruger systemet direkte (Peter og mekanikerne). |
| **Sekundær interessent** | Interessent, der kun berøres indirekte (kunderne). |
| **Kerneinteressent** | Interessent, der skal få den nye arbejdsgang til at fungere. |
| **Ressourcepersonale** | Interessent med stor indflydelse og stor nødvendighed (Peter). |
| **Gidsel** | Interessent med lille indflydelse, men stor nødvendighed. Systemet virker ikke uden deres registrering, men de bestemmer ikke over den (mekanikerne og Kasper). |
| **\[Case\]** | Oplysning stammer fra Vekto-casen og dens bilag. |
| **\[Skøn\]** | Vores egen vurdering, fx af tid og pris. |
| **\[Antagelse\]** | Noget, vi har antaget, men ikke fået bekræftet af Vekto. |
| **\[Spørg Peter\]** | Åbent punkt, der skal afklares hos Product Owner. |
| **KPI** | Måltal for succes. Vores KPI er, hvor ofte den registrerede beholdning stemmer med den faktiske (mål: 95 % efter tre måneder). |
