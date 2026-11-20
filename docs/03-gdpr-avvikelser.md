# GDPR-avvikelser i CityBike

## Personuppgiftsinventering

- Users: Name, Personnummer, Email, Phone. Direkt identifierande. De andra kolumnerna hör också till samma person.
- PaymentMethods: UserId, CardLast4, ExpiryMonth, ExpiryYear. Kortet hör till en kund via UserId.
- Bikes: Inga personuppgifter. Tabellen handlar bara om cykeln och inte om någon kund.
- Stations: Inga personuppgifter. Tabellen visar bara var stationerna finns.
- Trips: UserId. Knyter resan till en person, och då syns också när och var personen cyklade.
- GpsPoints: TripId, Latitude, Longitude. Via resan går det att se exakt var en person har varit.

## A1
Rutin: R1
Vad: Personnummer krävs vid registrering trots att syftet kan nås på annat sätt.
Artikel: Art. 5.1 c, dataskyddslagen 3 kap. 10 §
Risk: Hög
Åtgärd: Ta bort kravet. Kontrollera ålder på annat sätt eller ta bara emot födelsedatum.
Testfall: Registrering utan personnummer ska fungera (systemtest).

## A2
Rutin: R2
Vad: Positioner och resor sparas för alltid, fast de inte behövs efter att resan är betald.
Artikel: Art. 5.1 e
Risk: Hög
Åtgärd: Radera positionerna efter 30 dagar.
Testfall: Positioner som är äldre än 30 dagar ska vara borta efter att raderingen har körts (integration).

## A3
Rutin: R3
Vad: När en kund stänger kontot ändras bara status till Inactive, så alla uppgifter finns kvar.
Artikel: Art. 17
Risk: Medel
Åtgärd: Radera eller anonymisera kundens uppgifter när kontot stängs.
Testfall: När en testkund stänger kontot ska namn, personnummer och e-post vara borta i databasen (integration).

## A4
Rutin: R4
Vad: Kundtjänst delar ett konto och lösenordet ligger i chatten, så man vet inte vem som har gjort vad.
Artikel: Art. 32
Risk: Hög
Åtgärd: Alla i kundtjänst får ett eget konto.
Testfall: Två personer loggar in med egna konton och loggen visar vem som loggade in (integration).

## A5
Rutin: R4
Vad: Alla i kundtjänst kan se personnummer fast de inte behöver det i sitt jobb.
Artikel: Art. 5.1 c, art. 32
Risk: Hög
Åtgärd: Dölj personnummer för kundtjänst.
Testfall: En användare med rollen kundtjänst ska inte se personnummer när den hämtar en kund (integration).

## A6
Rutin: R5
Vad: Hela anropet sparas i loggen i 12 månader, så personnummer och lösenord hamnar där.
Artikel: Art. 5.1 c, art. 32
Risk: Hög
Åtgärd: Ta bort personnummer och lösenord innan något loggas, och spara loggar kortare tid.
Testfall: Efter en registrering i testmiljön ska personnumret och lösenordet inte finnas i loggfilen (integration).

## A7
Rutin: R6
Vad: Alla kunder får nyhetsbrev utan att de har blivit tillfrågade.
Artikel: Art. 6, art. 7
Risk: Låg
Åtgärd: Lägg till en ruta för nyhetsbrev som inte är ikryssad från början.
Testfall: En kund som inte kryssar i rutan ska inte få något nyhetsbrev (system).

## A8
Rutin: R7
Vad: Analysverktyget får kundens e-post och alla resor, men det finns inget avtal med leverantören.
Artikel: Art. 28
Risk: Hög
Åtgärd: Skriv ett avtal med leverantören och skicka inte e-postadressen.
Testfall: Inga e-postadresser ska skickas till analysverktyget i testmiljön (integration).

## A9
Rutin: R7
Vad: Uppgifterna sparas i USA, utanför EU, utan att det finns något skydd för det.
Artikel: Art. 44
Risk: Hög
Åtgärd: Välj ett analysverktyg som sparar data i EU.
Testfall: Ledningen kontrollerar i avtalet att data bara sparas i EU och godkänner det (acceptans).

## A10
Rutin: R8
Vad: Appen säger inget om hur personuppgifterna används, så kunden vet inte vad som sparas.
Artikel: Art. 13
Risk: Medel
Åtgärd: Skriv en integritetspolicy och visa den när kunden registrerar sig.
Testfall: Registreringssidan ska visa en länk till integritetspolicyn (system).

## A11
Rutin: R8
Vad: Det finns ingen lista över vilka personuppgifter som används och ingen konsekvensbedömning, fast CityBike följer var kunderna cyklar.
Artikel: Art. 30, art. 35
Risk: Medel
Åtgärd: Gör en lista över behandlingarna och en konsekvensbedömning.
Testfall: Ledningen går igenom listan och godkänner att alla tabeller och externa tjänster finns med (acceptans).

## A12
Rutin: R11
Vad: Lösenorden sparas utan salt, så de är lätta att knäcka om databasen läcker.
Artikel: Art. 32
Risk: Hög
Åtgärd: Spara lösenorden med en säkrare metod med salt.
Testfall: Två konton med samma lösenord ska få olika hash (enhet).

## Rutiner i ordning

Rutin: R9
Bedömning: i ordning. 90 dagar är en begränsad tid, och säkerhetskopior behövs för att kunna få tillbaka data om något går sönder.

## Incident R10
Tidpunkt för kännedom: tisdag 3 mars 2026 14:20
Frist för anmälan (datum och klockslag): fredag 6 mars 2026 14:20
Anmäla till IMY: Ja
Informera berörda kunder: Nej
Motivering: Namn, e-post och telefonnummer för 2 100 kunder skickades till ett externt företag. Vi vet inte vad de gör med filen, och uppgifterna kan användas för bluffmejl, så därför ska det anmälas. Men filen hade inga personnummer, lösenord eller kortuppgifter, så risken är inte hög och kunderna behöver inte informeras.
Åtgärder för att förhindra upprepning: 1. En annan person ska godkänna innan en fil med kunduppgifter skickas. 2. Servicebrev ska skickas direkt från e-posttjänsten och inte som en fil.

## Kontrollfrågor

1. Personnummer får användas om det behövs för att säkert veta vem personen är. Det gäller inte CityBike, för åldern kan kollas med födelsedatum och kunderna betalar med kort.
2. Uppgifterna finns kvar, och kunden har rätt att få dem raderade enligt art. 17.
3. Integration, för testet går mot API:et och kollar att behörigheten fungerar när flera delar jobbar tillsammans.
