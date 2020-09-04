INCLUDE <P18F4321.INC>
WREG	EQU 0xFE8
STKPTR	EQU 0xFFC
COUNTER EQU 0x60
RESULT	EQU 0x50
	
ORG 0x100	
START
    CLRF    COUNTER	;Clear counter
    CLRF    RESULT	;Clear result
    MOVLW   D'20'	;put 20 in WREG
    MOVWF   STKPTR	;initialize stack pointer to 0x20
    LFSR    1,0x37	;load FSR1 with 0x37, address of X8
    MOVLW   D'8'	;put 8 in WREG
    MOVWF   COUNTER	;set counter to 8
    
DATA_SET
    MOVWF   POSTDEC1	;copy WREG to what is pointed at by FSR1 then decrement FSR1
    DECF    WREG	;decrement WREG (Value to be copied)
    BNZ	    DATA_SET	;Branch to set value while WREG is not zero
    
    ;Summation Function
    CALL    SUMMATION	;
    
    ;Division Function
    BCF	    STATUS, C	;clear carry
    RRCF    RESULT	;divide by 2
    BCF	    STATUS, C	;Clear carry
    RRCF    RESULT	;divide by 2
    BCF	    STATUS, C	;Clear carry
    RRCF    RESULT	;divide by 2
    BCF	    STATUS, C	;Clear carry
    
    GOTO    HERE	;end program
    
ORG 0x200
;Subroutine
SUMMATION
    MOVFF   PREINC1, WREG   ;Increment FSR1 and then move whatever is pointed to by FSR1 to WREG
    ADDWF   RESULT	    ;Add WREG to result
    DECF    COUNTER	    ;Decrement counter
    BNZ	    SUMMATION	    ;Repeat summation routine until counter is 0
    return		    ;return to main program
    
HERE
    BRA	    HERE
END