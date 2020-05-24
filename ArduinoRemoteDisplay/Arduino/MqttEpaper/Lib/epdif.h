
#define ESP8266
#ifndef EPDIF_H
#define EPDIF_H

#include <arduino.h>


#define DIN        16
#define CLK        5
// Pin definition
#define CS_PIN     4
#define DC_PIN     0
#define RST_PIN    2
//3V3
//GND
#define BUSY_PIN   14


class EpdIf {
public:
    EpdIf(void);
    ~EpdIf(void);

    static int  IfInit(void);
    static void DigitalWrite(int pin, int value); 
    static int  DigitalRead(int pin);
    static void DelayMs(unsigned int delaytime);
    static void SpiTransfer(unsigned char data);
};

#endif
