#include <p18f4321.h>
//PORTD bits 0 and 1 are switch inputs to control duty cycle of motor
    //00 - 50% DC
    //11 - 75% DC
//PORTC CCP1 output PWM signal to Optocoupler to amplify signal for dc motor
//T = Period = PR2 = 249 = 0xF9


void main(void)
{
    //PORTD bits 0,1 input
    TRISDbits.TRISD0 = 1;
    TRISDbits.TRISD1 = 1;
    
    //PORTC CCP1 output
    TRISC = 0;
    
    //Configure CCP1CON and T2CON
    CCP1CON = 0x0C;
    T2CON = 0x00;
    TMR2 = 0;
    
    //PR2 setup
    PR2 = 249;
    
    //TMR2 ON
    T2CONbits.TMR2ON = 1;
    
    int integer_DC, fractional_DC;
    float intended_DC, actual_DC;
    while(1)
    {
        switch(PORTD)
        {
            case 0:
                intended_DC = .5;
                break;
            case 3:
                intended_DC = .75;
                break;
            default:
                T2CONbits.TMR2ON = 0;
        }
        actual_DC = intended_DC * PR2;
        integer_DC = actual_DC;
        fractional_DC = 100*(actual_DC - integer_DC);

        //set Duty Cycles
        CCPR1L = integer_DC;
        switch(fractional_DC)
        {
            case 0:
                CCP1CONbits.DC1B0 = 0;
                CCP1CONbits.DC1B1 = 0;
                break;
            case 25:
                CCP1CONbits.DC1B0 = 1;
                CCP1CONbits.DC1B1 = 0;
                break;
            case 50:
                CCP1CONbits.DC1B0 = 0;
                CCP1CONbits.DC1B1 = 1;
                break;
            case 75:
                CCP1CONbits.DC1B0 = 1;
                CCP1CONbits.DC1B1 = 1;
                break;
        }
        
    }
}