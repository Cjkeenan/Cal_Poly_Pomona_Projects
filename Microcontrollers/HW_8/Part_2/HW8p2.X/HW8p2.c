#include <P18F4321.h>
//D0-D3 ones digit output
//C0-C3 tens digit output
//INT2 number decrement with low priority
//INT1 number increment with high priority

void interrupt high_priority Increment_ISR(void);
void interrupt low_priority Decrement_ISR(void);
void split_digits(void);

int number = 0;
int tens = 0;
int ones = 0;

void main()
{
    //Configure Clock Speed
    OSCCON = 0x70;   //4MHz internal clock
    
    //Configure IO
    TRISD = 0x00;   //PORTD output
    TRISC = 0x00;   //PORTC output
    
    //Configure Interrupts
    RCONbits.IPEN = 1;      //enable priorities
    INTCONbits.GIEH = 1;    //enable high priorities
    INTCONbits.GIEL = 1;    //enable low priorities
    INTCON3bits.INT1IP = 1; //INT1 high priority
    INTCON3bits.INT2IP = 0; //INT2 low priority
    ADCON1 = 0x0F;          //Digital Input for Interrupts
    
    //Clear Flags
    INTCON3bits.INT1IF = 0;
    INTCON3bits.INT2IF = 0;
    
    //Enable Interrupts
    INTCON3bits.INT1IE = 1;
    INTCON3bits.INT2IE = 1;
    
    //Wait for interrupt
    while(1);
}

void split_digits(void)
{
    if(number > 99) number = 0; //deal with number over 2 digits
    if(number < 0)  number = 99;//deal with negative number
    
    tens = (int) number / 10;   //generate number in tens place
    ones = (int) number % 10;   //generate number in ones place

    PORTD = ones;               //output ones to PORTD
    PORTC = tens;               //output tens to PORTC
}

void interrupt high_priority Increment_ISR(void)
{
    INTCON3bits.INT1IF = 0; //clear flag
    number++;               //increment number
    split_digits();         //output numbers
}

void interrupt low_priority Decrement_ISR(void)
{
    INTCON3bits.INT2IF = 0; //clear flag
    number--;               //Decrement number
    split_digits();         //output numbers
}