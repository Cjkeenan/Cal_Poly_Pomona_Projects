#include <P18f4321.h>

#define LED PORTCbits.RC7
#define SW0 PORTDbits.RD6   
#define SW1 PORTDbits.RD7

void main()
{
    TRISC = 0x00;
    TRISD = 0xFF;
    
    while(1)
    {
        LED = ~(SW0^SW1);
    }
}