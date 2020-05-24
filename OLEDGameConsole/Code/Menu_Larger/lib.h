#pragma once

#include <Arduino.h>
#include <U8g2lib.h>

//Define board used here, note that some custom board definition can override this settings

#ifdef ARDUINO_AVR_MICRO
  #define PRO_MICRO
#endif
#ifdef ARDUINO_AVR_LILYPAD_USB
  #define PRO_MICRO
#endif
#ifdef ARDUINO_SAMD_ZERO
  #define SPARKFUN_SAMD_21
#endif

//Define the custom board version used here

//#define BOARD_74HC138_TO_DIRECT_WIRE
//#define BOARD_74HC138
//#define MAX7000
#define DIRECTWIRE

#ifdef U8X8_HAVE_HW_SPI
#include <SPI.h>
#endif
#ifdef U8X8_HAVE_HW_I2C
#include <Wire.h>
#endif

#ifdef SPARKFUN_SAMD_21
#define DP_CLK 13
#define DP_DAT 11
#define DP_CS 10
#define DP_DC 9
#define DP_RST 8
#endif

#ifdef PRO_MICRO
#define DP_CLK 15
#define DP_DAT 16
#define DP_CS 10
#define DP_DC 9
#define DP_RST 8
#endif

#ifdef MAX7000
#define DP_CLK 15
#define DP_DAT 16
#define DP_CS 13
#define DP_DC 9
#define DP_RST 8
#endif

#ifdef DIRECTWIRE
#define DP_CLK 7
#define DP_DAT 6
#define DP_CS 4
#define DP_DC 5
#define DP_RST 3
#endif

U8G2_PCD8544_84X48_1_4W_SW_SPI u8g2(U8G2_R0, /* clock=*/ DP_CLK, /* data=*/ DP_DAT, /* cs=*/ DP_CS, /* dc=*/ DP_DC, /* reset=*/ DP_RST);
//U8G2_SSD1306_128X64_NONAME_1_HW_I2C u8g2(U8G2_R0, /* reset=*/ U8X8_PIN_NONE);

#ifdef BOARD_74HC138

void ControlPinsSetup(){
    pinMode(4,OUTPUT); 
    pinMode(5,OUTPUT); 
    pinMode(6,OUTPUT); 
    pinMode(7,INPUT);
}

bool keyDetection(int KeyNumber, int ReadPin){//0 Up, 1 Left, 2 Right, 3 Down, 4 Y, 5 X, 6 B, 7 A
  bool state = false;
  digitalWrite(4,bitRead(KeyNumber,0));
  digitalWrite(5,bitRead(KeyNumber,1));
  digitalWrite(6,bitRead(KeyNumber,2));
  for(int i = 0; digitalRead(7) == 0; i ++){
    if(i >= 1){
      state = true;
      break;
    }
  }
  return state;
}

bool keyDetectionSingle(int KeyNumber, int ReadPin){//0 Up, 1 Left, 2 Right, 3 Down, 4 Y, 5 X, 6 B, 7 A
  bool state = false;
  for(int i = 0; keyDetection(KeyNumber,ReadPin) == true; i ++){
    if(i >= 1){
      state = true;
    }
  }
  return state;
}
#endif

#ifdef BOARD_74HC138_TO_DIRECT_WIRE

void ControlPinsSetup(){
    pinMode(4, INPUT_PULLUP);
    pinMode(5, INPUT_PULLUP);
    pinMode(6, INPUT_PULLUP);
    pinMode(7, INPUT_PULLUP);
    pinMode(A0, INPUT_PULLUP);
    pinMode(A1, INPUT_PULLUP);
    pinMode(A2, INPUT_PULLUP);
    pinMode(A3, INPUT_PULLUP);
}

bool keyDetection(int KeyNumber, int FOR_CONSISTENCY){//0 Up, 1 Left, 2 Right, 3 Down, 4 Y, 5 X, 6 B, 7 A
  short int LoopUp[] = {4,5,7,6,A3,A2,A1,A0};
  return !digitalRead(LoopUp[KeyNumber]);
}

bool keyDetectionSingle(int KeyNumber, int ReadPin){//0 Up, 1 Left, 2 Right, 3 Down, 4 Y, 5 X, 6 B, 7 A
  bool state = false;
  for(int i = 0; keyDetection(KeyNumber,ReadPin) == true; i ++){
    if(i >= 1){
      state = true;
    }
  }
  return state;
}
#endif

#ifdef MAX7000
  void ControlPinsSetup(){
    pinMode(4, OUTPUT);//Enable
    digitalWrite(4,HIGH);
    pinMode(5, OUTPUT);//6
    pinMode(6, OUTPUT);//5
    pinMode(7, OUTPUT);//4
    pinMode(A1, INPUT);
    pinMode(A2, INPUT);
}

bool keyDetection(int KeyNumber, int FOR_CONSISTENCY){//0 Up, 1 Left, 2 Right, 3 Down, 4 Y, 5 X, 6 B, 7 A, 8 Start, 9 Select
  bool state = false;
  short int ReadSide = A2;
  if(KeyNumber > 3 && KeyNumber < 8){
    KeyNumber = KeyNumber - 4;
    ReadSide = A1;
  }else if(KeyNumber == 8){
    KeyNumber = 5;
    ReadSide = A2;
  }else if(KeyNumber == 9){
    KeyNumber = 5;
    ReadSide = A1;
  }
  digitalWrite(5,bitRead(KeyNumber,0));
  digitalWrite(6,bitRead(KeyNumber,1));
  digitalWrite(7,bitRead(KeyNumber,2));
  for(int i = 0; digitalRead(ReadSide) == 1; i ++){
    if(i >= 1){
      state = true;
      break;
    }
  }
  return state;
}

bool keyDetectionSingle(int KeyNumber, int ReadPin){//0 Up, 1 Left, 2 Right, 3 Down, 4 Y, 5 X, 6 B, 7 A
  bool state = false;
  for(int i = 0; keyDetection(KeyNumber,ReadPin) == true; i ++){
    if(i >= 1){
      state = true;
    }
  }
  return state;
}
#endif

#ifdef DIRECTWIRE

void ControlPinsSetup(){
    pinMode(8, INPUT);
    pinMode(9, INPUT);
    pinMode(10, INPUT);
    pinMode(11, INPUT);
    pinMode(12, INPUT);
    pinMode(13, INPUT);
    pinMode(A0, INPUT);
    pinMode(A1, INPUT);
}

bool keyDetection(int KeyNumber, int FOR_CONSISTENCY){//0 Up, 1 Left, 2 Right, 3 Down, 4 Y, 5 X, 6 B, 7 A
  short int LoopUp[] = {8,9,10,11,12,13,A0,A1};
  return digitalRead(LoopUp[KeyNumber]);
}

bool keyDetectionSingle(int KeyNumber, int ReadPin){//0 Up, 1 Left, 2 Right, 3 Down, 4 Y, 5 X, 6 B, 7 A
  bool state = false;
  for(int i = 0; keyDetection(KeyNumber,ReadPin) == true; i ++){
    if(i >= 1){
      state = true;
    }
  }
  return state;
}
#endif
