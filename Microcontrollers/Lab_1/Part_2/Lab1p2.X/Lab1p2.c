#include <p18f4321.h>
#include <stdio.h>
#include <math.h>
#include <usart.h>

#pragma config OSC = INTIO2
#pragma config WDT = OFF
#pragma config LVP = OFF
#pragma config BOR = OFF

void init_UART()
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
void main(void)
{
    char k;
    float t;
    init_UART();
    while(1)
    {
        t= 19.909;
        printf ("\r\n\nHello World! First Floating Point Print with 1 decimal place t= %6.1f",t);
        printf ("\r\nHello World! First Floating Point print with 2 decimal places t= %6.2f",t);
    }
}