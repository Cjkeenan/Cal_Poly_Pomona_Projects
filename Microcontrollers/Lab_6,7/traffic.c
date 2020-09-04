
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


#define TFT_RST     PORTBbits.RB4       // Location of TFT Reset
#define TFT_CS      PORTBbits.RB2       // Location of TFT Chip Select
#define TFT_DC      PORTBbits.RB5       // Location of TFT D/C
#define NS_PED_SW   PORTAbits.RA3       // Location of Switch for North/South PED
#define NS_LT_SW    PORTAbits.RA4       // Location of Switch for North/South Left Turn
#define EW_PED_SW   PORTBbits.RB0       // Location of Switch for East/West PED
#define EW_LT_SW    PORTBbits.RB1       // Location of Switch for East/West Left Turn
#define SPKR        PORTBbits.RB3       // Location of Speaker
#define SEC_LED     PORTEbits.RE0       // Location of Second LED

void Initialize_Screen(void); 

void update_Count(char , char );
void update_color(char, char);
void update_RGB(char, char);
void update_misc(void);
void wait_one_second(void);
void wait_one_second_beep(char);

void wait_N_seconds(char, char);
void wait_N_seconds_PED(char, char);
void gen_1khz_sound(void);
void gen_2khz_sound(void);
void turn_off_sound(void);
void delay_ms(int);
unsigned int get_full_ADC(void);
void init_ADC(void);

#define _XTAL_FREQ      8000000         // Set operation for 8 Mhz
#define TMR_CLOCK       _XTAL_FREQ/4    // Timer Clock 2 Mhz
#define COUNT_PER_MS    TMR_CLOCK/1000  // Count per ms = 2000
#define COUNT_SCALED    COUNT_PER_MS/32 // 
    
#define Circle_Size     7               // Size of Circle for Light
#define Circle_Offset   15              // Location of Circle
#define TS_1            1               // Size of Normal Text
#define TS_2            2               // Size of PED Text
#define Count_Offset    10              // Location of Count

#define XTXT            30              // X location of Title Text 
#define XRED            40              // X location of Red Circle
#define XYEL            60              // X location of Yellow Circle
#define XGRN            80              // X location of Green Circle
#define XCNT            100             // X location of Sec Count

#define NS              0               // Number definition of North/South
#define NSLT            1               // Number definition of North/South Left Turn
#define EW              2               // Number definition of East/West
#define EWLT            3               // Number definition of East/West Left Turn
 
#define Color_Off       0               // Number definition of Off Color
#define Color_Red       1               // Number definition of Red Color
#define Color_Green     2               // Number definition of Green Color
#define Color_Yellow    3               // Number definition of Yellow Color

#define NS_Txt_Y        20
#define NS_Cir_Y        NS_Txt_Y + Circle_Offset
#define NS_Count_Y      NS_Txt_Y + Count_Offset
#define NS_Color        ST7735_BLUE 

#define NSLT_Txt_Y      50
#define NSLT_Cir_Y      NSLT_Txt_Y + Circle_Offset
#define NSLT_Count_Y    NSLT_Txt_Y + Count_Offset
#define NSLT_Color      ST7735_MAGENTA

#define EW_Txt_Y        80
#define EW_Cir_Y        EW_Txt_Y + Circle_Offset
#define EW_Count_Y      EW_Txt_Y + Count_Offset
#define EW_Color        ST7735_CYAN

#define EWLT_Txt_Y      110
#define EWLT_Cir_Y      EWLT_Txt_Y + Circle_Offset
#define EWLT_Count_Y    EWLT_Txt_Y + Count_Offset
#define EWLT_Color      ST7735_WHITE

#define PED_NS_Count_Y  30
#define PED_EW_Count_Y  90

#define Switch_Txt_Y    140

#define PED_Count_NS            8
#define PED_Count_EW            9

#include "ST7735_TFT.inc"

char buffer[31];                        // general buffer for display purpose
char *nbr;                              // general pointer used for buffer
char *txt;

char NS_Count[]     = "00";             // text storage for NS Count
char NSLT_Count[]   = "00";             // text storage for NS Left Turn Count
char EW_Count[]     = "00";             // text storage for EW Count
char EWLT_Count[]   = "00";             // text storage for EW Left Turn Count

