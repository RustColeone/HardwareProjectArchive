#include "MqttEpaper.h"
#ifdef EP27
#include "Lib\epd2in7b.h"
#include "Lib\imagedata.h"
#include "Lib\epdpaint.h"



#define COLORED     1
#define UNCOLORED   0

Epd epd;

extern byte Rxmsg[5808];
void EPsetup() {
  // put your setup code here, to run once:  
  if (epd.Init() != 0) {
    Serial.print("e-Paper init failed");
    return; 
  }
    /* This clears the SRAM of the e-paper display */
  
//  epd.ClearFrame();  
///  epd.DisplayFrame(IMAGE_BLACK); 
//  epd.DisplayFrame(Rxmsg); 
}


void EPsetup2() {
  unsigned char image[2048];  
  // put your setup code here, to run once:  
  if (epd.Init() != 0) {
    Serial.print("e-Paper init failed");
    return;   
  }
}
 
void EPsetup1() {
  // put your setup code here, to run once:  
  if (epd.Init() != 0) {
    Serial.print("e-Paper init failed");
    return; 
  }
    /* This clears the SRAM of the e-paper display */
  epd.ClearFrame();

  /**
   * inch e-Ink 264x176 e-Paper Display
  */
    
  unsigned char image[2048];  
  Paint paint(image, 176, 48);    //width should be the multiple of 8 
  paint.Clear(COLORED); 
  epd.TransmitPartialBlack(paint.GetImage(), 0, 0, paint.GetWidth(), paint.GetHeight());
  epd.DisplayFrame();
  Serial.print("step 0\r\n");
  while(!Serial.available());
  Serial.read();
  //Paint paint(image, 176, 24);    //width should be the multiple of 8 
  paint.Clear(UNCOLORED);
  paint.DrawStringAt(0, 0, "e-Paper Demo", &Font16, COLORED);
  epd.TransmitPartialBlack(paint.GetImage(), 16, 32, paint.GetWidth(), paint.GetHeight());
  epd.DisplayFrame();
  Serial.print("step 1\r\n");
  while(!Serial.available());
  Serial.read();
  paint.Clear(COLORED);
  paint.DrawStringAt(2, 2, "Hello world!", &Font20, UNCOLORED);
  epd.TransmitPartialRed(paint.GetImage(), 0, 64, paint.GetWidth(), paint.GetHeight());
  epd.DisplayFrame();
  Serial.print("step 2\r\n");
  while(! Serial.available());
  Serial.read();
  paint.SetWidth(64);
  paint.SetHeight(64);

  paint.Clear(UNCOLORED);
  paint.DrawRectangle(0, 0, 40, 50, COLORED);
  paint.DrawLine(0, 0, 40, 50, COLORED);
  paint.DrawLine(40, 0, 0, 50, COLORED);
  epd.TransmitPartialBlack(paint.GetImage(), 10, 130, paint.GetWidth(), paint.GetHeight());
    epd.DisplayFrame();
  Serial.print("step 3\r\n");
  while(! Serial.available());
  Serial.read();
  paint.Clear(UNCOLORED);
  paint.DrawCircle(32, 32, 30, COLORED);
  epd.TransmitPartialBlack(paint.GetImage(), 90, 120, paint.GetWidth(), paint.GetHeight());
    epd.DisplayFrame();
  Serial.print("step 4\r\n");
  while(! Serial.available());
  Serial.read();
  paint.Clear(UNCOLORED);
  paint.DrawFilledRectangle(0, 0, 40, 50, COLORED);
  epd.TransmitPartialRed(paint.GetImage(), 10, 200, paint.GetWidth(), paint.GetHeight());
  epd.DisplayFrame();
  Serial.print("step 5\r\n");
  while(! Serial.available());
  Serial.read();
  paint.Clear(UNCOLORED);
  paint.DrawFilledCircle(32, 32, 30, COLORED);
  epd.TransmitPartialRed(paint.GetImage(), 90, 190, paint.GetWidth(), paint.GetHeight());

  /* This displays the data from the SRAM in e-Paper module */
  epd.DisplayFrame();
  Serial.print("step 6\r\n");
  while(! Serial.available());
  Serial.read();
  /* This displays an image */
  epd.DisplayFrame(IMAGE_BLACK, IMAGE_RED);
  Serial.print("step 7\r\n");
  while(! Serial.available());
  Serial.read();
  /* Deep sleep */
  epd.Sleep();
  Serial.print("step 8\r\n");
  while(! Serial.available());
  Serial.read();
   
}

void showpicture()
{if (epd.Init() != 0) {
    Serial.print("e-Paper init failed");     
    }
 else   
 {epd.ClearFrame(); 
 epd.DisplayFrame(Rxmsg);  
 } //epd.DisplayFrame(IMAGE_BLACK);  
}



void lineOut(char *text1,char *text2)
{epd.ClearFrame();
  unsigned char image[2048];  
  Paint paint(image, 176, 48);    //width should be the multiple of 8 
  paint.Clear(COLORED);
  paint.DrawStringAt(2, 2,text1, &Font16, UNCOLORED);
  epd.TransmitPartialBlack(paint.GetImage(), 0, 64, paint.GetWidth(), paint.GetHeight());
  paint.DrawStringAt(2, 18,text2, &Font16, UNCOLORED);
  epd.TransmitPartialBlack(paint.GetImage(), 10, 64, paint.GetWidth(), paint.GetHeight());
  epd.DisplayFrame();
}
#endif
