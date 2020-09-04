INCLUDE <P18F4321.INC>
ADC_RESULT	EQU	0x34
INT_RESULT	EQU	0x30
FRAC_RESULT	EQU	0x31

ORG 0x100
    
    ;Configure ADCONs
    MOVLW   0x01
    MOVWF   ADCON0
    MOVLW   0x0D
    MOVWF   ADCON1
    MOVLW   0x29
    MOVWF   ADCON2
    
    ;Configure Inputs and Outputs
    CLRF    TRISC
    CLRF    PORTC
    CLRF    TRISD
    CLRF    PORTD
    
    BSF	    ADCON0, GO
    
ADCON_WAIT
    BTFSC   ADCON0, DONE
    GOTO    ADCON_WAIT
    GOTO    CONTINUE_1
    
CONTINUE_1
    MOVFF   ADRESH, ADC_RESULT
    CLRF    INT_RESULT
    CLRF    FRAC_RESULT
    
DIVISION_1    ;Now calculate integer and remainder
    MOVLW   D'51'    ;divisor which is 51
    SUBWF   ADC_RESULT, 1
    INCF    INT_RESULT, 1
    BN	    DIVISION_1_DONE
    GOTO    DIVISION_1
  
DIVISION_1_DONE
    ADDWF   ADC_RESULT, 1   ;remainder
    MOVFF   INT_RESULT, PORTC
    
DIVISION_2    ;Now calculate fraction, which is 1/5 of remainder
    MOVLW   D'5'    ;divisor which is 5, i.e. 51/10
    SUBWF   ADC_RESULT, 1
    INCF    FRAC_RESULT, 1
    BN	    DIVISION_2_DONE
    GOTO    DIVISION_2
  
DIVISION_2_DONE
    ADDWF   ADC_RESULT, 1
    MOVFF   FRAC_RESULT, PORTD
END