char PED_NS_Count[] = "00";             // text storage for NS Pedestrian Count
char PED_EW_Count[] = "00";             // text storage for EW Pedestrian Count

char SW_NSPED_Txt[] = "0";              // text storage for NS Pedestrian Switch
char SW_NSLT_Txt[]  = "0";              // text storage for NS Left Turn Switch
char SW_EWPED_Txt[] = "0";              // text storage for EW Pedestrian Switch
char SW_EWLT_Txt[]  = "0";              // text storage for EW Left Turn Switch
char Mode_Txt[]     = "D";              // text storage for Mode Light Sensor

char dir;
char Count;                             // RAM variable for Second Count
char PED_Count;                         // RAM variable for Second Pedestrian Count

char SW_NSPED;                          // RAM variable for NS Pedestrian Switch
char SW_NSLT;                           // RAM variable for NS Left Turn Switch
char SW_EWPED;                          // RAM variable for EW Pedestrian Switch
char SW_EWLT;                           // RAM variable for EW Left Turn Switch
char SW_MODE;                           // RAM variable for Mode Light Sensor

char i;

void putch (char c)
{   
    while (!TRMT);       
    TXREG = c;
}

void init_UART()
{
    OpenUSART (USART_TX_INT_OFF & USART_RX_INT_OFF & USART_ASYNCH_MODE & USART_EIGHT_BIT & USART_CONT_RX & USART_BRGH_HIGH, 25);
    OSCCON = 0x60;
}

void init_ADC()
{
    ADCON0 = 0x01;
    ADCON1 = 0x1B;
    ADCON2 = 0xA2;
}

void main()
{
  init_UART();                              // initialize UART (for debugging purpose)
  init_ADC();                               // initialize ADC port
  OSCCON =0x70;                             // set the processor to run at 8 Mhz
  nRBPU = 0;                                // Enable PORTB internal pull up resistor
  TRISA = 0xFF;                             // Set the PORT directions
  TRISB = 0x00;                             //
  TRISC = 0x10;                             // 
  TRISD = 0x00;                             //
  TRISE = 0x00;                             //
  PORTD = 0x00;                             //
  


  Initialize_Screen();                      // Initialize the TFT screen


  update_color(NS,   Color_Off);            // Turn off all the Lights
  update_color(NSLT, Color_Off);   
  update_color(EW,   Color_Off);    
  update_color(EWLT, Color_Off);  
  update_misc();   
  
  while(TRUE)
  {  
      int tcount = 3;                       // set delay count
      for (dir=0;dir<4;dir++)               // loop to do 4 directions
      {
          update_color  (dir, Color_Red);   // first set Red color
          wait_N_seconds(dir, tcount);      // wait for count seconds
          update_color  (dir, Color_Yellow);// next is Yellow color
          wait_N_seconds(dir, tcount);      // wait for count seconds
          update_color  (dir, Color_Green); // next is Green color
          wait_N_seconds(dir, tcount);      // wait for count seconds
          update_color  (dir, Color_Off);   // turn off color
      }
 
      dir = NS;                             // set North/South direction
      PED_Count = PED_Count_NS;             // set Ped Count
      wait_N_seconds_PED(dir, PED_Count);   // count down PED count with sound
      
      dir = EW;                             // set East/West direction
      PED_Count = PED_Count_EW;             // set Ped Count
      wait_N_seconds_PED(dir, PED_Count);   // count down PED count with sound        

  }
}

