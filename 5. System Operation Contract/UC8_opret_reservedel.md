**# CO8 – opretReservedel**

| Felt | Hvad skriver vi |
|---|---|
| Nummer | CO8 |
| Operation | opretReservedel(navn: String, leverandør: String, minimumsantal: Integer) |
| Krydsreferencer | UC8 Opret Reservedele |
| Forudsætninger | Programmet er startet. Navn er udfyldt og unikt, så der ikke findes en Reservedel med samme navn. Leverandør er udfyldt. Minimumsantal er et helt tal på 0 eller derover. |
| Slutbetingelser | En Reservedel-instans r blev oprettet.<br>r.navn blev sat til navn.<br>r.leverandør blev sat til leverandør.<br>r.minimumsantal blev sat til minimumsantal.<br>r.lagerbeholdning blev sat til 0.<br>r blev tilføjet til systemets reservedele, så den kan vælges ved udtag, indgå i lageroversigten og bestillingslisten og modtages på lager. |
