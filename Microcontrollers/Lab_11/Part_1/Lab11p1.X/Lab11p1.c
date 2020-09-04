#include <p18f4620.h>
#include <stdio.h>
#include <stdlib.h>
#include <xc.h>
#include <math.h>


#pragma config OSC = INTIO67
#pragma config BOREN =OFF
#pragma config WDT=OFF
#pragma config LVP=OFF

#define _XTAL_FREQ      8000000
#define setup_sw        PORTBbits.RB0

#define DS3231_ID       0x68
#define DS3231_Add_00   0x00
#define DS3231_Add_0E   0x0E
#define DS3231_Add_11   0x11
#define ACK             1
#define NAK             0


void Setup_RTC_Time(char);
void DS3231_Read_Time(char);
int  DS3231_Read_Temp(char);
void delay_ms(int);
void putch (char);
void init_UART(void);



//Software 1I2C
#define SCL_PIN PORTBbits.RB3
#define SCL_DIR TRISBbits.RB3
#define SDA_PIN PORTBbits.RB4
#define SDA_DIR TRISBbits.RB4
#include "softi2c.inc"




unsigned char i, second, minute, hour, dow, day, month, year, old_second;
int tempLSB, tempMSB, DS3231_tempC, DS3231_tempF;


void main()
{
    init_UART();
    OSCCON =0x70;                       //
    ADCON1 = 0x0F;                
    nRBPU = 0;                          // Enable PORTB internal pull up resistor
    TRISB = 0x01;                       // PORT B bit 0 as input

    TRISCbits.RC3 = 0;                  // PORT C bit 3 as output
    TRISCbits.RC4 = 0;                  // PORT C bit 4 as output
        
    I2C_Init(100000);                   // Initialize I2C Master with 100KHz clock 
    
    while(1)
    {  
        DS3231_Read_Time(DS3231_ID);
        
        if(second != old_second)
        {
            DS3231_Read_Temp(DS3231_ID);            //read temperature
            long int fullTemp = (tempMSB << 8);     //shift MSB to the left by 8 to make room for LSB
            fullTemp = fullTemp | tempLSB;          //concatenate MSB with LSB
            fullTemp = fullTemp >> 6;               //shift temperature right by 6 to eliminate unnecessary accuracy
            
            //Celsius conversion
            float tempC = .25 * fullTemp;
            DS3231_tempC = (int)tempC;
            
            //Fahrenheit conversion
            float tempF = ((tempC / 5) * 9) + 32;
            DS3231_tempF = (int)tempF;
            
            //display results
            printf("Time - %2x : %2x : %2x   " ,hour ,minute ,second);
            printf("Date - %2x / %2x / %2x   " ,month ,day ,year);
            printf("Day of Week - %x   " ,dow);
            printf("Temp[C] = %dC   " ,DS3231_tempC);
            printf("Temp[F] = %dF   \r" ,DS3231_tempF);
            
        }
        old_second = second;
        
    }
}


void putch (char c)
{   
    while (!TRMT);       
    TXREG = c;
}

void init_UART()
{
    	OpenUSART (USART_TX_INT_OFF & USART_RX_INT_OFF & USART_ASYNCH_MODE & USART_EIGHT_BIT & USART_CONT_RX & USART_BRGH_HIGH, 25);
    	OSCCON = 0x70;
}

int DS3231_Read_Temp(char Device)
{
    I2C_Start();                    //send start command
    I2C_Write((Device << 1 | 0 ));  //select device with write attribute
    I2C_Write((DS3231_Add_11));     //select starting register
    I2C_ReStart();                  //send start again
    I2C_Write((Device << 1) | 1 );  //select device with read attribute
    tempMSB = I2C_Read(ACK);        //read temperature 2 MSBs
    tempLSB = I2C_Read(NAK);        //read temperature 8 LSBs
    I2C_Stop();                     //send stop command
    delay_ms(50);                   //wait 50ms
}

void Setup_RTC_Time(char Device)
{

}

void DS3231_Read_Time(char Device)
{
    I2C_Start();                    //send start command
    I2C_Write((Device << 1 | 0 ));  //select device with write attribute
    I2C_Write((DS3231_Add_00));     //select starting register
    I2C_ReStart();                  //send start again
    I2C_Write((Device << 1) | 1 );  //select device with read attribute
    second = I2C_Read(ACK);         //read second register
    minute = I2C_Read(ACK);         //read minute register
    hour = I2C_Read(ACK);           //read hour register
    dow = I2C_Read(ACK);            //read day of week register
    day = I2C_Read(ACK);            //read day register
    month = I2C_Read(ACK);          //read month register
    year = I2C_Read(NAK);           //read year register
    I2C_Stop();                     //send stop command
    delay_ms(50);                   //wait 50ms
}
 
void delay_ms(int ms)
{
#define CPU_CLOCK       _XTAL_FREQ/4
#define COUNT_PER_MS    CPU_CLOCK/1000
#define COUNT_SCALED    COUNT_PER_MS/16
    
    int count;
    count = (0xffff - COUNT_SCALED) - 1;
    count = count * ms;
    
	T0CON = 0x03;                       // Timer 0, 16-bit mode, prescaler 1:16
	TMR0L = count & 0x00ff;             // set the lower byte of TMR
	TMR0H = count >> 8;                 // set the upper byte of TMR
	INTCONbits.TMR0IF = 0;              // clear the Timer 0 flag
	T0CONbits.TMR0ON = 1;               // Turn on the Timer 0

	while (INTCONbits.TMR0IF == 0); 	// wait for the Timer Flag to be 1 for done
	T0CONbits.TMR0ON = 0;               // turn off the Timer 0
}

