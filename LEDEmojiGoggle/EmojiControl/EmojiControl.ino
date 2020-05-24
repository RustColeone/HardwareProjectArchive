/*
 ESP8266 Blink by Simon Peter
 Blink the blue LED on the ESP-01 module
 This example code is in the public domain
 
 The blue LED on the ESP-01 module is connected to GPIO1 
 (which is also the TXD pin; so we cannot use Serial.print() at the same time)
 
 Note that this sketch uses LED_BUILTIN to find the pin with the internal LED
*/
#define ck 0
#define da 4
#define cl 5
#define cs 16
#define high 0
#define low 1
byte circle = B10101001;
void setup() {
  pinMode(ck, OUTPUT);  
  pinMode(da, OUTPUT); 
  pinMode(cl, OUTPUT); 
  pinMode(cs, OUTPUT); // Initialize the LED_BUILTIN pin as an output
  digitalWrite(ck, high);
  digitalWrite(da, high);
  digitalWrite(cl, high);
  digitalWrite(cs, high);
}

// the loop function runs over and over again forever
void loop() {
//digitalWrite(low,cl);
//digitalWrite(high,cl);
//Tx5byte(0,0,0,0,0);
  digitalWrite(ck, high);
  digitalWrite(da, high);
  digitalWrite(cl, high);
  digitalWrite(cs, high);  
  delay(2000);
  digitalWrite(ck, low);
  digitalWrite(da, low);
  digitalWrite(cl, low);
  digitalWrite(cs, low);  
  delay(2000);
}
void Tx5byte(byte ICData1,byte ICData2,byte ICData3,byte ICData4,byte ICData5)
{
Txbyte(ICData1);  
Txbyte(ICData2);  
Txbyte(ICData3);  
Txbyte(ICData4);  
Txbyte(ICData5);  
}



void Txbyte(byte ICdata)
{
  byte cycle;
 
  for(cycle =0; cycle<8; cycle++)
  {if(ICdata & B10000000) 
   digitalWrite(low,da);
   else
   digitalWrite(high,da);
  digitalWrite(low, ck);
  digitalWrite(high, ck);
  ICdata=ICdata<<1;
  }
}
