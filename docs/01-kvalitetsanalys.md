# Kvalitetsanalys CityBike

## 1. Observationer och egenskaper

### K1
Egenskap: Performance efficiency
Delegenskap: Time behaviour
Motivering: Kartan är för långsam under belastning (9 sekunder för 300 användare).

### K2
Egenskap: Functional suitability
Delegenskap: Functional correctness
Motivering: Kunden får betala två gånger för samma resa, så resultatet blir fel. Dålig täckning startar felet och det har med Reliability att göra, men det värsta är att beloppet blir fel.

### K3
Egenskap: Reliability
Delegenskap: Fault tolerance
Motivering: Resan måste fortsätta och inga positioner får försvinna fast styrenheten tappar täckningen.

### K4
Egenskap: Interaction capability
Delegenskap: Learnability
Motivering: Nya kunder hittar inte hur man avslutar resan och ringer kundtjänst 40 gånger i veckan.

### K5
Egenskap: Security
Delegenskap: Confidentiality
Motivering: Man kan se en annan kunds resa bara genom att ändra id i adressen, så behörigheten kontrolleras inte.

### K6
Egenskap: Maintainability
Delegenskap: Modularity
Motivering: Prisberäkningen ligger ihop med bokningen, så om man ändrar en sak kan något annat gå sönder.

### K7
Egenskap: Flexibility
Delegenskap: Adaptability
Motivering: Adminpanelen fungerar inte på surfplattorna som teknikerna använder. Små knappar är också Interaction capability, men huvudproblemet är att den inte fungerar på en annan sorts enhet.

### K8
Egenskap: Safety
Delegenskap: Fail safe
Motivering: Ett för varmt batteri kan börja brinna, så laddningen måste stoppas och teknikerna måste få ett larm.

### K9
Egenskap: Compatibility
Delegenskap: Interoperability
Motivering: API:et måste förstå data från två olika styrenheter som skickar olika format.

### K10
Egenskap: Flexibility
Delegenskap: Adaptability
Motivering: Man måste ändra koden på tolv ställen för att lägga till en ny stad. Det påverkar också Maintainability, men det viktigaste är att systemet inte går att anpassa.

## 2. De fyra viktigaste egenskaperna för CityBike

1. Security: om det brister kan kunder se andras resor och var de har varit, se K5 och R4 i avsnitt 6. Det har redan hänt en gång när 2 100 kunders uppgifter skickades till fel adress, se R10. Då kan CityBike få böter enligt GDPR och behöva betala skadestånd.
2. Safety: om laddningen inte stoppas när batteriet blir för varmt kan det börja brinna och någon kan skadas, se K8. Enligt avsnitt 7 är CityBike ansvarig för styrenheten.
3. Reliability: om positioner försvinner vet CityBike inte var cyklarna är och kan inte ta rätt betalt, se K3 och avsnitt 4.
4. Functional suitability: om betalningen blir fel får kunder betala dubbelt och blir missnöjda, se K2 och prisreglerna P1 till P3 i avsnitt 2.

## 3. Mätbara krav

### Krav 1: Security
Krav: 100 procent av anropen där en kund försöker öppna en annan kunds resa ska nekas med HTTP-status 403, testat med 1000 anrop.
Mått: andel nekade anrop
Gränsvärde: 100 procent nekade
Mätmetod: automatiskt test med två testkonton där man byter id i adressen
Hänvisning: K5, R4 i avsnitt 6

### Krav 2: Safety
Krav: När batteriet blir varmare än 60 °C ska laddningen stoppas inom 5 sekunder och larmet nå teknikerna inom 60 sekunder.
Mått: tid till stoppad laddning och tid till larm
Gränsvärde: högst 5 sekunder och högst 60 sekunder
Mätmetod: test i labb där temperaturen simuleras, 50 gånger
Hänvisning: K8, avsnitt 7

### Krav 3: Reliability
Krav: Om styrenheten saknar täckning i upp till 30 minuter ska 100 procent av positionerna komma fram inom 2 minuter efter att täckningen kommer tillbaka.
Mått: andel positioner som kommer fram och tid efter återanslutning
Gränsvärde: 100 procent, högst 2 minuter
Mätmetod: test i testmiljön där styrenhetens nät stängs av i 30 minuter under en resa
Hänvisning: K3, avsnitt 4

### Krav 4: Functional suitability
Krav: Om samma betalning skickas 2 till 5 gånger ska kunden bara debiteras 1 gång, i 100 procent av 1000 testfall.
Mått: antal debiteringar per resa
Gränsvärde: 1 debitering per resa
Mätmetod: automatiskt test som skickar samma betalning flera gånger och kollar betalningsloggen
Hänvisning: K2, avsnitt 2 och 4

### Uträkning: tillåten nedtid
99,7 procent tillgänglighet betyder att 0,3 procent får vara nedtid.
30 dagar = 30 × 24 = 720 timmar = 720 × 60 = 43 200 minuter.
43 200 × 0,003 = 129,6 minuter, alltså ungefär 2 timmar och 10 minuter.

## 4. Skillnad mot ett annat par

Vi har båda Security som nummer 1, men den största skillnaden är att det andra paret har med Performance efficiency och har Safety sist, medan jag har Safety som nummer 2 och inte har med Performance efficiency alls. Skillnaden beror på att de tänkte mer på hur kunderna upplever appen varje dag (K1), medan jag tänkte mer på vad som är farligast, till exempel att ett batteri kan börja brinna (K8, avsnitt 7). Vi placerade också K2 olika, de valde Reliability och jag valde Functional suitability, och därför finns Functional suitability med i min lista men inte i deras.
