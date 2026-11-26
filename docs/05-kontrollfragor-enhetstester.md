1. Varför skriver du förväntat värde från kravet i stället för från vad koden returnerar?
Testet ska kontrollera att koden gör det som kraavet säger.
Kravet P2 säger 15 kr, så 15 kr är rätt svar.. Om jag tar bara värdet från koden, då testar jag bara att koden gör det den redan gör.

2. Varför ska ett test bara ha en Act-del, och vad händer med felsökningen om det har två?

Ett test får testa en sak. Jag kan veta vad som är fel om testet blir örtt. Om det finns 2 Act delar vet jag inte vilket anrop som orsakar felet. Då blir jag tvungen att felsöka mer och testnamnet beskriver inte vad testet görr.

3. Vad hade hänt om du hade skrivit 12,50 som förväntat värde i steg 3?

Jag såg själv i testet för 61 sekunder visade Expected 15 och Actual 12,50. Om jag hade skrivit 12,50 hade jag aldrig hittar felet seconds / 60.