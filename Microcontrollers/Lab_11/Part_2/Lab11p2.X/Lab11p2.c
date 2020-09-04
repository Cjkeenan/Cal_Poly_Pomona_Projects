#include <stdio.h>
#include <stdlib.h>
#include <xc.h>
#include <math.h>
#include <p18f4620.h>
#pragma config OSC = INTIO67
#pragma config BOREN =OFF
#pragma config WDT=OFF
#pragma config LVP=OFF

#define _XTAL_FREQ      8000000

#define DS3231_ID       0x68
#define DS3231_Add_00   0x00
#define DS3231_Add_0E   0x0E
#define DS3231_Add_11   0x11

#define ACCESS_CFG      0xAC
#define START_CONV      0xEE
#define READ_TEMP       0xAA
#define CONT_CONV       0x02

#define ACK             1
#define NAK             0

#define setup_sw        PORTAbits.RA0

void Setup_RTC_Time(char);
void DS3231_Read_Time(char);
int  DS3231_Read_Temp(char);
void Initialize_TFT_Screen(void);
void Update_Screen(void);\

void delay_ms(int);
void putch(char);
void init_UART(void);
	
#define TFT_CS              PORTDbits.RD1		// change the value for CS based on your schematics
#define TFT_DC              PORTDbits.RD0      // change the value for DC based on your schematics
#define TFT_RST             PORTDbits.RD2		// change the value for RST based on your schematics
#define PULSE               PORTCbits.RE0

#define TS_1                1               	// Size of Normal Text
#define TS_2                2               	// Size of Number Text 
#define start_x             2
#define start_y             2
#define temp_x              28
#define temp_y              23
#define circ_x              40
#define circ_y              35
#define data_tempc_x        15
#define data_tempc_y        35
#define tempc_x             45
#define tempc_y             35
#define cirf_x              95
#define cirf_y              35
#define data_tempf_x        70
#define data_tempf_y        35
#define tempf_x             100
#define tempf_y             35
#define time_x              50
#define time_y              58
#define data_time_x         15
#define data_time_y         70
#define date_x              50
#define date_y              93
#define data_date_x         15
#define data_date_y         105
#define dc_x                15
#define dc_y                130
#define RPM_x               90
#define RPM_y               130
#define data_dc_x           4
#define data_dc_y           142
#define data_RPM_x          75
#define data_RPM_y          142
#include "ST7735_TFT.inc"

#define SCL_PIN PORTBbits.RB3
#define SCL_DIR TRISBbits.RB3
#define SDA_PIN PORTBbits.RB4
#define SDA_DIR TRISBbits.RB4
#include "softi2c.inc"

unsigned char i, second, minute, hour, dow, day, month, year, old_second;
int temp_MSB, temp_LSB, DS3231_tempC, DS3231_tempF;

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

char buffer[31] = "ECE3301L Spring 2019\0";
char *nbr;
char *txt;
char tempC[]        = "25";
char tempF[]        = "77";
char time[]         = "00:00:00";
char date[]         = "00/00/00";
char dc_text[]      = "50%";
char RPM_text[]     = "1800";

void Initialize_Screen(void) 
{ 
    LCD_Reset();                  // Screen reset
    TFT_GreenTab_Initialize();         
    fillScreen(ST7735_BLACK);     // Fills background of screen with color passed to it
 
    strcpy(txt, "ECE3301L Spring 2019\0");                                  // Text displayed 
    drawtext(start_x , start_y, txt, ST7735_WHITE  , ST7735_BLACK, TS_1);   // X and Y coordinates of where the text is to be displayed including text color and the background of it
                                                                            
    strcpy(txt, "Temperature:");                    
    drawtext(temp_x  , temp_y , txt, ST7735_MAGENTA, ST7735_BLACK, TS_1);   
    drawCircle(circ_x, circ_y , 2  , ST7735_YELLOW);                        //degree symbol
    
    strcpy(txt, "C/");
    drawtext(tempc_x , tempc_y, txt, ST7735_YELLOW , ST7735_BLACK, TS_2); 
    
    strcpy(txt, "F");         
    drawCircle(cirf_x, cirf_y , 2  , ST7735_YELLOW);                        //degree symbol
    drawtext(tempf_x , tempf_y, txt, ST7735_YELLOW , ST7735_BLACK, TS_2);
    
    strcpy(txt, "Time");
    drawtext(time_x  , time_y , txt, ST7735_BLUE   , ST7735_BLACK, TS_1);
    
    strcpy(txt, "Date");
    drawtext(date_x  , date_y , txt, ST7735_RED    , ST7735_BLACK, TS_1);
    
    strcpy(txt, "DC");
    drawtext(dc_x    , dc_y   , txt, ST7735_WHITE  , ST7735_BLACK, TS_1);
    
    strcpy(txt, "RPM");
    drawtext(RPM_x   , RPM_y  , txt, ST7735_WHITE   , ST7735_BLACK, TS_1);  
}


