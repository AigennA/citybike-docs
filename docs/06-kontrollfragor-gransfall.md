1. Varför är 60 och 61 sekunder bättre testvärden än 30 och 90?

Vid 60 och 61 sekunder börjar en ny minnut, och där ändras priset. Fel brukar finnas just där. 30 och 90ligger mitt i en minut , så priset ändras inte runt. Testet för 61 sekunder hittade felet seconds / 60.

2. Vad skiljer ett gränsvärde från ett vanligt värde i en ekvivalensklass?

I en ekvivalensklass ska alla värden ge sammma resultat, t.ex 1 till 60 sekunder. Vanligt värde ligger mitt i gruppen , som 30. Ett gränsvärde ligge ri kanten där gruppen slutar och nästa börjar, som 60 och 61.

3. Hur kan ett test som är grönt ändå inte skydda mot fel? Ge ett exempel från PriceCalculator.

Ett grönt test vizar bara att koden fungerar  för de värden jag har testat. Efter övning 1 var alla fem tester gröna, men när jag testade int.MaxValue blev priset -89 ...... kr i stället för 250 kr.