void Initialize_Screen()
{
  LCD_Reset();
  TFT_GreenTab_Initialize();
  fillScreen(ST7735_BLACK);
  
  /* TOP HEADER FIELD */
  txt = buffer;
  strcpy(txt, "ECE3301L Spring 2019");  
  drawtext(2, 2, txt, ST7735_WHITE, ST7735_BLACK, TS_1);
  
  /* MODE FIELD */
  strcpy(txt, "Mode:");
  drawtext(2, 10, txt, ST7735_WHITE, ST7735_BLACK, TS_1);
  drawtext(35,10, Mode_Txt, ST7735_WHITE, ST7735_BLACK, TS_1);

  /* SECOND UPDATE FIELD */
  strcpy(txt, "*");
  drawtext(120, 10, txt, ST7735_WHITE, ST7735_BLACK, TS_1);
      
  /* NORTH/SOUTH UPDATE FIELD */
  strcpy(txt, "NORTH/SOUTH");
  drawtext  (XTXT, NS_Txt_Y  , txt, NS_Color, ST7735_BLACK, TS_1);
  drawRect  (XTXT, NS_Cir_Y-8, 60, 18, NS_Color);
  drawCircle(XRED, NS_Cir_Y  , Circle_Size, ST7735_RED);
  drawCircle(XYEL, NS_Cir_Y  , Circle_Size, ST7735_YELLOW);
  fillCircle(XGRN, NS_Cir_Y  , Circle_Size, ST7735_GREEN);
  drawtext  (XCNT, NS_Count_Y, NS_Count, NS_Color, ST7735_BLACK, TS_2);
    
  /* NORTH/SOUTH LEFT TURN UPDATE FIELD */
  strcpy(txt, "N/S LT");
  drawtext  (XTXT, NSLT_Txt_Y, txt, NSLT_Color, ST7735_BLACK, TS_1);
  drawRect  (XTXT, NSLT_Cir_Y-8, 60, 18, NSLT_Color);
  fillCircle(XRED, NSLT_Cir_Y, Circle_Size, ST7735_RED);
  drawCircle(XYEL, NSLT_Cir_Y, Circle_Size, ST7735_YELLOW);
  drawCircle(XGRN, NSLT_Cir_Y, Circle_Size, ST7735_GREEN);  
  drawtext  (XCNT, NSLT_Count_Y, NSLT_Count, NSLT_Color, ST7735_BLACK, TS_2);
  
  /* EAST/WEST UPDATE FIELD */
  strcpy(txt, "EAST/WEST");
  drawtext  (XTXT, EW_Txt_Y, txt, EW_Color, ST7735_BLACK, TS_1);
  drawRect  (XTXT, EW_Cir_Y-8, 60, 18, EW_Color);
  fillCircle(XRED, EW_Cir_Y, Circle_Size, ST7735_RED);
  drawCircle(XYEL, EW_Cir_Y, Circle_Size, ST7735_YELLOW);
  drawCircle(XGRN, EW_Cir_Y, Circle_Size, ST7735_GREEN);  
  drawtext  (XCNT, EW_Count_Y, EW_Count, EW_Color, ST7735_BLACK, TS_2);

  /* EAST/WEST LEFT TURN UPDATE FIELD */
  strcpy(txt, "E/W LT");
  drawtext  (XTXT, EWLT_Txt_Y, txt, EWLT_Color, ST7735_BLACK, TS_1);
  drawRect  (XTXT, EWLT_Cir_Y-8, 60, 18, EWLT_Color);  
  fillCircle(XRED, EWLT_Cir_Y, Circle_Size, ST7735_RED);
  drawCircle(XYEL, EWLT_Cir_Y, Circle_Size, ST7735_YELLOW);
  drawCircle(XGRN, EWLT_Cir_Y, Circle_Size, ST7735_GREEN);   
  drawtext  (XCNT, EWLT_Count_Y, EWLT_Count, EWLT_Color, ST7735_BLACK, TS_2);

  /* NORTH/SOUTH PEDESTRIAM UPDATE FIELD */
  strcpy(txt, "PNS");  
  drawtext(3, NS_Txt_Y, txt, NS_Color, ST7735_BLACK, TS_1);
  drawtext(2, PED_NS_Count_Y, PED_NS_Count, NS_Color, ST7735_BLACK, TS_2);
  
  /* EAST/WEST PEDESTRIAM UPDATE FIELD */  
  drawtext(2, PED_EW_Count_Y, PED_EW_Count, EW_Color, ST7735_BLACK, TS_2);
  strcpy(txt, "PEW");  
  drawtext(3, EW_Txt_Y, txt, EW_Color, ST7735_BLACK, TS_1);
      
  /* MISCELLANEOUS UPDATE FIELD */  
  strcpy(txt, "NSP NSLT EWP EWLT MD");
  drawtext(1,  Switch_Txt_Y, txt, ST7735_WHITE, ST7735_BLACK, TS_1);
  drawtext(6,  Switch_Txt_Y+9, SW_NSPED_Txt, ST7735_WHITE, ST7735_BLACK, TS_1);
  drawtext(32, Switch_Txt_Y+9, SW_NSLT_Txt, ST7735_WHITE, ST7735_BLACK, TS_1);
  drawtext(58, Switch_Txt_Y+9, SW_EWPED_Txt, ST7735_WHITE, ST7735_BLACK, TS_1);
  drawtext(87, Switch_Txt_Y+9, SW_EWLT_Txt, ST7735_WHITE, ST7735_BLACK, TS_1);  
  drawtext(112,Switch_Txt_Y+9, Mode_Txt, ST7735_WHITE, ST7735_BLACK, TS_1);
}

