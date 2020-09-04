#include <stdio.h>
#include <stdlib.h>
#include <xc.h>
#include <math.h>
#include <p18f4620.h>
#include <pic18f4620.h>
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
void Update_Screen(void);
void INT0_isr(void);
void INT1_isr(void);
void do_update_pwm(char);
int get_RPS(void);
void delay_500ms(void);
void delay_ms(int);

#define TFT_CS              PORTDbits.RD1		// change the value for CS based on your schematics
#define TFT_DC              PORTDbits.RD0      // change the value for DC based on your schematics
#define TFT_RST             PORTDbits.RD2		// change the value for RST based on your schematics
#define PULSE               PORTEbits.RE0
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

char SWUP_flag, SWDN_flag;
char Setup_Mode, Select_Field;
unsigned char i, second, minute, hour, dow, day, month, year, old_second;
int temp_LSB, temp_MSB, DS3231_tempC, DS3231_tempF;

char SWUP_flag, SWDN_flag;
short duty_cycle;
int rps, RPM;

//IR Control Prototypes
#define CH_DN       0x00ffa25d
#define CH_UP       0x00ffe21d
#define Plus        0x00ffa857
#define Minus       0x00ffe01f
#define Prev        0x00ff22dd
#define Next        0x00ff02fd

void TIMER1_isr(void);
void INT2_isr(void);
void IR_Error(void);

unsigned char nec_state = 0;
unsigned char i;
short nec_ok = 0;
short bit_count = 0;
unsigned long long nec_code;

void interrupt high_priority chkisr() 
{
    if (INTCONbits.INT0IF == 1) INT0_isr();
    if (INTCON3bits.INT1IF == 1) INT1_isr();
    if (PIR1bits.TMR1IF == 1) TIMER1_isr();
    if (INTCON3bits.INT2IF == 1) INT2_isr();
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

char buffer[31] = " ECE3301L Spring 2019\0";
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
    LCD_Reset();                                                 // Screen reset
    TFT_GreenTab_Initialize();         
    fillScreen(ST7735_BLACK);                                    // Fills background of screen with color passed to it
 
    strcpy(txt, " ECE3301L Spring 2019\0");                                 // Text displayed 
    drawtext(start_x , start_y, txt, ST7735_WHITE  , ST7735_BLACK, TS_1);   // X and Y coordinates of where the text is to be displayed
    strcpy(txt, "Temperature:");
    drawtext(temp_x  , temp_y , txt, ST7735_MAGENTA, ST7735_BLACK, TS_1);                                                                                               // including text color and the background of it
    drawCircle(circ_x, circ_y , 2  , ST7735_YELLOW);
    strcpy(txt, "C/");
    drawtext(tempc_x , tempc_y, txt, ST7735_YELLOW , ST7735_BLACK, TS_2); 
    strcpy(txt, "F");         
    drawCircle(cirf_x, cirf_y , 2  , ST7735_YELLOW);
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
    
    rps = get_RPS(); // measure RPS
    RPM = rps * 60; // calculate RPM equivalent
    
    char RPM_0 = RPM/1000; 
    char RPM_1 = (RPM/100)%10; 
    char RPM_2 = (RPM/10)%10;
    char RPM_3 = RPM%10; 
    RPM_text[0] = RPM_0 + '0'; 
    RPM_text[1] = RPM_1 + '0'; 
    RPM_text[2] = RPM_2 + '0';
    RPM_text[3] = RPM_3 + '0';
    drawtext(data_RPM_x, data_RPM_y, RPM_text, ST7735_WHITE, ST7735_BLACK, TS_2);
  
    int dcint = duty_cycle;
    char dc_0 = (int)(dcint/10);
    char dc_1 = (int)(dcint%10);
    dc_text[0] = dc_0 + '0';
    dc_text[1] = dc_1 + '0';
    drawtext(data_dc_x, data_dc_y, dc_text, ST7735_WHITE, ST7735_BLACK, TS_2); //Duty Cycle
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
    temp_MSB = I2C_Read(ACK);        //read temperature 2 MSBs
    temp_LSB = I2C_Read(NAK);        //read temperature 8 LSBs
    I2C_Stop();                     //send stop command
    delay_ms(50);                   //wait 50ms
}

void Setup_RTC_Time(char Device)
{
											// << add code from Lab #10
}

void INT0_isr(void)
{
    INTCONbits.INT0IF = 0;
    duty_cycle = duty_cycle + 5;
    if(duty_cycle > 95)
    {
        duty_cycle = 0;
    }
    do_update_pwm(duty_cycle); // generate PWM
}

