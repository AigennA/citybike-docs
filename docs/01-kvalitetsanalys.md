# Kvalitetsanalys CityBike

## 1. Observationer och egenskaper

### K1
Egenskap: Performance efficiency
Delegenskap: Time behaviour
Motivering: Kartan är för långsam under belastning (9 sekunder för 300 användare).

### K2
Egenskap: Functional suitability
Delegenskap: Functional correctness
Motivering: Kunden debiteras fel belopp eftersom samma resa dras två gånger; dålig täckning (Reliability) utlöser felet men skadan är ett felaktigt resultat.

### K3
Egenskap: Reliability
Delegenskap: Fault tolerance
Motivering: Resan ska fortsätta och inga positioner får gå förlorade trots att styrenheten tappar uppkopplingen.

### K4
Egenskap: Interaction capability
Delegenskap: Learnability
Motivering: Nya kunder kan inte själva lista ut hur resan avslutas, vilket syns i 40 samtal per vecka till kundtjänst.

### K5
Egenskap: Security
Delegenskap: Confidentiality
Motivering: En kund kommer åt en annan kunds resedata bara genom att ändra id i adressen, alltså saknas behörighetskontroll.

### K6
Egenskap: Maintainability
Delegenskap: Modularity
Motivering: Prisberäkningen är inte separerad från bokningsflödet, så en ändring i den ena riskerar att förstöra den andra.

### K7
Egenskap: Flexibility
Delegenskap: Adaptability
Motivering: Adminpanelen (S2) anpassar sig inte till teknikernas surfplattor; små knappar påverkar även Interaction capability men grundproblemet är att den inte fungerar på en annan enhetstyp.

### K8
Egenskap: Safety
Delegenskap: Fail safe
Motivering: Ett överhettat batteri kan orsaka brand, så systemet måste gå till ett säkert läge genom att bryta laddningen och varna (Hazard warning).

### K9
Egenskap: Compatibility
Delegenskap: Interoperability
Motivering: API:et (S3) måste kunna utbyta data med två styrenhetsmodeller som använder olika dataformat.

### K10
Egenskap: Flexibility
Delegenskap: Adaptability
Motivering: Systemet kan inte anpassas till en ny stad utan kodändringar på tolv ställen; hårdkodade värden påverkar även Maintainability.

## 2. De fyra viktigaste egenskaperna för CityBike

1. Security: om behörighetskontrollen brister kan kunder se andras resor och positioner, se K5 samt R4 och R11 i avsnitt 6, vilket ger skadeståndsrisk och sanktionsavgift enligt GDPR.
2. Safety: om laddningen inte bryts vid överhettning kan ett batteri börja brinna och skada människor eller egendom, se K8 och avsnitt 7 där CityBike räknas som tillverkare av styrenheten och därmed bär produktansvaret.
3. Reliability: om resor och positioner går förlorade vid avbrott vet CityBike inte var cyklarna finns och kan inte debitera rätt, se K3 och avsnitt 4 där styrenheten ska skicka position var 15:e sekund.
4. Functional suitability: om betalningen räknas fel debiteras kunder dubbelt, vilket ger återbetalningar, klagomål och förlorat förtroende, se K2, prisreglerna P1 till P3 i avsnitt 2 och betalningssteget i avsnitt 4.

## 3. Mätbara krav

### Krav 1: Security
Krav: 100 procent av API-anrop där en inloggad kund begär en resa som tillhör en annan kund nekas med HTTP-status 403, testat med minst 1000 anrop.
Mått: andel nekade anrop till andra kunders resor
Gränsvärde: 100 procent nekade (0 lyckade anrop)
Mätmetod: automatiserat behörighetstest med två testkonton där resans id byts ut i adressen
Hänvisning: K5, R4 i avsnitt 6

### Krav 2: Safety
Krav: När batteritemperaturen överstiger 60 °C bryts laddningen inom 5 sekunder och larm når teknikerna inom 60 sekunder.
Mått: tid från uppmätt temperatur över 60 °C till bruten laddning och till mottaget larm
Gränsvärde: högst 5 sekunder till bruten laddning, högst 60 sekunder till larm
Mätmetod: labbtest med simulerad temperaturgivare, 50 upprepningar
Hänvisning: K8, avsnitt 7

### Krav 3: Reliability
Krav: Vid avbrott i mobiltäckning på upp till 30 minuter går 0 procent av positionerna förlorade och alla skickas inom 2 minuter efter återanslutning.
Mått: andel mottagna positioner och tid från återanslutning till sista mottagna position
Gränsvärde: 100 procent mottagna, högst 2 minuter
Mätmetod: test i testmiljö där styrenhetens nätverk kopplas bort i 30 minuter under en pågående resa
Hänvisning: K3, avsnitt 4 och 7

### Krav 4: Functional suitability
Krav: När samma betalningsbegäran skickas 2 till 5 gånger för en resa debiteras kunden exakt 1 gång i 100 procent av 1000 testfall.
Mått: antal debiteringar per resa
Gränsvärde: 1 debitering per resa (0 dubbeldebiteringar)
Mätmetod: automatiserat integrationstest som skickar dubblerade betalningsbegäranden med fördröjning och kontrollerar betalningsloggen
Hänvisning: K2, avsnitt 2 och 4

### Uträkning: tillåten nedtid
Tillgänglighet 99,7 procent betyder att 0,3 procent av tiden får vara nedtid.
30 dagar = 30 × 24 = 720 timmar = 720 × 60 = 43 200 minuter.
Tillåten nedtid = 43 200 × 0,003 = 129,6 minuter, alltså ungefär 2 timmar och 10 minuter.

## 4. Skillnad mot ett annat par

<Skriv 2–3 meningar efter jämförelsen med ett annat par.>
