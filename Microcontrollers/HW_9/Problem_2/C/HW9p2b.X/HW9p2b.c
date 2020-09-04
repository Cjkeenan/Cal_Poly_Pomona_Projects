#include <P18F4321.h>
#include <stdio.h>

void putch (char);
void init_UART(void);

void main()
{
    init_UART();
    
    unsigned int First_CCPR1L = 0;
    unsigned int First_CCPR1H = 0;
    unsigned int Low_Byte = 0;
    unsigned int High_Byte = 0;
    
    //Configure CCP1CON
    CCP1CON = 0x05;         //capture mode every rising edge
    
    //Configure Timer 1 with 1:1 prescale
    T0CON = 0x00;           //1:1 prescaler
    T0CONbits.T08BIT = 0;   //16-bit timer
    
    //Port C bit 2 as input
    TRISC = 0xFF;

    //Configure Timer 1
    PIE1bits.TMR1IE = 0;    //Disable Timer 1 interrupt
    PIR1bits.TMR1IF = 0;    //Clear Timer 1 flag
    
    //Clear CCPR1
    CCPR1H = 0x00;
    CCPR1L = 0x00;
    
    while(1)
    {
        CCP1CON = 0x05;         //capture mode every rising edge
        while(PIR1bits.CCP1IF == 0);    //wait until flag is set
        First_CCPR1L = CCPR1L;  //store initial low byte
        First_CCPR1H = CCPR1H;  //store initial high byte
        T1CONbits.TMR1ON = 1;   //turn on timer
        PIR1bits.CCP1IF = 0;    //clear flag

        while(PIR1bits.CCP1IF == 0);    //wait until flag is set
        CCP1CON = 0x00;         //turn off CCP module capture mode
        T1CONbits.TMR1ON = 0;   //turn off timer
        Low_Byte = CCPR1L - First_CCPR1L;
        High_Byte = CCPR1H - First_CCPR1H;

        printf("High_Byte = %d\n ", High_Byte);
        printf("Low_Byte = %d\n", Low_Byte);
    }
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