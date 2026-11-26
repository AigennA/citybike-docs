# Gränsfall i PriceCalculator
 
## Värden jag testar
- 0 sekunder: 10 kr
- 59 sekunder: 12,50 kr
- 1 sekund: 12,50 kr
- 60 sekunder: 12,50 kr
- 61 sekunder: 15 kr
- 120 sekunder: 15 kr
- 121 sekunder: 17,50 kr
- 5760 sekunder: 250 kr
- 5761 sekunder: 250 kr

- int.MaxValue (2 147 483 647 sekunder) : 250 kr

- -1 sekund: fel (ArgumentOutOfRangeExceptio)

 - int.MaxValue är det största heltalet. Koden lade till 59 och talet blev för stort. Priset blev -89 478 472,50 kr ii stället för 250 kr. en resa på 68 år hade alltså gett kunnden 89 miljoner kronor-Man kund cykla till Saturnus och tillbaka och ändå få betalt.
 
## Varför de är intressanta

- 0:  är den minsta tillåtna tiden. Då ska man bara betala upplåsningsavgiften (P1)
- 1 är den första sekunden då har en minut börjat.
-  59 och 60 ligger i slutet av första minuten, priset är samma inte ökat än.
- 61 är början på en ny minut då priset ska öka.
- 120 och 121 är samma gräns vid andra minuten.
- 5760 är gränsen där priset når taket 250 kr.
- 5761 är precis över taket. Prisset ska stanna på 250 kr.
- Och -1 en negativ tid. Den ska ge ett fel.
