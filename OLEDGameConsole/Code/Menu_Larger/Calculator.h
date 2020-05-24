#include "lib.h"

short int CalSelectX = 0;
short int CalSelectY = 0;
short int PressCount = 0;
float CalNumber[] = {0,0,0};
short int InputIndex = 0;
short int DecimalPlaces = 0;
bool DecimalFlag = false;
bool ErrorFlag = false;
char CalInputLookUp[5][4] = {{'7','8','9','+'},{'4','5','6','-'},{'1','2','3','*',},{'0','.','/','='},{'A','A','C','C'}};
char Action;

int NumberInput(int Number, short int x, short int y){
    if(Number > 1000){
        return Number;
    }
    int TempInt = 0;
    TempInt = CalInputLookUp[y][x] - 48;
    if(Number != 0){
        Number = Number * 10 + TempInt;
    }
    else{
      Number = TempInt;
    }
    return Number;
}
float DecimalInput(float Number, short int x, short int y){
    DecimalPlaces += 1;
    float Tempfloat = 0;
    Tempfloat = CalInputLookUp[y][x] - 48;
    
    for(int i = 0; i < DecimalPlaces; i ++){
        Tempfloat = Tempfloat/10.0;
    }
    Number += Tempfloat;
    
    return Number;
}

void setupCal(){
  ControlPinsSetup();
    u8g2.begin();
    u8g2.setFont(u8g2_font_6x10_tf);
}

void loopCal(void) {
    for(;;){
      if(keyDetectionSingle(5, 7)){
          return;
      }
      if(keyDetectionSingle(0, 7) && CalSelectY > 0){
          CalSelectY--;
      }
      if(keyDetectionSingle(3, 7) && CalSelectY < 4){
          CalSelectY++;
      }
      if(keyDetectionSingle(1, 7) && CalSelectX > 0){
          CalSelectX--;
      }
      if(keyDetectionSingle(2, 7) && CalSelectX < 3){
          CalSelectX++;
      }
      if(keyDetectionSingle(7, 7)){
          //PressCount += 1;
          char key = CalInputLookUp[CalSelectY][CalSelectX];
          if((CalSelectX <= 2 && CalSelectY <= 2) || key == '0'){
              if(!DecimalFlag){
                  CalNumber[InputIndex] = NumberInput(CalNumber[InputIndex], CalSelectX, CalSelectY);
              }else{
                  CalNumber[InputIndex] = DecimalInput(CalNumber[InputIndex], CalSelectX, CalSelectY);
              }
          }
          else if(key == '.'){
              DecimalFlag = true;
          }
          else if(key == 'A'){
              Action = 0;
              CalNumber[0] = CalNumber[2];
              CalNumber[1] = 0;
              InputIndex = 0;
              DecimalPlaces = 0;
              DecimalFlag = false;
          }
          else if(key == 'C'){
              Action = 0;
              CalNumber[0] = 0;
              CalNumber[1] = 0;
              CalNumber[2] = 0;
              InputIndex = 0;
              DecimalPlaces = 0;
              DecimalFlag = false;
              ErrorFlag = false;
            }
          else if(key != '='){
              Action = key;
              DecimalPlaces = 0;
              DecimalFlag = false;
              InputIndex = 1;
          }
          else{
              double temp = 0;
              switch(Action){
                  case '+':
                      temp = CalNumber[0] + CalNumber[1];
                      CalNumber[2] = temp;
                      break;
                  case '-':
                      temp = CalNumber[0] - CalNumber[1];
                      CalNumber[2] = temp;
                      break;
                  case '*':
                      temp = CalNumber[0] * CalNumber[1];
                      CalNumber[2] = temp;
                      break;
                  case '/':
                      temp = CalNumber[0] / CalNumber[1];
                      CalNumber[2] = temp;
                      break;
              }
              if(temp >= 30000){
                  ErrorFlag = true;
              }else{
                  ErrorFlag = false;
              }
          }
      }
    
        
      u8g2.setFont(u8g2_font_micro_tr );
      u8g2.setFontDirection(0);
      u8g2.setFontRefHeightAll();
      
        u8g2.firstPage();
        //u8g2.clearDisplay();
        do{
            u8g2.drawStr(0,6,"Calculator");
            u8g2.setCursor(54, 6);
            u8g2.print(CalInputLookUp[CalSelectY][CalSelectX]);
            u8g2.setCursor(62, 6);
            u8g2.print(InputIndex);
            u8g2.setCursor(70, 6);
            u8g2.print(CalSelectX);
            u8g2.setCursor(78, 6);
            u8g2.print(CalSelectY);
            
            u8g2.setCursor(5, 18);
            u8g2.print(CalNumber[0]);
            if(Action!= 0){
                u8g2.setCursor(5, 27);
                u8g2.print(Action); 
            }
            u8g2.setCursor(5, 36);
            u8g2.print(CalNumber[1]);
            u8g2.drawHLine(2, 37, 30);
            u8g2.setCursor(5, 45);
            if(!ErrorFlag){
                u8g2.print(CalNumber[2]); 
            }else{
                u8g2.print("ERROR");
            }
    
            if(CalSelectY < 4){
                u8g2.drawFrame(8*CalSelectX + 48,8*(CalSelectY) + 8,7,7); 
            }
            else{
                u8g2.drawStr(8*CalSelectX + 48,8*(CalSelectY) + 8,"-"); 
                u8g2.drawFrame(16*(CalSelectX/2) + 48,8*(CalSelectY) + 8,15,7); 
            }
            u8g2.drawFrame(42,6,42,42);
            u8g2.drawStr(50,14,"7 8 9 +");
            u8g2.drawHLine(42, 15, 42);
            u8g2.drawStr(50,22,"4 5 6 -");
            u8g2.drawHLine(42, 23, 42);
            u8g2.drawStr(50,30,"1 2 3 *");
            u8g2.drawHLine(42, 31, 42);
            u8g2.drawStr(50,38,"0 . / =");
            u8g2.drawHLine(42, 39, 42);
            u8g2.drawStr(50,46,"ANS CLR");
        }while (u8g2.nextPage());
    }
}


void StartCalculator(){
  setupCal();
  loopCal();
  u8g2.setFont(u8g2_font_6x10_tf);
}