void Update_TFT_Screen(void)
{
    tempC[0]  = DS3231_tempC/10  + '0';
    tempC[1]  = DS3231_tempC%10  + '0';
    tempF[0]  = DS3231_tempF/10  + '0';
    tempF[1]  = DS3231_tempF%10  + '0';
    time[0]   = (hour >> 4)  + '0';
    time[1]   = (hour & 0x0F)  + '0';
    time[3]   = (minute >> 4)  + '0';
    time[4]   = (minute & 0x0F)  + '0';
    time[6]   = (second >> 4)  + '0';
    time[7]   = (second & 0x0F)  + '0';
    date[0]   = (month >> 4)  + '0';
    date[1]   = (month & 0x0F)  + '0';
    date[3]   = (day >> 4) + '0';
    date[4]   = (day & 0x0F)  + '0';
    date[6]   = (year >> 4)  + '0';
    date[7]   = (year & 0x0F)  + '0';
    
    drawtext(15, 35, tempC, ST7735_YELLOW, ST7735_BLACK, 2);       
    drawtext(70, 35, tempF, ST7735_YELLOW, ST7735_BLACK, 2);
    drawtext(15, 70, time, ST7735_CYAN, ST7735_BLACK, 2);
    drawtext(15, 105, date, ST7735_GREEN, ST7735_BLACK, 2);   
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


int DS3231_Read_Temp(char Device)
{
    I2C_Start();                    //send start command
    I2C_Write((Device << 1 | 0 ));  //select device with write attribute
    I2C_Write((DS3231_Add_11));     //select starting register
    I2C_ReStart();                  //send start again
    I2C_Write((Device << 1) | 1 );  //select device with read attribute
    temp_MSB = I2C_Read(ACK);       //read temperature 2 MSBs
    temp_LSB = I2C_Read(NAK);       //read temperature 8 LSBs
    I2C_Stop();                     //send stop command
    delay_ms(50);                   //wait 50ms
}


void Setup_RTC_Time(char Device)
{
											// << add code from Lab #10
}


void main()
{
    init_UART();
    OSCCON =0x70;
    ADCON1 = 0x0F;                      	//	
    nRBPU = 0;                            	// Enable PORTB internal pull up resistor 
	TRISA = 0xFF;							// << add the appropriate value for the TRISx registers
    TRISB = 0xFF;
    TRISC = 0x01;
	TRISD = 0x00;
 	//TRISE = 0x--;       

    I2C_Init(100000);                   	// Initialize I2C Master with 100KHz clock 
    txt = buffer;    

    Initialize_Screen();
    while(1)
    {
        if (setup_sw == 0)
        {
            DS3231_Read_Time(DS3231_ID);
            if (second != old_second)
            {     
                DS3231_Read_Temp(DS3231_ID);            //read temperature
                long int fullTemp = (temp_MSB << 8);    //shift MSB to the left by 8 to make room for LSB
                fullTemp = fullTemp | temp_LSB;         //concatenate MSB with LSB
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

                Update_TFT_Screen();
            }
            old_second = second;
        }
        else
        {
            Setup_RTC_Time(DS3231_ID);
        }
    }
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