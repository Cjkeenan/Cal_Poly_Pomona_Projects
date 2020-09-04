INCLUDE <P18F4321.INC>
WREG EQU 0xFE8
 
ORG 0x50
    MOVLW   0x0F    ;load 0F into WREG
    MOVWF   0x40    ;load 0F into address 0x40 so that change can be detected
    MOVLW   0x02    ;Value of WREG that is being checked
    
CHECK
    BTFSC   WREG,0  ;if WREG is even, i.e. bit 0 is set to 0, skip next instruction, i.e. skip odd, execute even
    GOTO    ODD	    ;if Odd functionality
    GOTO    EVEN    ;if Even functionality
	
EVEN
    CLRF    0x40    ;Clear register to all zeros
    GOTO    HERE    ;End program
    
ODD
    SETF    0x40    ;Set register to all ones
    GOTO    HERE    ;End program

HERE
    BRA	    HERE
END