#include <P18F4321.h>
#include <stdio.h>
#include <math.h>

void putch (char);
void init_UART(void);
unsigned int get_full_ADC(void);

void main()
{
    //Initial Configuration
    OSCCON = 0x60;  //4MHz internal clock
    ADCON0 = 0x01;  //AN0 as channel and enable AD converter
    ADCON1 = 0x0D;  //all digital pins except for AN0
    ADCON2 = 0x8C;  //2 TAD Right justified, with Fosc/4 as conversion clock   
    TRISAbits.RA0 = 1;
    
    unsigned int sample, sample_sq;
    float RMS = 0, RMS_fraction = 0;
    int RMS_int = 0;
    
    while(1)
    {
        int i;
        RMS = 0;
        for(i = 0; i < 128; i++)
        {
            sample = get_full_ADC();
            sample_sq = sample*sample;
            RMS += sample_sq;
        }
        
        RMS = sqrt(RMS);
        RMS /= i;
        
        RMS_int = RMS;
        RMS_fraction = RMS - RMS_int;
    }
}

unsigned int get_full_ADC(void)
{
    int result;
    
    ADCON0bits.GO = 1;                  // Start Conversion
    while(ADCON0bits.DONE == 1);        // wait for conversion to be completed
    result = (ADRESH * 0x100) + ADRESL; // combine result of upper byte and lower byte into result

    return result;                      // return the result.
}