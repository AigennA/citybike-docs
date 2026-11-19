# Testnivåkarta CityBike

## T1
Nivå: enhet
Motivering: Fråga fyra, för det är bara en prisberäkning utan databas eller nätverk.

## T2
Nivå: enhet
Motivering: Fråga fyra, för taket i P3 testas direkt i PriceCalculator utan andra delar.

## T3
Nivå: integration
Motivering: Fråga tre, för API:et jobbar med en riktig SQL Server-databas men appen och styrenheten är inte med.

## T4
Nivå: enhet
Motivering: Fråga fyra, för upplåsningsklienten är en testdubbel och bara BookingService testas.

## T5
Nivå: system
Motivering: Fråga två, för testet går genom kundappen, API:et och en simulerad styrenhet.

## T6
Nivå: acceptans
Motivering: Fråga ett, för projektledaren godkänner efter att pilotkunderna testat.

## T7
Nivå: integration
Motivering: Fråga tre, för repositoryt testas mot en riktig databas.

## T8
Nivå: system
Motivering: Fråga två, för hela kartan testas med 500 användare i en driftlik miljö.

## T9
Nivå: enhet
Motivering: Fråga fyra, för datumet skickas in som parameter och inget annat behövs.

## T10
Nivå: acceptans
Motivering: Fråga ett, för ekonomiansvarig är beställare och godkänner kvittot.

## T11
Nivå: integration
Motivering: Fråga tre, för en riktig HTTP-stack körs i processen men inga andra systemdelar startas.

## T12
Nivå: system
Motivering: Fråga två, för hela resan från registrering till betalning körs i testmiljön.

## T13
Nivå: enhet
Motivering: Fråga fyra, för EmailValidator kollar bara en text och behöver inget annat.

## T14
Nivå: acceptans
Motivering: Fråga ett, för kundtjänst är användare och skriver under att det fungerar.

## T15
Nivå: integration
Motivering: Fråga tre, för StationService och databasen jobbar tillsammans.

## T16
Nivå: system
Motivering: Fråga två, för riktiga styrenheter, firmware och backend testas tillsammans hela vägen.

## Sammanställning
Enhet: 5
Integration: 4
System: 4
Acceptans: 3

Det liknar pyramiden lite eftersom enhetstester är flest och acceptanstester minst, men i ett riktigt projekt borde det finnas mycket fler enhetstester.

## Eget testfall
Krav: Krav 3: Reliability i docs/01-kvalitetsanalys.md
Givet: en resa pågår och styrenheten skickar position var 15:e sekund
När: styrenhetens nät stängs av i 30 minuter och sedan slås på igen
Då: alla 120 positioner från avbrottet (100 procent) finns i tabellen GpsPoints inom 2 minuter
Nivå: system
Testtyp: icke-funktionellt, svartlåda

## Kontrollfrågor
1. Felet hittas billigast med ett enhetstest. Det är ett räknefel i PriceCalculator, för 61 sekunder ska räknas som två påbörjade minuter enligt P2. T1 ligger närmast eftersom det testar pris för en viss tid, men man borde lägga till ett test för 61 sekunder.
2. T16 var svårast. Jag tvekade mellan integration och system, för det är bara styrenheter i en testrigg. Jag valde system eftersom upplåsning och position går hela vägen till backend.
