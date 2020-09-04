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
#define count           (0xffff - (COUNT_SCALED * (ms)) - 57)

#define Second_LED PORTEbits.RE0
#define Chip_Select PORTBbits.RB0

// Prototype Area  
void Do_Init(void);
void interrupt high_priority T0ISR(void) ;
void SPI_out(unsigned char);

unsigned char array[80];
char i;
int counter;

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
    counter = 0;
    OSCCON=0x70;                // Initialize the ports
    ADCON1=0x0F;                // Configure all pins to digital
    TRISE=0x00;                 // Configure PORT E to be all outputs
    TRISB=0x00;                 // Configure PORT B as outputs
    TRISC=0x00;
        
    T0CON=0x08;                 // Timer0 off, increment on positive 
                                // edge, 1:1 prescaler
  
    //TMR0H = count & 0x00ff;
    //TMR0L = count >> 8;
    TMR0H = 0xFA;
    TMR0L = 0x4C;
    
    for(i=0;i<80;i++)
    {
        if(i<40)
        {
            array[i]=(int)(2.55/40*i*51);
        }
        else
        {
            array[i]=(int)(2.55/40*(80-i)*51);
        }
    }
    
    SSPSTAT=0x40;       // SMP:
                        // Input data sampled at middle of data
                        // output
                        // CKE:
                        // Transmit occurs on transition from active
    SSPCON1=0x20;       // SSPEN:

    
    INTCONbits.TMR0IE=1;        // Set interrupt enable
    INTCONbits.TMR0IF=0;        // Clear interrupt flag
    INTCONbits.GIE=1;           // Set the Global Interrupt Enable 
    T0CONbits.TMR0ON=1;         // Turn on Timer0
}

void interrupt high_priority T0ISR() 
{
    INTCONbits.TMR0IF=0;        // Clear the interrupt flag
    //TMR0H = count & 0x00ff;                 // Reload Timer High and 
    //TMR0L = count >> 8;                 // Timer Low
    TMR0H = 0xFC;
    TMR0L = 0x3A;
    
    SPI_out(array[counter]);
    counter++;
    if(counter==80)
    {
        counter = 0;
    }
    Second_LED = ~Second_LED;   // flip logic state of
                                // Second_LED
}

void SPI_out(unsigned char SPI_data) 
{
    char First_byte, Second_byte;
    First_byte = (SPI_data & 0xf0) >> 4;    // take the upper nibble of data and >> 4 
                                            //times
    First_byte = 0x30 | First_byte;         // set the upper nibble with 0x30
    Second_byte = (SPI_data & 0x0f) <<4;    // take the lower nibble of data and << 4 times
    
    Chip_Select = 0;                        // set the chip select of the D/A chip to be low
    
    SSPBUF = First_byte;                    // output the first byte to the SPI bus
    while (SSPSTATbits.BF == 0);            // wait for status done
    for (i=0;i<1;i++);                      // small delay
    
    SSPBUF = Second_byte;                   // output the second byte to the SPI bus
    while (SSPSTATbits.BF == 0);            // wait for status done
    for (i=0;i<1;i++);                      // small delay
    
    Chip_Select = 1;                        // raise chip select high
}