void update_color(char direction, char Color)
{
    char Circle_Y;
    
    update_RGB(direction, Color);
    
    Circle_Y = NS_Cir_Y + direction * 30;    
    
    if (Color == Color_Off)
    {
            fillCircle(XRED, Circle_Y, Circle_Size, ST7735_BLACK);
            fillCircle(XYEL, Circle_Y, Circle_Size, ST7735_BLACK);
            fillCircle(XGRN, Circle_Y, Circle_Size, ST7735_BLACK); 
            drawCircle(XRED, Circle_Y, Circle_Size, ST7735_RED);            
            drawCircle(XYEL, Circle_Y, Circle_Size, ST7735_YELLOW);
            drawCircle(XGRN, Circle_Y, Circle_Size, ST7735_GREEN);                       
    }    
    
    if (Color == Color_Red)
    {
            // put code here
    }
          
    if (Color == Color_Yellow)
    {
           // put code here              
    }
          
    if (Color == Color_Green)
    {
           // put code here                      
    }
         
}

void update_RGB(char direction, char Color)
{
           // put code here         
}
void update_Count(char direction, char count)
{
   switch (direction)
   {
      case NS:       
        NS_Count[0] = count/10  + '0';
        NS_Count[1] = count%10  + '0';
        drawtext(XCNT, NS_Count_Y, NS_Count, NS_Color, ST7735_BLACK, TS_2); 
        break;
      
      case NSLT:      
           // put code here         
        break;
      
      case EW:        
           // put code here         
        break;
            
      case EWLT:       
           // put code here         
        break;
        
    }  
}

void update_PED_Count(char direction, char count)
{
   switch (direction)
   {
      case NS:       
            // put code here         
        break;
        
      case EW:       
           // put code here         
        break;
   }
   
}

void update_misc()
{
    int STEP;
    float Volt;
    SW_NSPED = NS_PED_SW;
    
    // put code here for the other sensors        
    
    
    if (SW_NSPED == 0) SW_NSPED_Txt[0] = '0'; else SW_NSPED_Txt[0] = '1';
    // put code here for the other sensors     
   
    
    drawtext(6,  Switch_Txt_Y+9, SW_NSPED_Txt, ST7735_WHITE, ST7735_BLACK, TS_1);
    // put code here for the other sensors              
}

void wait_one_second()
{
    SEC_LED = 1;
    // put code here 
    SEC_LED = 0;
    // put code here 
    update_misc();
}

void wait_one_second_beep(char direction)
{
    SEC_LED = 1;
    // put code here 
    SEC_LED = 0;
    // put code here 
    update_misc();
}

void wait_N_seconds(char direction, char sec)
{
    int s;
    for (s=sec-1;s>=0;s--)
    {  
       wait_one_second();
       update_Count(direction, s);
    }
}

void wait_N_seconds_PED(char direction, char sec)
{
    int s;
    for (s=sec-1;s>=0;s--)
    {
        wait_one_second_beep(direction);
        update_PED_Count(direction, s);
    }
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

void gen_1khz_sound()
{
    PR2 = 0b11111001 ;
    T2CON = 0b00000101 ;
    CCPR2L = 0b01001010 ;
    CCP2CON = 0b00111100 ;
}

void gen_2khz_sound()
{
    PR2 = 0b01111100 ;
    T2CON = 0b00000101 ;
    CCPR2L = 0b00111110 ;
    CCP2CON = 0b00011100 ;
}

void turn_off_sound()
{
    CCP2CON = 0b0;
    SPKR = 0;

}

unsigned int get_full_ADC(void)
{
int result;
	ADCON0bits.GO=1; 												// Start Conversion
	while(ADCON0bits.DONE==1); 										// wait for conversion to be completed (DONE=0)
	result =((ADRESH*0x100)+ADRESL);								// combine result of upper byte and lower byte into result
	return result; 													// return the result.
}
