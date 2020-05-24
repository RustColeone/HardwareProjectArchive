#include "MqttEpaper.h"
#ifdef EP213
#include "Lib\epd2in13.h"
#include "Lib\epdpaint.h"
#include "Lib\imagedata.h"


//hardware refer to epdif.h//
#define COLORED     0
#define UNCOLORED   1
//#define MYHID
//#ifdef MYHID
//#include "HID-Project.h"
//#endif
/**
  * Due to RAM not enough in Arduino UNO, a frame buffer is not allowed.
  * In this case, a smaller image buffer is allocated and you have to 
  * update a partial display several times.
  * 1 byte = 8 pixels, therefore you have to set 8*N pixels at a time.
  */
extern byte Rxmsg[4000];  
unsigned char image[1024];
Paint paint(image, 0, 0);
Epd epd;
unsigned long time_start_ms;
unsigned long time_now_s;

#define bufsize 64
uint8_t rawhidData[bufsize];
uint8_t megabuff[bufsize];

void partialupdate(char *textout);
void movetoarray();
void DataFromEEPROM();
void DataToEEPROM();



void EPsetup() {  
  if (epd.Init(lut_full_update) != 0) {
      //Serial.print("e-Paper init failed");
      return;
  }

  epd.ClearFrameMemory(0xFF);   // bit set = white, bit reset = black
  
  paint.SetRotate(ROTATE_0);
  paint.SetWidth(128);    // width should be the multiple of 8 
  paint.SetHeight(24);

  /* For simplicity, the arguments are explicit numerical coordinates */
  paint.Clear(COLORED);
  paint.DrawStringAt(30, 4, "Hello world!", &Font12, UNCOLORED);
  epd.SetFrameMemory(paint.GetImage(), 0, 10, paint.GetWidth(), paint.GetHeight());
/*
  paint.Clear(UNCOLORED);
  paint.DrawStringAt(30, 4, "e-Paper Demo", &Font12, COLORED);
  epd.SetFrameMemory(paint.GetImage(), 0, 30, paint.GetWidth(), paint.GetHeight());

  paint.SetWidth(64);
  paint.SetHeight(64);
  
  paint.Clear(UNCOLORED);
  paint.DrawRectangle(0, 0, 40, 50, COLORED);
  paint.DrawLine(0, 0, 40, 50, COLORED);
  paint.DrawLine(40, 0, 0, 50, COLORED);
  epd.SetFrameMemory(paint.GetImage(), 16, 60, paint.GetWidth(), paint.GetHeight());

  paint.Clear(UNCOLORED);
  paint.DrawCircle(32, 32, 30, COLORED);
  epd.SetFrameMemory(paint.GetImage(), 72, 60, paint.GetWidth(), paint.GetHeight());

  paint.Clear(UNCOLORED);
  paint.DrawFilledRectangle(0, 0, 40, 50, COLORED);
  epd.SetFrameMemory(paint.GetImage(), 16, 130, paint.GetWidth(), paint.GetHeight());

  paint.Clear(UNCOLORED);
  paint.DrawFilledCircle(32, 32, 30, COLORED);
  epd.SetFrameMemory(paint.GetImage(), 72, 130, paint.GetWidth(), paint.GetHeight());
  */
  epd.DisplayFrame();

  delay(2000);

  if (epd.Init(lut_partial_update) != 0) {
      //Serial.print("e-Paper init failed");
      return;
      }
  epd.SetFrameMemory(IMAGE_DATA);  
  epd.DisplayFrame(); 
 // epd.SetFrameMemory(IMAGE_DATA);
 // epd.DisplayFrame();
  time_start_ms = millis();
}


void cleanAll(void){
  epd.ClearFrameMemory(0xFF);   // bit set = white, bit reset = black  
  paint.SetRotate(ROTATE_0);
  paint.SetWidth(128);    // width should be the multiple of 8 
  paint.SetHeight(24);
  paint.Clear(UNCOLORED);
  epd.DisplayFrame();
  epd.ClearFrameMemory(0xFF);   // bit set = white, bit reset = black  
  paint.SetRotate(ROTATE_0);
  paint.SetWidth(128);    // width should be the multiple of 8 
  paint.SetHeight(24);
  paint.Clear(UNCOLORED);
  epd.DisplayFrame();
}

void showpicture()
{
  if (epd.Init(lut_full_update) != 0) {
    Serial.print("e-Paper init failed");     
    }
 else  {
    epd.SetFrameMemory(Rxmsg);  
    epd.DisplayFrame();
    epd.SetFrameMemory(Rxmsg);  
    epd.DisplayFrame(); 
    }
}


void partialupdate(char *textout) {
  // put your main code here, to run repeatedly:
  //time_now_s = (millis() - time_start_ms) / 1000;
  //char time_string[] = {'0', '0', ':', '0', '0', '\0'};
  //time_string[0] = time_now_s / 60 / 10 + '0';
  //time_string[1] = time_now_s / 60 % 10 + '0';
  //time_string[3] = time_now_s % 60 / 10 + '0';
  //time_string[4] = time_now_s % 60 % 10 + '0';

  paint.SetWidth(32);
  paint.SetHeight(196);
  paint.SetRotate(ROTATE_90);

  paint.Clear(UNCOLORED);
  paint.DrawStringAt(0, 4, textout, &Font24, COLORED);
  epd.SetFrameMemory(paint.GetImage(), 80, 72, paint.GetWidth(), paint.GetHeight());
  epd.DisplayFrame();

  delay(500);
}

#endif
