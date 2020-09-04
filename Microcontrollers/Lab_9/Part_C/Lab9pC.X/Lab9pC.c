#include <stdio.h>
#include <stdlib.h>
#include <xc.h>
#include <math.h>
#include <p18f4620.h>

#pragma config OSC      =   INTIO67
#pragma config BOREN    =   OFF
#pragma config WDT      =   OFF
#pragma config LVP      =   OFF

#define _XTAL_FREQ      8000000         // Set operation for 8 Mhz
#define TMR_CLOCK       _XTAL_FREQ/4    // Timer Clock 2 Mhz
#define COUNT_PER_MS    TMR_CLOCK/1000  // Count per ms = 2000
#define COUNT_SCALED    COUNT_PER_MS    //
#define ms              1
#define count           (0xffff - (COUNT_SCALED * (ms)) - 56)

#define Second_LED PORTEbits.RE0

// Prototype Area  
void Do_Init(void);
void interrupt high_priority T0ISR(void) ;

unsigned char array[50];
char i;

void main()
{

    OSCCON=0x070;       // Program oscillator to be at 8Mhz
    TRISC=0x00;         // Setup port C with output
    SSPSTAT=0x40;       // SMP:
                        // Input data sampled at middle of data
                        // output
                        // CKE:
                        // Transmit occurs on transition from active
    SSPCON1=0x20;       // SSPEN:
    while (1)
    {
        SSPBUF = 0x55; // data 0x55 to be sent out
        while (SSPSTATbits.BF == 0); // wait for status done
        SSPBUF = 0xaa; // data 0xAA to be sent out
        while (SSPSTATbits.BF == 0); // wait for status done
        for (i=0;i<10;i++); // small delay
    }
}