#include "MqttEpaper.h"
#include <ESP8266WiFi.h>
#include <PubSubClient.h>

#define EP213

WiFiClient espClient;
PubSubClient client(espClient);

void mqttloop(char* INTopic,char* OUTTopic,char *msg,bool pub);
void lineOut(char *text1,char *text2);
void showpicture();

long lastMsg = 0;
#ifdef EP27
byte Rxmsg[5808];
int txsize=88;
String totaltx="95";
#else
byte Rxmsg[4000];
int txsize=80;
String totaltx="79";
#endif
char incomtopic[50];
int buffercount;


void callback(char* topic, byte* payload, unsigned int length) {
int i; 
char c[4];
String b;
  for (i = 0; i < 50; i++)    
        { incomtopic[i]=topic[i];
        if(topic[i]=='\n' || topic[i]=='\r')
            break;
        }      
  if(topic[0]=='f' ||topic[0]=='s' )    
  {if(topic[0]=='f') buffercount=0;
   buffercount=payload[1];
   buffercount=buffercount-30;
   buffercount=buffercount*txsize; //22*4 or 16*5
     {for (i = 0; i < txsize;i++ ) 
          Rxmsg[buffercount+i]=payload[i+8];  //for char    
     //b = (String)length;
     //b.toCharArray(c, 4);
     //lineOut(incomtopic,c);       
     }
  b = (String)payload[1];
  b.toCharArray(c, 4);      
  //client.publish("RXPicture",c);
  if(b==totaltx)   //picture length+30-1      
      showpicture();
  mqttloop("spicture","RXPicture",c,true);
  }  
  else
  {
   if(length>128) length=128;
      {
      for (i = 0; i < length; i++) 
        Rxmsg[i]=(byte)payload[i];  //for char
      }               
       //lineOut(incomtopic,"123");    
  }              
}


bool setup_wifi(char* ssid,char* password) {
  byte c; 
  WiFi.begin(ssid,password);
  for(c=0;c<50;c++)
    {if(WiFi.status() != WL_CONNECTED) 
        delay(500);
    else
        {digitalWrite(LED_BUILTIN, LOW);
          break;        
        }
    }
if(c<=50)
  return true;
else
  return false;  
}

void clientsubscribe(char *INTOPIC)
{
client.subscribe(INTOPIC);
}

IPAddress getwifiip()
{
return  WiFi.localIP();
}    


int clientloop()
{return client.loop();
}

byte *GetRxData()
{
  //String TSinst="testRxdata";
  //TSinst.toCharArray(RRxmsg,TSinst.length());           
  return Rxmsg;
}

char *GetInComTopic()
{
  //String TSinst="testRxTopic ";
  //TSinst.toCharArray(RRxmsg,TSinst.length());           
    return incomtopic;   
}  

 //mqtt message arrived//




//mqtt reconnect//
void reconnect(char* INTOPIC1,char* INTOPIC2,char* INTOPIC3) {
  // Loop until we're reconnected
  while (!client.connected()) {
  String clientId = "dredrqkn";
  clientId += String(random(0xffff), HEX);
     if (client.connect(clientId.c_str(),"dredrqkn","C8uapIdgxl3y")) {     
      //client.publish("outTopic", "hello world");     
      client.subscribe(INTOPIC1);    
      client.subscribe(INTOPIC2);      
      client.subscribe(INTOPIC3);
      } else {      
      delay(1000);
    }
  }
}


 
bool CheckMqttConnnect()
{
return client.connected();  
}

//char *buf = malloc(128);
//sprintf(buf,"%s",String(ip).c_str());
   


void mqttsetup(char* mqtt_server,char* userid,char* userpass,char* ClientID,short mqtt_port) { 
  client.setServer(mqtt_server, mqtt_port);
  client.connect(ClientID,userid,userpass);
  client.setCallback(callback);
}

//mqttfixed time to publish message//
void mqttloop(char* INTopic,char* OUTTopic,char *msg,bool pub ) {
  if (!client.connected()) {
    reconnect(INTopic,"spicture","RXPicture");
  }
  //client.loop();  //mqttfixed time to publish message//
  //long now = millis();
  //if (now - lastMsg > 2000) {
  //  lastMsg = now;
  //  ++value;
  //  snprintf (msg, 50, "hello world #%ld", value);
  //  Serial.print("Publish message: ");
  //  Serial.println(msg);
  if(pub) client.publish(OUTTopic, msg,sizeof(msg));
  //}
}
