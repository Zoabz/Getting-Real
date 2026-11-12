# CO8 – opretReservedel

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO8 |
| Operation | opretReservedel(navn: String, leverandør: String, minimumsantal: Integer) |
| Krydsreferencer | UC8 Opret Reservedele I Systemet |
| Forudsætninger | Programmet er startet. Navn er udfyldt og unikt, så der ikke findes en Reservedel med samme navn. [Antagelse] Leverandør er udfyldt. Minimumsantal er et helt tal på 0 eller derover. |
| Slutbetingelser | En Reservedel-instans r blev oprettet. r.navn blev sat til navn. r.leverandør blev sat til leverandør. r.minimumsantal blev sat til minimumsantal. r.lagerbeholdning blev sat til 0. [Antagelse] r blev tilføjet til systemets reservedele, så den kan vælges ved udtag (UC6), indgå i lageroversigten og bestillingslisten (UC7) og modtages på lager (UC9). |
