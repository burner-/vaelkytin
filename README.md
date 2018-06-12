# vaelkytin
Sceptron Flasher aka. CS:GO Game State Integration to Art-Net translator

Created for Vectorama 2018, work-in-progress.

This tool takes player health information and flashed status from CS:GO Game State Integration and translates it to pixel strips for use with VDO Sceptron 10 (1000mm) and their accompanying P3-050 controller.

**NOTE:** P3-050 cannot translate pixel data from Art-Net to Sceptrons, you must use the DVI input by placing the bar graphics to a second monitor.

Libraries used:

https://github.com/MikeCodesDotNet/ArtNet.Net

https://github.com/rakijah/CSGSI
