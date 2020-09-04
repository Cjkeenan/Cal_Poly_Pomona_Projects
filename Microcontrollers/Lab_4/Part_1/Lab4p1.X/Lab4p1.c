//Created by Mark Tippit and Colin Keenan for ECE 3301L Spring 2019 at Cal Poly Pomona
//Lab 4

#include <p18f4620.h>
//#include <p18f4321.h>
#include <stdio.h>
#include <math.h>
#include <usart.h>

#pragma config OSC = INTIO67
//#pragma config OSC = INTIO2
#pragma config WDT = OFF
#pragma config LVP = OFF
#pragma config BOREN = OFF
//#pragma config BOR = OFF

// Prototype Area
void init_IO(void);
void putch(char);
void init_UART(void);
unsigned int get_full_ADC(void);

//Color Prototypes
void SET_RED_1(void);
void SET_GREEN_1(void);
void SET_BLUE_1(void);
void SET_PURPLE_1(void);
void SET_YELLOW_1(void);
void SET_CYAN_1(void);
void SET_WHITE_1(void);
void SET_OFF_1(void);

void SET_RED_3(void);
void SET_GREEN_3(void);
void SET_YELLOW_3(void);


// Global Variables
#define RED_1 PORTBbits.RB0
#define GREEN_1 PORTBbits.RB1
#define BLUE_1 PORTBbits.RB2

#define RED_3 PORTEbits.RE0
#define GREEN_3 PORTEbits.RE1

int STEP;
float mVTEMP, TEMP;
int TEMP_ONES, TEMP_TENS, ITEMP, ImVTEMP;
char seven_seg[10] = {0x40, 0x79, 0x24, 0x30, 0x19, 0x12, 0x02, 0x78, 0x00, 0x10};	//7seg Hex values for Common Anode Seven Segment Display {0 ... 9}

void main(void)
{
    init_UART();
    init_IO();
    
    //Getting Temperature value
    while(1){
		//Poll ADC and convert to a Temperature
        STEP = get_full_ADC();					// get number of steps from ADC (max 1024)
        mVTEMP = STEP * 4.0;					// Temp in mV = Step * 4mV per step
        mVTEMP = mVTEMP + 30;					// Temperature voltage calibration due to interference
        TEMP = mVTEMP / 10.0;					// Temperature = Temp in mV / 10 mV per Degree F
		
		// Generate the ones and tens place number for Temperature
        ITEMP = (int)TEMP;						// Truncate temperature since we are only displaying two digits
        TEMP_TENS = ITEMP / 10;					// Get tens place, since type int, division will truncate
        TEMP_ONES = ITEMP % 10;					// Get ones place by getting the remainder by division by 10 as many times as possible
        
        // Seven Segment setting Logic
		PORTD = seven_seg[TEMP_TENS];			// Set PORTD to the value of seven seg array created above at index of the current 10's place number
        PORTC = seven_seg[TEMP_ONES];			// Set PORTC to the value of seven seg array created above at index of the current 1's place number
        
        printf("Temperature = %f.\r\n", TEMP);	// print current temperature reading to USB UART
        
        //Setting colors of RGB LEDs
        //D1 LOGIC
        if(ITEMP < 65)							// if the integer version of temp is below 65
        {
            SET_OFF_1();						// turn off
        }
        else if(65 >= ITEMP && ITEMP <= 72)		// if the integer version of temp is between 65 and 72
        {
            SET_RED_1();						// set red
        }
        else if (73 >= ITEMP && ITEMP <= 76)	// if the integer version of temp is between 73 and 76
        {
            SET_GREEN_1();						// set green
        }
        else if (77 >= ITEMP && ITEMP <= 83)	// if the integer version of temp is between 77 and 83
        {
            SET_BLUE_1();						// set blue
        }
        else if (ITEMP > 83)					// if the integer version of temp is greater than 83
        {
            SET_WHITE_1();						// set white
        }
        else
        {
            SET_PURPLE_1();						// set to a different color so if there is an error we are aware
        }
        
        //D2 LOGIC
        PORTB = (0x07 & PORTB) | (TEMP_TENS << 3);		//clear PORTB bits 3,4,5 and then set those bits to the tens place of the temp (Shift left too ofset number by bits 0, 1, 2)
        
        //D3 LOGIC
        ImVTEMP = STEP * 4;								// Generate the Integer version of the Temp in mV
        if(ImVTEMP <= 2000)								// if the voltage is below 2000 mV
        {
            SET_RED_3();								// set green
        }
        else if(ImVTEMP > 2000 && ImVTEMP <= 3000)		// if the voltage is between 2000mV and 3000mV
        {
            SET_GREEN_3();								// set green
        }
        else if (ImVTEMP > 3000)						// if the voltage is above 3000 mV
        {
            SET_YELLOW_3();								// set yellow
        }
    }
}

