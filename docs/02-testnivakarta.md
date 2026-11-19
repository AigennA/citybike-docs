# Testnivåkarta CityBike

## T1
Nivå: enhet
Motivering: Fråga fyra avgör eftersom PriceCalculator testas som ren beräkning enligt P1 och P2 utan databas, nätverk eller användare.

## T2
Nivå: enhet
Motivering: Fråga fyra avgör eftersom taket i P3 kontrolleras direkt i PriceCalculator utan några andra delar.

## T3
Nivå: integration
Motivering: Fråga tre avgör eftersom API:et och en riktig SQL Server-databas samverkar, men resten av kedjan (kundapp och styrenhet) är inte med.

## T4
Nivå: enhet
Motivering: Fråga fyra avgör eftersom upplåsningsklienten är ersatt av en testdubbel, så bara logiken i BookingService körs.

## T5
Nivå: system
Motivering: Fråga två avgör eftersom kedjan går genom kundappen (S1), API:et (S3) och en simulerad styrenhet.

## T6
Nivå: acceptans
Motivering: Fråga ett avgör eftersom det är projektledaren som godkänner resultatet efter att pilotkunder använt appen.

## T7
Nivå: integration
Motivering: Fråga tre avgör eftersom repositoryt testas mot en riktig SQL Server-databas.

## T8
Nivå: system
Motivering: Fråga två avgör eftersom hela kartflödet belastas med 500 användare i en driftlik testmiljö.

## T9
Nivå: enhet
Motivering: Fråga fyra avgör eftersom datumet skickas in som parameter, så testet beror inte på systemklockan eller någon annan del.

## T10
Nivå: acceptans
Motivering: Fråga ett avgör eftersom ekonomiansvarig som beställare godkänner kvittots innehåll och pris.

## T11
Nivå: integration
Motivering: Fråga tre avgör eftersom en riktig HTTP-stack med autentisering körs i processen, men övriga systemdelar startas inte.

## T12
Nivå: system
Motivering: Fråga två avgör eftersom hela resflödet körs genom alla systemdelar och betaltjänstens testläge i testmiljön.

## T13
Nivå: enhet
Motivering: Fråga fyra avgör eftersom EmailValidator bara kontrollerar en textsträng utan beroenden.

## T14
Nivå: acceptans
Motivering: Fråga ett avgör eftersom kundtjänst som användare går igenom användarfallen och skriver under ett protokoll.

## T15
Nivå: integration
Motivering: Fråga tre avgör eftersom StationService och databasen samverkar för att räkna fram antalet lediga cyklar.

## T16
Nivå: system
Motivering: Fråga två avgör eftersom firmware, verkliga styrenheter (S5) i en testrigg och backend körs tillsammans och upplåsning och positionsrapport kontrolleras hela vägen.

## Sammanställning
Enhet: 5
Integration: 4
System: 4
Acceptans: 3

Fördelningen liknar pyramiden eftersom enhetstesterna är flest och acceptanstesterna färst, men den är mycket plattare än pyramiden; i ett riktigt projekt bör enhetstesterna vara många fler än testerna på de övre nivåerna.

## Eget testfall
Krav: Krav 3: Reliability i docs/01-kvalitetsanalys.md
Givet: en pågående resa där styrenheten skickar position var 15:e sekund enligt avsnitt 4
När: styrenhetens mobilnät kopplas bort i 30 minuter och sedan kopplas in igen
Då: 100 procent av de 120 positionerna från avbrottet finns i tabellen GpsPoints inom 2 minuter efter återanslutningen
Nivå: system
Testtyp: icke-funktionellt, svartlåda

## Kontrollfrågor
1. Felet hittas billigast på enhetsnivå eftersom det är ett beräkningsfel i PriceCalculator där 61 sekunder ska räknas som två påbörjade minuter enligt P2, och T1 ligger närmast att fånga det eftersom det testar priset för en given restid; ett nytt enhetstest för 61 sekunder bör läggas till.
2. T16 var svårast att placera eftersom jag tvekade mellan integration och system: det är bara styrenheter och firmware i en testrigg, men eftersom upplåsning och positionsrapport går hela vägen till backend valde jag system.
