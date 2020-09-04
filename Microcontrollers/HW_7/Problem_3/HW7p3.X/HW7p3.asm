INCLUDE <P18F4321.INC>

WREG	EQU 0xFE8
PORTC	EQU 0xF82
PORTD	EQU 0xF83
	
C0	EQU 0x50
C1	EQU 0x51
C2	EQU 0x52
 
ORG 0x100
START:
    SETF    TRISC	;set PORTC as input
    CLRF    TRISD	;set PORTD as output

POLL
    ;if all switches low or if number of high switches is even is equivalent to the zeroes when 3 input bits are XORed
    ;PORTC bit 0
    MOVLW   0x01    ;mask bit 0
    ANDWF   PORTC,0 ;
    MOVWF   C0	    ;store value of port c bit 0
    
    ;PORTC bit 1
    MOVLW   0x02    ;mask bit 1
    ANDWF   PORTC,0 ;
    MOVWF   C1	    ;store value of port c bit 1
    RRNCF   C1	    ;shift into place of bit 0
    
    ;PORTC bit 2
    MOVLW   0x04    ;mask bit 2
    ANDWF   PORTC,0 ;
    MOVWF   C2	    ;store value of port c bit 2
    RRNCF   C2	    ;shift into place of bit 1
    RRNCF   C2	    ;shift into place of bit 0
    
    ;Do XOR
    MOVF    C2,W    ;Move Port C bit 2 into WREG
    XORWF   C1,0    ;XOR bit 1 with WREG (bit 2) and store result in WREG
    XORWF   C0,0    ;XOR bit 0 with WREG (bit 1 XOR bit 2) and store in WREG
    
    ;Check result of XOR
    BTFSC   WREG,0  ;Check bit 0 of WREG for result of XORs
    GOTO    LED_OFF ;if result of XOR is 1, LED will turn off
    GOTO    LED_ON  ;if result of XOR is 0, LED will turn on
    
LED_ON
    BSF	    PORTD,6
    GOTO    POLL
    
LED_OFF
    BCF	    PORTD,6
    GOTO    POLL
    
HERE
    BRA	HERE
    
END