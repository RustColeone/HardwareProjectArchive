# ArduinoRemoteDisplay
Remotely update an display with the help of MQTT

## Requirements
- Arduino ide
- Visual Studio

### Tested on Device
- ESP8266

### Supported Displays
- Waveshare E-Paper 2.13 inch
- Waveshare E-Paper 2.7  inch

## Usage
1. Please edit the definition(The program runs on conditional define), commenting all other displays leaving the desired display only. The files are located [Here for Arduino side](Arduino/MqttEpaper/MqttEpaper.h) and [Here for PC side](VisualStudio/EpaperMqttDisplay/Form1bak.cs)
2. Build and Run the Visual Studio Solution, under the tab ESP8266, Fill in the information for MQTT and WiFi that you want your Arduino to connect to.
3. Fill in the information for MQTT under the tab PCLinkMQTT
4. Click Link-all to connect.
5. Edit a picture, resize it to reasonable size (about 250 * 150) and save as bitmap file
6. Under the Picture tab, open the bitmap file and click Send to Epaper
