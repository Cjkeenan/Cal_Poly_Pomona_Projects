#include <stdio.h>
#include <stdlib.h>
#include <xc.h>
#include <math.h>
#include <p18f4620.h>

#pragma config OSC      =   INTIO67
#pragma config BOREN    =   OFF
#pragma config WDT      =   OFF
#pragma config LVP      =   OFF

unsigned int get_full_ADC(void);
void Init_ADC(void);
void Init_UART(void);
void Select_Channel(char);
float Read_Volt_In(void);

void main()
{
    Init_UART();
    Init_ADC();
    Select_Channel(0);
    
    float Volts;
    
    while(1)
    {
        Volts = Read_Volt_In();
        printf("Voltage = %f\r\n", Volts);
    }
}

float Read_Volt_In()
{
    int STEP;
    STEP = get_full_ADC();					// get number of steps from ADC (max 1024)
    return (STEP * 4.0) / 1000.0;			// Voltage in V = Step * 4mV per step / 1000 mV per Volt
}

unsigned int get_full_ADC(void)
{
    int result;
    
    ADCON0bits.GO = 1;                  // Start Conversion
    while(ADCON0bits.DONE == 1);        // wait for conversion to be completed
    result = (ADRESH * 0x100) + ADRESL; // combine result of upper byte and lower byte into result

    return result;                      // return the result.
}

void Init_UART()
{
    OpenUSART (USART_TX_INT_OFF & USART_RX_INT_OFF &
    USART_ASYNCH_MODE & USART_EIGHT_BIT & USART_CONT_RX &
    USART_BRGH_HIGH, 25);
    OSCCON = 0x60;
}

void Init_ADC()
{
    //ADCON0=0x01;    // select channel AN0, and turn on the ADC subsystem
    ADCON1=0x17 ;   // select pins AN0 through AN7 as analog signal, VDD-VSS as
                    // reference voltage
    ADCON2=0xA9;    // right justify the result. Set the bit conversion time (TAD) and
                    // acquisition time
    TRISA=0x01;     // Set PORTA as input
}

void Select_Channel(char c)
{
    ADCON0 = (c * 4) + 1;
}

void putch (char c)
{   
    while (!TRMT);       
    TXREG = c;
}