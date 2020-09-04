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

#define _XTAL_FREQ 8000000

#define CH_DN       0x00ffa25d
#define CH_UP       0x00ffe21d
#define Plus        0x00ffa857
#define Minus       0x00ffe01f
#define Prev        0x00ff22dd
#define Next        0x00ff02fd

void TIMER1_isr(void);
void INT2_isr(void);
unsigned char nec_state = 0;
unsigned char i;
short nec_ok = 0;
short bit_count = 0;
unsigned long long nec_code;

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
    OSCCON = 0x70;
}

void interrupt high_priority chkisr()
{
    if (PIR1bits.TMR1IF == 1) TIMER1_isr();
    if (INTCON3bits.INT2IF == 1) INT2_isr();
}

void TIMER1_isr(void)
{
    nec_state = 0; // Reset decoding process
    INTCON2bits.INTEDG2 = 0; // Edge programming for INT2 falling edge
    T1CONbits.TMR1ON = 0; // Disable T1 Timer
    PIR1bits.TMR1IF = 0; // Clear interrupt flag
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
                nec_state = 0;
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
                nec_state = 0;
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
                nec_state = 0;
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
                nec_state = 0;
            }
            return;
    }
}

void main()
{
    init_UART();
    OSCCON = 0x70; // 8 Mhz
    nRBPU = 0; // Enable PORTB internal pull up resistor
    TRISA = 0x01;
    TRISB = 0x07;
    TRISC = 0x01; //
    TRISD = 0x00;
    TRISE = 0x00;
    ADCON1 = 0x0F; //
    
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
    
    while(1)
    {
        //printf("NEC_Code = %08lx \r\n", nec_code);
        //nec_ok = 1;
        if (nec_ok == 1)
        {
            nec_ok = 0;
            printf ("NEC_Code = %08lx \r\n", nec_code);
            INTCON3bits.INT2IE = 1; // Enable external interrupt
            INTCON2bits.INTEDG2 = 0; // Edge programming for INT2 falling edge
        }
    }
}