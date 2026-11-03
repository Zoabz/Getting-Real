# Objektmodel – Vekto Cykelværksted

En objektmodel viser konkrete objekter og deres værdier på et bestemt tidspunkt. Den bygger på [domænemodellen](../2.%20Domænemodel/domænemodel.md) og er her vist for use case [UC6 Reservedele udtag](../1.%20Usecases/UC6%20Reservedele%20udtag.md).

Alle navne og værdier er **eksempeldata**, som vi har fundet på til at vise modellen (bortset fra reservedelsnavnene, som kommer fra lagerarket i uge 37).

## Situation

En mekaniker (Annette) har brugt 2 sæt bremseklodser og 1 liter kædeolie på reparation 1001 og registrerer udtaget (UC6).

## Før udtaget gemmes

```mermaid
classDiagram
    class r1["r1 : Reparation"] {
        reparationsnummer = 1001
        indleveringsdato = 2026-11-02
        cykelbeskrivelse = Trek FX 2
        fejlbeskrivelse = Bremserne larmer
        status = Åben
    }
    class k1["k1 : Kunde"] {
        navn = Mette Hansen
        telefonnummer = +4512345678
    }
    class m1["m1 : Medarbejder"] {
        navn = Annette
        initialer = AN
    }
    class rd1["rd1 : Reservedel"] {
        beskrivelse = Bremseklodser (skive)
        beholdning = 5
        minimumsbeholdning = 4
    }
    class rd2["rd2 : Reservedel"] {
        beskrivelse = Kædeolie 1L
        beholdning = 3
        minimumsbeholdning = 2
    }
    class l1["l1 : Leverandør"] {
        navn = Nordic Bike Parts A/S
        adresse = Vejle
    }

    k1 -- r1
    l1 -- rd1
    l1 -- rd2
```

## Efter udtaget er gemt

```mermaid
classDiagram
    class r1["r1 : Reparation"] {
        reparationsnummer = 1001
        status = Åben
    }
    class m1["m1 : Medarbejder"] {
        initialer = AN
    }
    class u1["u1 : Udtag"] {
        dato = 2026-11-03
        antalTaget = 2
    }
    class u2["u2 : Udtag"] {
        dato = 2026-11-03
        antalTaget = 1
    }
    class rd1["rd1 : Reservedel"] {
        beskrivelse = Bremseklodser (skive)
        beholdning = 3
        minimumsbeholdning = 4
    }
    class rd2["rd2 : Reservedel"] {
        beskrivelse = Kædeolie 1L
        beholdning = 2
        minimumsbeholdning = 2
    }

    r1 -- u1
    r1 -- u2
    u1 -- m1
    u2 -- m1
    u1 -- rd1
    u2 -- rd2
```

## Hvad ændrede sig

| Objekt | Før | Efter |
| :---- | :---- | :---- |
| u1 : Udtag | findes ikke | oprettet, knyttet til r1, m1 og rd1 (antalTaget = 2) |
| u2 : Udtag | findes ikke | oprettet, knyttet til r1, m1 og rd2 (antalTaget = 1) |
| rd1 : Reservedel | beholdning = 5 | beholdning = 3, dvs. under minimum (4), så bremseklodser kommer på bestillingslisten (UC7) |
| rd2 : Reservedel | beholdning = 3 | beholdning = 2, dvs. på minimum (2), så kædeolie også kommer på bestillingslisten (UC7) |

Eksemplet viser også reglen fra UC7: en reservedel skal bestilles, når beholdningen er **på eller under** minimum.
