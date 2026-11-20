# Regelverkschecklista för CityBike

## GDPR

### G1 Radering av kundens uppgifter
Gäller: Ja
Skäl: Art. 17, kunden har rätt att få uppgifterna raderade.
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Testrapport som visar att kundens uppgifter är borta efter radering.

### G2 Radera gamla positioner
Gäller: Ja
Skäl: Art. 5.1 e, positionerna sparas för alltid enligt R2.
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Körningslogg som visar att gamla positioner raderas.

### G3 Egna konton i adminpanelen
Gäller: Ja
Skäl: Art. 32, kundtjänst delar ett konto och alla ser personnummer enligt R4.
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Testrapport som visar att kundtjänst inte ser personnummer.

### G4 Fråga om nyhetsbrev
Gäller: Ja
Skäl: Art. 6 och art. 7, kunderna får nyhetsbrev utan att ha sagt ja enligt R6.
Ansvarig: Frontend-utvecklare
Verifieras med: Nivå system, testtyp funktionell
Bevis: Testrapport med skärmbild som visar att rutan inte är ikryssad från början.

### G5 Avtal med analysverktyget
Gäller: Ja
Skäl: Art. 28 och art. 44, uppgifter skickas till USA utan avtal enligt R7.
Ansvarig: Ledning
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Påskrivet avtal och en logg som visar att inga e-postadresser skickas.

### G6 Inga personuppgifter i loggen
Gäller: Ja
Skäl: Art. 5.1 c, personnummer och lösenord hamnar i loggen enligt R5.
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Utdrag ur loggen som visar att personnummer och lösenord inte finns där.

## CE och produktkrav

### C1 Maskindirektivet och maskinförordningen
Gäller: Osäkert
Skäl: Cykeln har högst 250 W och 25 km/h, så den räknas som elcykel och reglerna gäller cykeln. Men CityBike säljer inte cyklarna, så det är oklart om CityBike blir ansvarig när de sätter in sin styrenhet. En jurist kan avgöra det.
Ansvarig: Ledning
Verifieras med: Nivå acceptans, testtyp icke-funktionell
Bevis: Intyg från cykeltillverkaren och svar från juristen.

### C2 EN 15194 för elcyklar
Gäller: Ja
Skäl: Standarden gäller elcyklar med högst 250 W och 25 km/h, och det stämmer med avsnitt 7.
Ansvarig: Ledning
Verifieras med: Nivå acceptans, testtyp icke-funktionell
Bevis: Testrapport från cykeltillverkaren som CityBike sparar.

### C3 Radioutrustningsdirektivet
Gäller: Ja
Skäl: Styrenheten har ett mobilmodem och CityBike räknas som tillverkare enligt avsnitt 7.
Ansvarig: Firmwareutvecklare
Verifieras med: Nivå system, testtyp icke-funktionell
Bevis: Testrapport från ett provningslaboratorium.

### C4 EN 50604-1 och batteriförordningen
Gäller: Osäkert
Skäl: Batteriet är inte gjort av CityBike, men styrenheten ska stoppa laddningen vid 60 °C. Det är oklart hur mycket ansvar CityBike har. En jurist och ett provningslaboratorium kan avgöra det.
Ansvarig: Ledning
Verifieras med: Nivå system, testtyp icke-funktionell
Bevis: Testrapport från batteritillverkaren och CityBikes eget test av temperaturskyddet.

### C5 Elektromagnetisk kompatibilitet
Gäller: Ja
Skäl: Styrenheten är elektronik och får inte störa annan utrustning eller bli störd själv.
Ansvarig: Firmwareutvecklare
Verifieras med: Nivå system, testtyp icke-funktionell
Bevis: EMC-testrapport från ett provningslaboratorium.

## Cyber Resilience Act

### CRA1 Lista över komponenter (SBOM)
Gäller: Ja
Skäl: CityBike äger firmwaren och måste veta vilka delar den består av, så att det inte finns kända säkerhetshål vid leverans. Det gäller från 11 december 2027.
Ansvarig: Firmwareutvecklare
Verifieras med: Nivå integration, testtyp icke-funktionell
Bevis: En SBOM-fil för varje firmwareversion.

### CRA2 Säkerhetsuppdateringar av firmware
Gäller: Ja
Skäl: Firmware uppdateras trådlöst enligt avsnitt 7, och CityBike måste skicka säkerhetsuppdateringar under hela supporttiden.
Ansvarig: Firmwareutvecklare
Verifieras med: Nivå system, testtyp funktionell
Bevis: Testrapport som visar att uppdateringen fungerar i testriggen.

### CRA3 Ta emot rapporter om säkerhetshål
Gäller: Ja
Skäl: CityBike måste kunna ta emot rapporter om säkerhetshål. Plikten att rapportera gäller redan från 11 september 2026, men det finns ingen rutin för det i dag.
Ansvarig: Ledning
Verifieras med: Nivå acceptans, testtyp funktionell
Bevis: En skriven rutin och ett protokoll från en övning.

### CRA4 Säkra lösenord
Gäller: Ja
Skäl: Säkerhet ska byggas in från början, men enligt R11 sparas lösenorden utan salt.
Ansvarig: Backend-utvecklare
Verifieras med: Nivå integration, testtyp funktionell
Bevis: Testrapport som visar att samma lösenord ger olika hash.

## Spårbarhet

### K1 Batteriet får inte överstiga 60 °C vid laddning
Källa: C4
Testfall: Koppla en cykel till laddaren i testriggen. Höj temperaturen i batterisensorn till 65 °C. Mät hur lång tid det tar innan laddningen stoppas och larmet kommer till teknikerna. Gör testet 50 gånger. Godkänt om laddningen stoppas inom 5 sekunder och larmet kommer inom 60 sekunder.
Nivå och testtyp: System, icke-funktionell
Resultat som ska sparas: Firmwareversion, datum, vem som testade, uppmätta tider och om testet blev godkänt.
Teknisk dokumentation: Testrapporten sparas som PDF i den tekniska dokumentationen för styrenheten i minst 10 år.

### K2 Kundens uppgifter raderas
Källa: G1
Testfall: Skapa en testkund med två resor. Skicka en begäran om radering. Kontrollera i databasen att kundens namn, personnummer, e-post och positioner är borta.
Nivå och testtyp: Integration, funktionell
Resultat som ska sparas: Programversion, datum, testkundens Id och om testet blev godkänt.
Teknisk dokumentation: Testrapporten sparas i mappen docs/testrapporter i repot.

## Kontrollfrågor

1. CityBike sätter sitt eget varumärke på styrenheten och säljer den på marknaden, därför räknas de som tillverkare (avsnitt 7).
2. Varje ny firmwareversion måste testas igen, till exempel upplåsning, position och batteriskyddet.
3. Resultat som ska sparas, för där står vilken firmwareversion som testades, när och av vem.
