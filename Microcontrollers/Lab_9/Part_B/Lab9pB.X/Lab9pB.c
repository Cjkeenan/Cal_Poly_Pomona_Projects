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
void Init_UART(void);
void putch(char);

unsigned char array[50];
char i;

void main() 
{
    Do_Init(); // Initialization 
    while (1)
    { 
        // Do nothing,
        // wait for interrupt
    } 
}

void Do_Init()                  // Initialize the ports
{
    OSCCON=0x70;                // Initialize the ports
    ADCON1=0x0F;                // Configure all pins to digital
    TRISE=0x00;                 // Configure PORT C to be all outputs
        
    T0CON=0x08;                 // Timer0 off, increment on positive 
                                // edge, 1:1 prescaler
  
    TMR0H = count & 0x00ff;
    TMR0L = count >> 8;
    
    INTCONbits.TMR0IE=1;        // Set interrupt enable
    INTCONbits.TMR0IF=0;        // Clear interrupt flag
    INTCONbits.GIE=1;           // Set the Global Interrupt Enable 
    T0CONbits.TMR0ON=1;         // Turn on Timer0
}

void interrupt high_priority T0ISR() 
{
    INTCONbits.TMR0IF=0;        // Clear the interrupt flag
    TMR0H = count & 0x00ff;     // Reload Timer High and 
    TMR0L = count >> 8;         // Timer Low
    Second_LED = ~Second_LED;   // flip logic state of
                                // Second_LED
}