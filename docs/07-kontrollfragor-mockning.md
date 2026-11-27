Kontrollfrågor: mockning med Moq

Vilket test blev rött?

Testet Book_BatteryExactlyAtLimit_UnlocksBike (B5) blev rött. Med <= räknas 10 procent som för lite batteri, så tjänsten svarar BatteryTooLow i stället för Unlocked. 
De andra testerna har 82, 64 och 9 procent och ligger inte på gränsen, så de märkte inte ändringen.

2- Vilka rader styr vad ett beroende svarar, och vilken rad kontrollerar att något anropades?

Raderna med Setup styr svaren:
_bikes.Setup(b => b.GetById(1)).Returns(new Bike(1, "Available", 82));
 och
_unlockClient.Setup(u => u.Unlock(1)).Returns(true);.
Raden _unlockClient.Verify(u => u.Unlock(1), Times.Once());

 kontrollerar att Unlock anropades en gång.

 3- Skulle du mocka PriceCalculator?


Nej. PriceCalculator räknar bara ut priset. Den använder ingen databas, så det finns inget att byta ut. Om jag mockar den testar jag inte priset på riktigt.