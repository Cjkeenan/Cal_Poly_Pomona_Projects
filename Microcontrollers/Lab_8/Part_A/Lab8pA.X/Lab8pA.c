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
#define COUNT_SCALED    COUNT_PER_MS/32 // 

#define PULSE           PORTCbits.RC2   //PWM pulse output

void delay_500ms(void);
void Do_Init(void);

void main(void)
{
    Do_Init();          // initialize the I/O (make sure to setup the direction
                        // of the I/O especially the signal ?PULSE?
    OSCCON = 0x70;      // set the CPU speed to be at 8Mhz
    PULSE = 0;          // set the PULSE to be 0 first
    while (1)
    {
        PULSE = ~PULSE; // Flip the logic state of PULSE
        delay_500ms();  // delay 500 msec.
    }
}

void delay_500ms(void)
{
    int count;
    count = (0xffff - (COUNT_SCALED*500)) - 430;
    //count = count * 500;                //500 ms
    
        T0CON = 0x04;                   // Timer 0, 16-bit mode, pre scaler 1:32
        TMR0L = count & 0x00ff;         // set the lower byte of TMR
        TMR0H = count >> 8;             // set the upper byte of TMR
        INTCONbits.TMR0IF = 0;          // clear the Timer 0 flag
        T0CONbits.TMR0ON = 1;           // Turn on the Timer 0
        while (INTCONbits.TMR0IF == 0); // wait for the Timer Flag to be 1 for done
        T0CONbits.TMR0ON = 0;           // turn off the Timer 0
}

void Do_Init()
{
    TRISC=0x00;     // Set PORTC as output
}