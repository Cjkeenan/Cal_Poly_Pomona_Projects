#include <p18f4620.h>
#include <stdio.h>
#include <math.h>
#include <usart.h>

#pragma config OSC = INTIO67
#pragma config WDT = OFF
#pragma config LVP = OFF
#pragma config BOREN = OFF
#pragma config CCP2MX = PORTBE

//input RA0 Vin

//output B0, B1, B2, RGB 
#define RED PORTBbits.RB0
#define GREEN PORTBbits.RB1
#define BLUE PORTBbits.RB2
//RC0 - RC7 1st 7seg
//RD7 1st 7seg DP
#define DP PORTDbits.RD7
//RD0 - RD6 2nd 7seg
//VREF RA3
//RE0 VREF through 10k
//RE1 VREF through 1k
//RE2 VREF through 100

unsigned int get_full_ADC(void);
void Init_ADC(void);
void Init_UART(void);
void Select_Channel(char);
void turn_off_buzzer(void);
void gen_1Khz_beep(void);
void gen_2Khz_beep(void);

void main()
{
    Init_UART();
    Init_ADC();
    Select_Channel(5);          //ADCON select channel 5 for ADC (100-ohm resistor)
    
    int STEP;
    float Volts, RL;
    
    while(1)
    {
        //Poll ADC and convert to a Temperature
        STEP = get_full_ADC();					// get number of steps from ADC (max 1024)
        Volts = (STEP * 4.0) / 1000;			// Volts in V = Step * 4mV per step / 1000 mV per Volt
        RL = (Volts / (4.096 - Volts)) * 0.1;   // Using Ohms Law in order to find resistance from known Vref and recorded voltage
        
        printf("RL = %f\r\n", RL);
        
        if(RL >= 0.1)				//if the resistance is greater than 100 ohms
        {
            turn_off_buzzer();
            PORTB = 0x00;			//turn off RGB LED
        }
        if(RL < 0.1 && RL >= 0.01)	//if the resistance is between 10 and 100 ohms
        {
            gen_1Khz_beep();
            PORTB = 0x01;			//set color of RGB to red, since red has a long wavelength, i.e. low frequency
        }
        if(RL < 0.01)				//if the resistance is less than 10 ohms
        {
            gen_2Khz_beep();
            PORTB = 0x04;			//set color of RGB to blue, since blue has a short wavelength, i.e. high frequency
        }
    }
}

void gen_1Khz_beep (void)
{
    PR2 = 0b11111001;      // values for 1Khz beep
    CCPR2L = 0b01010010;
    CCP2CON = 0b00011100;
    T2CON = 0b00000101;    // Turn T2 on here
}

void gen_2Khz_beep (void)
{
    PR2 = 0b01111100;      // values for 2Khz beep
    CCPR2L = 0b00111110;
    CCP2CON = 0b00011100;
    T2CON = 0b00000101;    // Turn T2 on here
}

void turn_off_buzzer (void)
{
    CCP2CON = 0;
}

void Init_ADC(void)
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
    TRISE=0xFF;     // Set PORTE as input
 
}

void Select_Channel(char c)
{
    ADCON0 = (c * 4) + 1;
}
 
unsigned int get_full_ADC(void)
{
    int result;
    ADCON0bits.GO=1;                        // Start Conversion
    while(ADCON0bits.DONE==1);              // wait for conversion to be completed
    result = (ADRESH * 0x100) + ADRESL;     // combine result of upper byte and lower byte into result
    return result;                          // return the result.
}

void Init_UART()
{
    OpenUSART (USART_TX_INT_OFF & USART_RX_INT_OFF &
    USART_ASYNCH_MODE & USART_EIGHT_BIT & USART_CONT_RX &
    USART_BRGH_HIGH, 25);
    OSCCON = 0x60;
}
 
void putch(char c)
{
    while(!TRMT);
    TXREG = c;
}