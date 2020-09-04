#include <stdio.h>
#include <stdlib.h>
#include <xc.h>
#include <math.h>
#include <p18f4620.h>

#pragma config OSC      =   INTIO67
#pragma config BOREN    =   OFF
#pragma config WDT      =   OFF
#pragma config LVP      =   OFF
#pragma config CCP2MX   =   PORTBE

#define _XTAL_FREQ      8000000         // Set operation for 8 Mhz
#define TMR_CLOCK       _XTAL_FREQ/4    // Timer Clock 2 Mhz
#define COUNT_PER_MS    TMR_CLOCK/1000  // Count per ms = 2000
#define COUNT_SCALED    COUNT_PER_MS/32 // 
#define PULSE           PORTCbits.RC1

#define TS_1 1 // Size of Normal Text
#define TS_2 2 // Size of Number Text

#define title_txt_X 2 // X-location of Title Text
#define title_txt_Y 2 // X-location of Title Text

#define voltage_txt_X 25 // X-location of Voltage Text
#define voltage_txt_Y 25 // Y-location of Voltage Text

#define voltage_X 40 // X-location of Voltage Number
#define voltage_Y 37 // Y-location of Voltage Number
#define voltage_Color ST7735_BLUE // Color of Voltage data

#define dc_txt_X 37
#define dc_txt_Y 60
#define dc_X 52
#define dc_Y 72
#define dc_Color ST7735_MAGENTA

#define RPS_txt_X 20
#define RPS_txt_Y 95
#define RPS_X 20
#define RPS_Y 107
#define RPS_Color ST7735_CYAN

#define HZ_txt_X 90
#define HZ_txt_Y 95
#define HZ_X 75
#define HZ_Y 107
#define HZ_Color ST7735_CYAN

#define RPM_txt_X 37
#define RPM_txt_Y 130
#define RPM_X 20
#define RPM_Y 142
#define RPM_Color ST7735_WHITE

#define TFT_RST     PORTBbits.RB4       // Location of TFT Reset
#define TFT_CS      PORTBbits.RB2       // Location of TFT Chip Select
#define TFT_DC      PORTBbits.RB5       // Location of TFT D/C


int get_RPS(void);
void delay_500ms(void);
void Init_UART(void);
void putch(char);
void Init_ADC(void);
void do_update_pwm(char);
float Read_Volt_In(void);
unsigned int get_full_ADC(void);
void Select_Channel(char);
void delay_ms(int);

char *txt;
char buffer[30] = "";
char voltage_text[] = "0.0V";
char dc_text[] = "--%";
char RPS_text[] = "00";
char HZ_text[] = "000";
char RPM_text[] = "0000 RPM";

#include "ST7735_TFT.inc"

void Initialize_Screen()
{
    LCD_Reset();
    TFT_GreenTab_Initialize();
    fillScreen(ST7735_BLACK);
    
    strcpy(txt, " ECE3301L Spring 2019\0");
    drawtext(title_txt_X,   title_txt_Y,    txt, ST7735_WHITE,  ST7735_BLACK, TS_1);

    strcpy(txt, "Input Voltage:");
    drawtext(voltage_txt_X, voltage_txt_Y,  txt, voltage_Color, ST7735_BLACK, TS_1);

    strcpy(txt, "Hz");
    drawtext(HZ_txt_X,      HZ_txt_Y,       txt, HZ_Color,      ST7735_BLACK, TS_1); //Hz

    strcpy(txt, "Duty Cycle");
    drawtext(dc_txt_X,      dc_txt_Y,       txt, dc_Color,      ST7735_BLACK, TS_1); //Duty Cycle

    strcpy(txt, "RPS");
    drawtext(RPS_txt_X,     RPS_txt_Y,      txt, RPS_Color,     ST7735_BLACK, TS_1); //RPS

    strcpy(txt, "Fan Speed");
    drawtext(RPM_txt_X,     RPM_txt_Y,      txt, RPM_Color,     ST7735_BLACK, TS_1); //Fan Speed
}

