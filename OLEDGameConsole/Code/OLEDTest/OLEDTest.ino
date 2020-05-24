#include "U8glib.h"

//U8GLIB_SSD1306_128X64 u8g(U8G_I2C_OPT_NONE|U8G_I2C_OPT_DEV_0);	// I2C / TWI 
U8GLIB_SSD1306_128X64 u8g(U8G_I2C_OPT_DEV_0|U8G_I2C_OPT_NO_ACK|U8G_I2C_OPT_FAST);	// Fast I2C / TWI 
//U8GLIB_SSD1306_128X64 u8g(U8G_I2C_OPT_NO_ACK);	// Display which does not send AC


int readkeypad(void);

void draw(byte hpos,byte vpos,char *text) {
  // graphic commands to redraw the complete screen should be placed here  
  u8g.setFont(u8g_font_unifont);
  //u8g.setFont(u8g_font_osb21);
  u8g.drawStr( hpos, vpos, text);  //"Hello World!");
}

void setup(void) {
  ////////////
  pinMode(4,OUTPUT); 
  pinMode(5,OUTPUT); 
  pinMode(6,OUTPUT); 
  pinMode(18,OUTPUT); 
  pinMode(7,INPUT);  
  //////////// 
  // flip screen, if required
  // u8g.setRot180();
  
  // set SPI backup if required
  //u8g.setHardwareBackup(u8g_backup_avr_spi);

  // assign default color value
  if ( u8g.getMode() == U8G_MODE_R3G3B2 ) {
    u8g.setColorIndex(255);     // white
  }
  else if ( u8g.getMode() == U8G_MODE_GRAY2BIT ) {
    u8g.setColorIndex(3);         // max intensity
  }
  else if ( u8g.getMode() == U8G_MODE_BW ) {
    u8g.setColorIndex(1);         // pixel on
  }
  else if ( u8g.getMode() == U8G_MODE_HICOLOR ) {
    u8g.setHiColorByRGB(255,255,255);
  }  
 // pinMode(8, OUTPUT);
}
byte vp=20;

void loop(void) {
  // picture loop  
  
  byte Char=readkeypad();
  Serial.println(Char,DEC);
  u8g.firstPage();  
  do {
    if(Char==0)
      draw(0,vp,"This is 0 key");   
      if(Char==1)
      draw(0,vp,"This is 1 key");   
      if(Char==2)
      draw(0,vp,"This is 2 key");   
      if(Char==3)
      draw(0,vp,"This is 3 key");   
      if(Char==4)
      draw(0,vp,"This is 4 key");   
      if(Char==5)
      draw(0,vp,"This is 5 key");   
      if(Char==6)
      draw(0,vp,"This is 6 key");   
      if(Char==7)
      draw(0,vp,"This is 7 key");   
    //draw(0,32,"The second line");   
  }while( u8g.nextPage());
   vp++;
    if(vp>62) vp=20;
  // rebuild the picture after some delay
  delay(500);
}

//while (!Serial.available()); 
int readkeypad(void){
byte Contact[]={0,0,0,0,0,0,0,0,0,0,0};
int Coop;
//while(digitalRead(7)==LOW);

for(Coop=0;Coop<8;Coop++)
  {
  if(Coop==1)
  {digitalWrite(4,HIGH);
  digitalWrite(5,LOW);
  digitalWrite(6,LOW);
  }
  if(Coop==2)
  {digitalWrite(4,LOW);
  digitalWrite(5,HIGH);
  digitalWrite(6,LOW);
  }
  if(Coop==3)
  {digitalWrite(4,HIGH);
  digitalWrite(5,HIGH);
  digitalWrite(6,LOW);
  }
  if(Coop==7)
  {digitalWrite(4,HIGH);
  digitalWrite(5,HIGH);
  digitalWrite(6,HIGH); 
  }
  if(Coop==4)
  {digitalWrite(4,LOW);
  digitalWrite(5,LOW);
  digitalWrite(6,HIGH);
  }
  if(Coop==5)
  {digitalWrite(4,HIGH);
  digitalWrite(5,LOW);
  digitalWrite(6,HIGH);
  }  
  if(Coop==6)
  {digitalWrite(4,LOW);
  digitalWrite(5,HIGH);
  digitalWrite(6,HIGH);
  }
  if(Coop==0)
  {digitalWrite(4,LOW);
  digitalWrite(5,LOW);
  digitalWrite(6,LOW);
  //Serial.println("this is step 7");  
  //while (!Serial.available());      
  }
  digitalWrite(18,LOW);
  //if(digitalRead(7)==LOW)
      {for(byte i=0;i<20;i++)  
        {delay(1);  
        if(digitalRead(7)==LOW)
            {Contact[Coop]++;
            if(Contact[Coop]>7)
            break;            
            Serial.println("this next step 7");             
            Serial.println(Coop,DEC);  
            }
        else
            Contact[Coop]==0;
       // Serial.println(Coop,DEC);         
        }
      }
      if(Contact[Coop]>3)   
      break; // second for loop         
  } 
digitalWrite(18,HIGH);
//Serial.println(Coop,DEC); 
if(Contact[Coop]>3)
    return Coop;
else
    return -1;    
}
