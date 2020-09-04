#include <p18f4321.h>
#include <stdio.h>
#include <math.h>
#include <usart.h>

#pragma config OSC = INTIO2
#pragma config WDT = OFF
#pragma config LVP = OFF
#pragma config BOR = OFF

int ADC_Result;
float Volt;

void init_UART()
{
    OpenUSART (USART_TX_INT_OFF & USART_RX_INT_OFF &
    USART_ASYNCH_MODE & USART_EIGHT_BIT & USART_CONT_RX &
    USART_BRGH_HIGH, 25);
    OSCCON = 0x60;
}
void putch (char c)
{
    while (!TRMT);
    TXREG = c;
}
// Prototype Area
void Init_ADC(void);
unsigned int Get_Full_ADC(void);

void Init_ADC(void)
{
    ADCON0=0x01; // select channel AN0, and turn on the ADDC subsystem
    ADCON1=0x0a; // set pins 2,3,4,5 & 7 as analog signal, VDD-VSS as ref voltage
    // and right justify the result
    ADCON2=0xA9; // Set the bit conversion time (TAD) and acquisition time
}
unsigned int Get_Full_ADC(void)
{
    int result;
    ADCON0bits.GO=1; // Start Conversion
    while(ADCON0bits.DONE==1); // Wait for conversion to be completed (DONE=0)
    result = (ADRESH * 0x100) + ADRESL; // Combine result of upper byte and lower byte into
    return result; // return the most significant 8- bits of the result.
}
void main(void)
{
    char k;
    float t;
    init_UART();
    Init_ADC();
    while(1)
        {
        ADCON0=0x01;
        ADC_Result = Get_Full_ADC();
        Volt = ADC_Result / 1024.0 * 5.0;
        printf ("Volt at AN0 is %f\r\n", Volt);
        
        ADCON0=0x05;
        ADC_Result = Get_Full_ADC();
        Volt = ADC_Result / 1024.0 * 5.0;
        printf ("Volt at AN1 is %f\r\n", Volt);
        
        ADCON0=0x09;
        ADC_Result = Get_Full_ADC();
        Volt = ADC_Result / 1024.0 * 5.0;
        printf ("Volt at AN2 is %f\r\n", Volt);
        
        ADCON0=0x0d;
        ADC_Result = Get_Full_ADC();
        Volt = ADC_Result / 1024.0 * 5.0;
        printf ("Volt at AN3 is %f\r\n", Volt);
        
        ADCON0=0x11;
        ADC_Result = Get_Full_ADC();
        Volt = ADC_Result / 1024.0 * 5.0;
        printf ("Volt at AN4 is %f\r\n\n", Volt);
        }
}