void main()
{
    Init_UART();
    Init_ADC();
    OSCCON = 0x70;
    txt = buffer;
    Initialize_Screen();
    Select_Channel(0);
    
    while (1)
    {
        float input_voltage = Read_Volt_In(); // get input voltage
        char dc = (input_voltage/ 4.096) * 100; // calculate duty cycle
        printf("DC: %p, Voltage: %f\r\n", dc, input_voltage);
        do_update_pwm(dc); // generate PWM
        char RPS = get_RPS(); // measure RPS
        int HZ = RPS * 2; // calculate HZ equivalent
        int RPM = RPS * 60; // calculate RPM equivalent

        //2 digit Input Voltage
        char IV_0 = (int) input_voltage;
        char IV_1 = (int) ((input_voltage - IV_0) * 10);
        voltage_text[0] = IV_0 + '0';
        voltage_text[2] = IV_1 + '0';
        drawtext(voltage_X, voltage_Y, voltage_text, voltage_Color, ST7735_BLACK, TS_2);

        //3 digits Frequency
        char HZ_0 = HZ/100; 
        char HZ_1 = (HZ/10)%10; 
        char HZ_2 = HZ%10; 
        HZ_text[0] = HZ_0 + '0'; 
        HZ_text[1] = HZ_1 + '0'; 
        HZ_text[2] = HZ_2 + '0';
        drawtext(HZ_X, HZ_Y, HZ_text, HZ_Color, ST7735_BLACK, TS_2); //Hz

        //2 digits Duty Cycle
        int dcint = dc;
        char dc_0 = (int)(dcint/10);
        char dc_1 = (int)(dcint%10);
        dc_text[0] = dc_0 + '0';
        dc_text[1] = dc_1 + '0';
        drawtext(dc_X, dc_Y, dc_text, dc_Color, ST7735_BLACK, TS_2); //Duty Cycle

        //2 digits RPS
        int RPSint = RPS;
        char RPS_0 = (int)(RPSint/10);
        char RPS_1 = (int)(RPSint%10);
        RPS_text[0] = RPS_0 + '0';
        RPS_text[1] = RPS_1 + '0';
        drawtext(RPS_X, RPS_Y, RPS_text, RPS_Color, ST7735_BLACK, TS_2); //RPS

        //4 digits RPM
        char RPM_0 = RPM/1000; 
        char RPM_1 = (RPM/100)%10; 
        char RPM_2 = (RPM/10)%10;
        char RPM_3 = RPM%10; 
        RPM_text[0] = RPM_0 + '0'; 
        RPM_text[1] = RPM_1 + '0'; 
        RPM_text[2] = RPM_2 + '0';
        RPM_text[3] = RPM_3 + '0';
        drawtext(RPM_X, RPM_Y, RPM_text, RPM_Color, ST7735_BLACK, TS_2);
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

int get_RPS(void)
{
    TMR1L = 0;          // clear TMR1L to clear the pulse counter
    T1CON = 0x03;       // enable the hardware counter
    PULSE = 1;          // turn on the PULSE signal
    delay_500ms();     // delay 500 msec
    PULSE = 0;          // turn off the PULSE signal
    char RPS = TMR1L;   // read the number of pulse
    T1CON = 0x02;       // disable the hardware counter
    return (RPS);       // return the counter
}

void delay_500ms(void)
{
    int count;
    int ms = 500;
    count = (0xffff - (COUNT_SCALED * ms)) - 421;
    
        T0CON = 0x04;                   // Timer 0, 16-bit mode, pre scaler 1:32
        TMR0L = count & 0x00ff;         // set the lower byte of TMR
        TMR0H = count >> 8;             // set the upper byte of TMR
        INTCONbits.TMR0IF = 0;          // clear the Timer 0 flag
        T0CONbits.TMR0ON = 1;           // Turn on the Timer 0
        while (INTCONbits.TMR0IF == 0); // wait for the Timer Flag to be 1 for done
        T0CONbits.TMR0ON = 0;           // turn off the Timer 0
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

void putch (char c)
{   
    while (!TRMT);       
    TXREG = c;
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
    TRISC=0x01;     // Set PORTC as output with bit 0 as input (tach)
    TRISD=0x00;     // Set PORTD as output
    TRISE=0x00;     // Set PORTE as output
}

void Select_Channel(char c)
{
    ADCON0 = (c * 4) + 1;
}

void delay_ms(int ms)
{
    int count;
    count = (0xffff - COUNT_SCALED) - 1;
    count = count * ms;
 
	T0CON = 0x04;                       // Timer 0, 16-bit mode, pre scaler 1:32
	TMR0L = count & 0x00ff;             // set the lower byte of TMR
	TMR0H = count >> 8;                 // set the upper byte of TMR
	INTCONbits.TMR0IF = 0;              // clear the Timer 0 flag
	T0CONbits.TMR0ON = 1;               // Turn on the Timer 0

	while (INTCONbits.TMR0IF == 0); 	// wait for the Timer Flag to be 1 for done
	T0CONbits.TMR0ON = 0;               // turn off the Timer 0
}