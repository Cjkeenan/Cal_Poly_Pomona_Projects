#include <p18f4620.h>
#include <stdio.h>
#include <math.h>
#include <usart.h>

#pragma config OSC = INTIO67
#pragma config WDT = OFF
#pragma config LVP = OFF
#pragma config BOREN = OFF

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
void Do_Display(float);
void Init_ADC(void);
void Init_UART(void);
void Select_Channel(char);
void Color_Select(float);

void main()
{
    Init_UART();
    Init_ADC();
    Select_Channel(7);          //ADCON select channel 7 for ADC (10K-ohm resistor)
    
    int STEP;
    float Volts, RL;
    
    while(1)
    {
        //Poll ADC and convert to a Resistance
        STEP = get_full_ADC();					// get number of steps from ADC (max 1024)
        Volts = (STEP * 4.0) / 1000;			// Volts in V = Step * 4mV per step / 1000 mV per Volt
        RL = (Volts / (4.096 - Volts)) * 10.0;  // Using Ohms Law in order to find resistance from known Vref and recorded voltage R = V/I  
        
        printf("RL = %f\r\n", RL);
        Do_Display(RL);
        Color_Select(RL);
    }
}

void Do_Display(float V)
{
    int U_value, L_value, U_display, L_display;
    char seven_seg[10] = {0x40, 0x79, 0x24, 0x30, 0x19, 0x12, 0x02, 0x78, 0x00, 0x10};	//7seg Hex values for Common Anode Seven Segment Display {0 ... 9}
    
    if(V < 10.0)
    {
        U_value = (int)(V);						//Since the resistor is less than 10K ohms, upper value truncated by int will give the ones place
        L_value = ((int)(V - U_value)) * 10;	//Voltage - ones place will give the decimal value, which when multiplied by 10 will give the value of the lower place	

        U_display = seven_seg[U_value];
        L_display = seven_seg[L_value];
        
        PORTC = U_display;
        PORTD = L_display;
        DP = 0;
    }
    if (V >= 10.0)
    {
        U_value = ((int)V) / 10;		//Since the resistor is over 10K ohms, upper value is determined by casting the resitance to int, and then dividing by 10 allowing truncation
        L_value = ((int)V) % 10;		//lower value is the remainder after dividing the resistance by 10 n times	

        U_display = seven_seg[U_value];
        L_display = seven_seg[L_value];
        
        PORTC = U_display;
        PORTD = L_display;
        DP = 1;
    }
}

void Color_Select(float R)
{
    int tens_value = (int)(R / 10.0);
    if(tens_value >= 7)
    {
        PORTB = 0x07;		//If resistor value above 70K ohms, display white
    }
    else
    {
        PORTB = tens_value;	//display color corresponding to the tens place of resistor in K ohms
    }
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