void putch (char c)
{
    while (!TRMT);
    TXREG = c;
}

void init_UART()
{
    OpenUSART (USART_TX_INT_OFF & USART_RX_INT_OFF &
    USART_ASYNCH_MODE & USART_EIGHT_BIT & USART_CONT_RX &
    USART_BRGH_HIGH, 25);
    OSCCON = 0x60;
}

void init_IO (void)
{
    TRISA = 0xFF;                       //Initialize with the Port A as input
    TRISB = 0x00;                       //Initialize with the Port B as output (RGB LEDs 1,2)
    TRISC = 0x00;                       //Initialize with the Port C as output (7 seg 1)
    TRISD = 0x00;                       //Initialize with the Port D as output (7 seg 2)
    TRISE = 0x00;                        //Initialize with the Port E as output (Common Cathode RGB)
    
    ADCON0 = 0x05;                      // select channel AN0, and turn on the ADC subsystem
    ADCON1 = 0x1B;                      // set all pins as digital signal except AN0-AN3, VREF+, VSS as reference voltage
    ADCON2 = 0xA9;                      // right justify the result and set the bit conversion time (TAD) and acquisition time
}

unsigned int get_full_ADC(void)
{
    int result;
    
    ADCON0bits.GO = 1;                  // Start Conversion
    while(ADCON0bits.DONE == 1);        // wait for conversion to be completed
    result = (ADRESH * 0x100) + ADRESL; // combine result of upper byte and lower byte into result

    return result;                      // return the result.
}


// Color Setting Definitions
//

//D1 set (Common Cathode)
void SET_RED_1()
{
    RED_1 = 1;
    GREEN_1 = 0;
    BLUE_1 = 0;
}
void SET_GREEN_1()
{
    RED_1 = 0;
    GREEN_1 = 1;
    BLUE_1 = 0;
}
void SET_BLUE_1()
{
    RED_1 = 0;
    GREEN_1 = 0;
    BLUE_1 = 1;
}
void SET_YELLOW_1()
{
    RED_1 = 1;
    GREEN_1 = 1;
    BLUE_1 = 0;
}
void SET_CYAN_1()
{
    RED_1 = 0;
    GREEN_1 = 1;
    BLUE_1 = 1;
}
void SET_PURPLE_1()
{
    RED_1 = 1;
    GREEN_1 = 0;
    BLUE_1 = 1;
}
void SET_WHITE_1()
{
    RED_1 = 1;
    GREEN_1 = 1;
    BLUE_1 = 1;
}
void SET_OFF_1()
{
    RED_1 = 0;
    GREEN_1 = 0;
    BLUE_1 = 0;
}

//D3 set (Common Anode)
void SET_RED_3()
{
    RED_3 = 0;
    GREEN_3 = 1;
}
void SET_GREEN_3()
{
    RED_3 = 1;
    GREEN_3 = 0;
}
void SET_YELLOW_3()
{
    RED_3 = 0;
    GREEN_3 = 0;
}