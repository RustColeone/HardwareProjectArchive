#include <ESP8266WiFi.h>
#include "MqttEpaper.h"


// Update these with values suitable for your network.
/*
const char* ssid ="ATT3jl8Tns";
const char* password = "6mrk8iyf26vn";
const char* mqtt_server = "m13.cloudmqtt.com";
const char* INTOPIC = "inTopic";
const char* OUTTOPIC = "outTopic";
uint16_t mqtt_port = 18462;
*/

void EPsetup();
void partialupdate(char *textout);

void clientsubscribe(char *INTOPIC);
int clientloop();
char *GetRxData();
char *GetInComTopic();
void mqttloop(char* INTopic,char* OUTTopic,char *msg,bool pub);
IPAddress getwifiip();
bool getwificonnect();
bool setup_wifi(char *ssid,char *password);
void mqttsetup(char* mqtt_server,char* userid,char* userpass,char* ClientID,short mqtt_port);
bool CheckMqttConnnect();

void movechar(char * source)
{
for(byte c=0;c<30;c++)
   source[c]=source[c+3];
}


byte WiFiConnected=0;
byte MqttConnected=0;




  char pass[35];
  char ssid[35];  
  char Mpass[35];
  char Mssid[35];
  char Mbroker[35];
  char MClient[35];
  char Mport[35];  

  char MINTopic[35];
  char MOUTTopic[35];

  char MOUTcontent[35];


void setup() {
Serial.begin(38400);
pinMode(LED_BUILTIN, OUTPUT); 
digitalWrite(LED_BUILTIN, HIGH);
EPsetup();
}
  
String convertToString(char* a, int size) 
{ 
    int i; 
    String s = ""; 
    for (i = 0; i < size; i++) { 
        s = s + a[i]; 
    } 
    return s; 
} 


  
void loop() {
  String Sinst; 
  char inst[35]; 

  

  if(WiFiConnected && MqttConnected)
    {clientloop();
    mqttloop(MINTopic,MOUTTopic,MOUTcontent,false);
    }
  if(Serial.available()>0)
  {
    //Serial1.setTimeout(1000);
    Sinst = Serial.readString();   
    byte Length= Sinst.length();    
    byte Status;
    if(Length>3)
    {Sinst.toCharArray(inst,Length);  
    //Serial.println(Sinst);            
      if(inst[0]=='X' && inst[2]=='X')
      {
        Status=inst[1];
        switch(Status)
        {case '4':
        Sinst.toCharArray(Mpass,Length);
#ifdef  EP27        
        Serial.println("YaY");
#else        
        Serial.println("YAY");
#endif
        movechar(Mpass);
        Serial.println(Mpass);                       
        break;       
        case '5':
        Sinst.toCharArray(Mbroker,Length);
        Serial.println("YbY");
        movechar(Mbroker);
        Serial.println(Mbroker);               
        break;        
        case '6':
        Sinst.toCharArray(Mport,Length);
        Serial.println("YcY");
        movechar(Mport);
        Serial.println(Mport);                     
        break;              
        case '7':
        Sinst.toCharArray(Mssid,Length);
        Serial.println("YdY");          
        movechar(Mssid);        
        Serial.println(Mssid);      
        break;       
        case '8':
        Sinst.toCharArray(MClient,Length);
        Serial.println("YeY");
        movechar(MClient);
        Serial.println(MClient);                        
        break;       
        case '9':  
        if(WiFiConnected)
          {mqttsetup(Mbroker,Mssid,Mpass,MClient,convertToString(Mport,5).toInt()); //18462); //
          //mqttsetup(Mbroker,"dredrqkn","C8uapIdgxl3y","clientID",18462);
          if(CheckMqttConnnect())           
            {Serial.println("YfY   ");        
            Serial.println(convertToString(Mport,5)); 
            MqttConnected=1;           
            }
            else  
            {Serial.println("YgY   ");                             
            Serial.println(convertToString(Mport,5)); 
            }
          }
        else
            {Serial.println("YgY   ");        
            Serial.println("WiFi not connected");           
            }  
        break;  
        
        ///////////////////////////////////////////
        case 'g':
        Sinst.toCharArray(ssid,Length);
        Serial.println("Y7Y");
        Serial.println(ssid);
        movechar(ssid); 
        break;        
        case 'h':
        Sinst.toCharArray(pass,Length);      
        movechar(pass);                             
        if(setup_wifi(ssid,pass))           
          {Serial.println("Y8Y   ");
          Serial.println(getwifiip());          
          WiFiConnected=1;                           
          }
        else
          {Serial.println("Y9Y   ");            
          Serial.println("Unable to connected");             
          WiFiConnected=0;
          }      
        break;          
        //////////////////////////////
        case 'e':  //com port test                            
        Serial.println("Y1Y   ");
        Serial.println("Serial port connected");                       
        break;                              
        //////////////////////////////
        case 'T':  //com port test        
        Sinst.toCharArray(MOUTcontent,Length);                            
        movechar(MOUTcontent); 
        mqttloop(MINTopic,MOUTTopic,MOUTcontent,true);
        Serial.println("Y2Y   ");
        Serial.println("Data TX");                       
        break;                            
        //////////////INCOMMING data////////////////
        case 'W':  //com port test                                                
        Serial.println("Y5Y   ");
        Serial.println(GetRxData());                            
        break;           
        case 'Y':  //com port test                                                
        Serial.println("Y6Y   ");        
        Serial.println(GetInComTopic());                         
        break;                            
        //////////////////////////////
        case 'U':  //com port test  
        Sinst.toCharArray(MINTopic,Length);                                              
        movechar(MINTopic); 
        clientsubscribe(MINTopic);
        Serial.println("Y3Y   ");
        Serial.println(MINTopic);                               
        break;                          
        case 'V':  //com port test  
        Sinst.toCharArray(MOUTTopic,Length);                                         
        movechar(MOUTTopic); 
        Serial.println("Y4Y   ");
        Serial.println(MOUTTopic);                       
        break;                      
        //////////////////////////////
        default:        
        Serial.println(Status);
        break;
        }                 
      Status=100;
      Sinst="";
      Serial.flush();
      }
    }
  }
}

       
