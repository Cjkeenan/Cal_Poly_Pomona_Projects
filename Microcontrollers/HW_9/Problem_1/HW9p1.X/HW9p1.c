#include <P18F4321.h>
#include <stdio.h>

int seconds = 0;
int minutes = 0;
int hours = 0;

void interrupt high_priority seconds_ISR(void);
void update_time(void);
void putch (char);
void init_UART(void);

void main()
{
    init_UART();
    
    //Configure Clock Speed
    OSCCON = 0x70;   //8MHz internal clock
    
    //Configure Timer 1 with 128 prescaler
    T0CON = 0x06;           //128 prescaler
    T0CONbits.T08BIT = 0;   //16-bit timer

    //Configure Interrupts
    INTCONbits.GIE = 1;     //global interrupt enable
    INTCONbits.PEIE = 1;    //Peripheral interrupt enable
    INTCONbits.TMR0IE = 1;  //TMR0 Interrupt enable
    
    //Load timer 1 with necessary count for 1s of delay
    TMR0H = 0xC2;
    TMR0L = 0xF7;
    
    T0CONbits.TMR0ON = 1;   //turn on timer
    
    //Initialize clock
    hours = 23;
    minutes = 59;
    seconds = 50;
    
    while(1);       //wait for interrupt
}
    
void interrupt high_priority second_ISR(void)
{
    INTCONbits.TMR0IF = 0;
    seconds++;
    
    //reload timer
    TMR0H = 0xC2;
    TMR0L = 0xF7;
    
    update_time();
}

void update_time(void)
{
    //check if minutes should increment
    if(seconds >= 60)
    {
        seconds = 0;
        minutes++;
    }

    //check if hours should increment
    if( minutes >= 60)
    {
        minutes = 0;
        hours++;
    }

    //do not allow for more than 24 hours
    hours = hours % 24;
    
    printf("%02d : %02d : %02d\n", hours, minutes, seconds);
}

void putch (char c)
{
    while (!TRMT);
    TXREG = c;
}

void init_UART(void)
{
    OpenUSART (USART_TX_INT_OFF & USART_RX_INT_OFF &
    USART_ASYNCH_MODE & USART_EIGHT_BIT & USART_CONT_RX &
    USART_BRGH_HIGH, 25);
}