void INT1_isr(void)
{
    INTCON3bits.INT1IF = 0;
    duty_cycle = duty_cycle - 5;
    if(duty_cycle < 0)
    {
        duty_cycle = 95;
    }
    do_update_pwm(duty_cycle); // generate PWM
}

void INT2_isr(void)
{
    unsigned int timer;
    INTCON3bits.INT2IF = 0; // Clear external interrupt
    if (nec_state != 0)
    {
        timer = (TMR1H << 8) | TMR1L; // Store Timer1 value
        TMR1H = 0; // Reset Timer1
        TMR1L = 0;
    }

    switch(nec_state)
    {
        case 0 :    //leading pulse detection
            //clear timer 1
            TMR1H = 0;
            TMR1L = 0;
            
            //program timer 1 with 1 microsecond of count
            //time per instruction in 1:1 prescale is 0.5 microseconds, so if its count + 1, count will be 1, if its just count, it will be 2
            T1CON = 0x90;
            //TMR1H = 0x00;
            //TMR1L = 0x01;
            
            //enable timer 1
            T1CONbits.TMR1ON = 1;
            
            //set bit_count to 0
            bit_count = 0;
            
            //set nec_code to 0
            nec_code = 0;
            
            //change INT2 to detect rising edge
            INTCON2bits.INTEDG2 = 1;
            
            //set nec_state to 1
            nec_state = 1;
            return;
            
        case 1 :    //end of leading pulse and start of space detection
            if(timer < 9500 && timer > 8500)
            {
                //printf("hello 1: %d\r\n", timer);
                //change edge detection to falling edge
                INTCON2bits.INTEDG2 = 0;
                nec_state = 2;
            }
            else
            {
                IR_Error();
            }
            return;
            
        case 2 :    //end of space detection
            //printf("hello 2: %d\r\n", timer);
            if(timer < 5000 && timer > 4000)
            {
                //change edge detection to rising edge
                INTCON2bits.INTEDG2 = 1;
                nec_state = 3;
            }
            
            else
            {
                IR_Error();
            }
            return;
            
        case 3 :    //start of the data detection loop bit by bit
            //printf("hello 3: %d\r\n", timer);
            if(timer < 700 && timer > 400)
            {
                //change edge detection to falling edge
                INTCON2bits.INTEDG2 = 0;
                nec_state = 4;
            }
            else
            {
                IR_Error();
            }
            return;
            
        case 4 :    //data read
            //printf("hello 4: %d\r\n", timer);
            if(timer < 1800 && timer > 400)
            {
                nec_code = nec_code << 1;       //shift nec_code to make space for new bit
                //check for if the time after pulse is greater than 1000 microseconds, which is a logical 1

                if(timer > 1000)  nec_code++;     //add logical 1
                bit_count++;    //increment count of bits
                    //printf("hello from 4: timer:%d, nec_code:%x, bit_count:%d\r\n", timer, nec_code, bit_count);
                    //check if all bits of code have been received
                    if(bit_count > 31)
                    {
                        nec_ok = 1;     //set flag for receiving all bits
                        INTCON3bits.INT2IE = 0;     //turn off INT2 interrupt
                    }
                    
                    //check if bits still need to be detected
                    else
                    {
                        //change edge detection to rising edge
                        INTCON2bits.INTEDG2 = 1;
                        nec_state = 3;      //check for next bit
                    }               
            }
            else
            {
                IR_Error();
            }
            return;
    }
}

void TIMER1_isr(void)
{
    nec_state = 0; // Reset decoding process
    INTCON2bits.INTEDG2 = 0; // Edge programming for INT2 falling edge
    T1CONbits.TMR1ON = 0; // Disable T1 Timer
    PIR1bits.TMR1IF = 0; // Clear interrupt flag
}

void IR_Error(void)
{
    nec_state = 0;
    T1CONbits.TMR1ON = 0;
}

