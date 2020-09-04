#include <stdio.h>
#include <stdlib.h>
#include <xc.h>
#include <math.h>
#include <p18f4620.h>

#pragma config OSC      =   INTIO67
#pragma config BOREN    =   OFF
#pragma config WDT      =   OFF
#pragma config LVP      =   OFF

void Init_ADC(void);
void do_update_pwm(char);
float Read_Volt_In(void);
unsigned int get_full_ADC(void);
void Select_Channel(char);
void putch(char);
void Init_UART(void);

void main()
{
    Init_ADC(); // initialize all the hardware
    Init_UART();
    Select_Channel(0);
    
    while (1)
    {
        float input_voltage = Read_Volt_In ();      // read the input voltage
        float dc = (input_voltage / 4.096) * 100;    // calculate the percentage of the ratio of the input voltage versus the reference voltage of 4.096V. ?dc? must be converted into a ?char?
        printf("Duty Cycle: %f\r\n", dc);
        do_update_pwm((int)dc);                          // call routine to generate the PWM pulse
    }
}

void do_update_pwm(char duty_cycle)
{
    float dc_f;
    int dc_I;
    PR2 = 0b00000100 ;                  // set the frequency for 25 Khz
    T2CON = 0b00000111 ;                //
    
    dc_f = ( 4.0 * duty_cycle / 20.0) ; // calculate factor of duty cycle versus a 25 Khz signal
    dc_I = (int) dc_f;                  // get the integer part
    if (dc_I > duty_cycle) dc_I++;      // round up function
    
    CCP1CON = ((dc_I & 0x03) << 4) | 0b00001100;
    CCPR1L = (dc_I) >> 2;
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

void Init_ADC()
{
    //ADCON0=0x01;    // select channel AN0, and turn on the ADC subsystem
    ADCON1=0x17 ;   // select pins AN0 through AN7 as analog signal, VDD-VSS as
                    // reference voltage
    ADCON2=0xA9;    // right justify the result. Set the bit conversion time (TAD) and
                    // acquisition time
    TRISA=0xFF;     // Set PORTA as input
    TRISB=0x00;     // Set PORTB as output
    TRISC=0x00;     // Set PORTC as output
    TRISD=0x00;     // Set PORTD as output
    TRISE=0x00;     // Set PORTE as output
}

void Select_Channel(char c)
{
    ADCON0 = (c * 4) + 1;
}

void Init_UART()
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