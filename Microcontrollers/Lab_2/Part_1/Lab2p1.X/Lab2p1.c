//Created by Mark Tippit and Colin Keenan for ECE 3301L Spring 2019 at Cal Poly Pomona
//Lab 2

#include <p18f4321.h>
#include <stdio.h>
#include <math.h>
#include <usart.h>

#pragma config OSC = INTIO2
#pragma config WDT = OFF
#pragma config LVP = OFF
#pragma config BOR = OFF

// Prototype Area
void Do_Init(void);
void LED_SWITCH(void);

void main(void)
{
    Do_Init();
    while (1)
    {
        LED_SWITCH();
    }
}

void Do_Init(void)
{
    //OSCCON = 0x60;
    
    TRISA = 0x00;                       //Initialize with the Port A bits 0-3 set as output while leaving the other bits unchanged
    TRISB = 0xFF;                       //Initialize with the Port B bits 0-3 set as input while leaving the other bits unchanged
    TRISC = 0x00;                       //Initialize with the Port C bits 0-3 set as output while leaving the other bits unchanged
    TRISD = 0x00;                       //Initialize with the Port D bits 0-3 set as output while leaving the other bits unchanged
    
    //ADCON0 = 0x01;                    // select channel AN0, and turn on the ADC subsystem
    ADCON1 = 0x0F;                      // set all pins as digital signal, VDD-VSS as reference voltage and right justify the result
    //ADCON2 = 0xA9;                    // Set the bit conversion time (TAD) and acquisition time
    
    PORTD = 0;
}

void LED_SWITCH(void)
{
    char in;                            // Use variable in as char
 
        in = PORTB;                     // read data from PORTB and save it into ?in?
        in &= 0x0F;                     // Mask out the unused upper four bits
        PORTA = in;                     // Output the data to PORTA
    
}