void main()
{
    init_UART();
    OSCCON =0x70;
    ADCON1 = 0x0F;                      	//	
    nRBPU = 0;                            	// Enable PORTB internal pull up resistor 
    TRISA = 0x01;
    TRISB = 0x07;
    TRISC = 0x01;                           //
    TRISD = 0x00;
    TRISE = 0x00;  

    I2C_Init(100000);                   // Initialize I2C Master with 100KHz clock 
    txt = buffer;    
    
    INTCONbits.INT0IF = 0;      // INT0 IF is in INTCON
    INTCON3bits.INT1IF = 0;     // INT1 IF is in INTCON3

    INTCONbits.INT0IE = 1;      // INT0 IE is in INTCON
    INTCON3bits.INT1IE = 1;     // INT1 IE is in INTCON3

    INTCON2bits.INTEDG0 = 0;    // Edge programming for INT0, INT1 and
    INTCON2bits.INTEDG1= 0;     // INT2 are in INTCON2
            
    INTCONbits.PEIE = 1;        // Peripheral Interrupt Enable
	INTCONbits.GIE = 1;         // Global Interrupt Enable
    
    INTCON3bits.INT2IF = 0; // Clear external interrupt
    INTCON2bits.INTEDG2 = 0; // Edge programming for INT2 falling edge H to L
    INTCON3bits.INT2IE = 1; // Enable external interrupt
    
    TMR1H = 0; // Reset Timer1
    TMR1L = 0; //
    
    PIR1bits.TMR1IF = 0; // Clear timer 1 interrupt flag
    PIE1bits.TMR1IE = 1; // Enable Timer 1 interrupt
    INTCONbits.PEIE = 1; // Enable Peripheral interrupt
    INTCONbits.GIE = 1; // Enable global interrupts
    
    nec_ok = 0; // Clear flag
    nec_code = 0x0; // Clear code
    
    Initialize_Screen();
    
    duty_cycle = 50;
    do_update_pwm(duty_cycle); 
    
    
    while(1)
    {        
    if (nec_ok == 1)
    {
        nec_ok = 0;
        printf ("NEC_Code = %08lx \r\n", nec_code);
        INTCON3bits.INT2IE = 1; // Enable external interrupt
        INTCON2bits.INTEDG2 = 0; // Edge programming for INT2 falling edge
        
        if(nec_code = Plus)
        {
            duty_cycle = duty_cycle + 5;
            if(duty_cycle > 95)
            {
                duty_cycle = 0;
            }
            do_update_pwm(duty_cycle); // generate PWM 
        }
        
        if(nec_code = Minus)
        {
            duty_cycle = duty_cycle - 5;
            if(duty_cycle < 0)
            {
                duty_cycle = 95;
            }
            do_update_pwm(duty_cycle); // generate PWM 
        }
        
//        switch(nec_code)
//        {
//            case Plus:
//                duty_cycle = duty_cycle + 5;
//                if(duty_cycle > 95)
//                {
//                    duty_cycle = 0;
//                }
//                do_update_pwm(duty_cycle); // generate PWM               
//                return;
//            case Minus:
//                duty_cycle = duty_cycle - 5;
//                if(duty_cycle < 0)
//                {
//                    duty_cycle = 95;
//                }
//                do_update_pwm(duty_cycle); // generate PWM
//                return;
//        }
    }    
            
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

int get_RPS(void)
{
    TMR1L = 0;          // clear TMR1L to clear the pulse counter
    T1CON = 0x03;       // enable the hardware counter
    PULSE = 1;          // turn on the PULSE signal
    delay_500ms();      // delay 500 msec
    PULSE = 0;          // turn off the PULSE signal
    char RPS = TMR1L;   // read the number of pulse
    T1CON = 0x02;       // disable the hardware counter
    return (RPS);       // return the counter
}

void delay_ms(int ms)
{           
    #define COUNT_PER_MS    _XTAL_FREQ/4000     // Count per ms = 2000             
    #define COUNT_SCALED    COUNT_PER_MS/32     // 

    int count;
    count = COUNT_SCALED * ms;
    count = (0xffff - count);

    T0CON = 0x04;                       // Timer 0, 16-bit mode, pre-scaler 1:32

    TMR0L = count & 0x00ff;             // set the lower byte of TMR
    TMR0H = count >> 8;                 // set the upper byte of TMR

    INTCONbits.TMR0IF = 0;              // clear the Timer 0 flag
    T0CONbits.TMR0ON = 1;               // Turn on the Timer 0

    while (INTCONbits.TMR0IF == 0);  // wait for the Timer Flag to be 1 for done
    T0CONbits.TMR0ON = 0;               // turn off the Timer 0
}
    
void delay_500ms(void) 
{
    INTCONbits.TMR0IF = 0;                  // clear the Timer 0 flag 
    T0CON = 0x04;                           // Timer 0, 16-bit mode, pre-scaler 1:32
    TMR0H = 0x86;
    TMR0L = 0x01; 

    T0CONbits.TMR0ON = 1;                   // Turn on the Timer 0  
    while (INTCONbits.TMR0IF == 0);         // wait for the Timer Flag to be 1 for done  
    T0CONbits.TMR0ON = 0;                   // turn off the Timer 0 } 
}
