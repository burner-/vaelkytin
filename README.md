# vaelkytin
Sceptron Flasher aka. CS:GO Game State Integration to Art-Net translator

![Vectorama 2018 Asus ROG CS:GO](http://gallery.vectorama.info/?t=Big&f=Vectorama+2018%2F9.6.2018+Lauantai%2FAtte+Haapalahti%2Fvectorama_la-33.jpg)

First real-world use at Vectorama 2018.

This tool takes player health information and flashed status from CS:GO Game State Integration and translates it to pixel strips for use with VDO Sceptron 10 (1000mm) and their accompanying P3-050 controller.

**NOTE:** P3-050 cannot translate pixel data from Art-Net to Sceptrons, you must use the DVI input by placing the bar graphics to a second monitor.

Libraries used:

https://github.com/MikeCodesDotNet/ArtNet.Net

https://github.com/rakijah/CSGSI
