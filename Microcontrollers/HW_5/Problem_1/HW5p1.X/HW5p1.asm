INCLUDE <P18F4321.INC>
WREG EQU 0xFE8
 
ORG 0x100
START:
    ;Initilize Data
    CLRF    0x60    ;Clear parity counter location
    
    ;MOVLW   0x07    ;Odd number
    MOVLW   0x06    ;Even number
    MOVWF   0x70    ;Store number to check in address 0x70
    
    ;Check Parity
    BTFSC   0x70,0  ;Check the number's bit 0, if 1, increment parity counter, if 0, skip increment
    INCF    0x60    ;Parity counter increment
    
    BTFSC   0x70,1  ;Check the number's bit 1, if 1, increment parity counter, if 0, skip increment
    INCF    0x60    ;Parity counter increment
    
    BTFSC   0x70,2  ;Check the number's bit 2, if 1, increment parity counter, if 0, skip increment
    INCF    0x60    ;Parity counter increment
    
    BTFSC   0x70,3  ;Check the number's bit 3, if 1, increment parity counter, if 0, skip increment
    INCF    0x60    ;Parity counter increment
    
    BTFSC   0x70,4  ;Check the number's bit 4, if 1, increment parity counter, if 0, skip increment
    INCF    0x60    ;Parity counter increment
    
    BTFSC   0x70,5  ;Check the number's bit 5, if 1, increment parity counter, if 0, skip increment
    INCF    0x60    ;Parity counter increment
    
    BTFSC   0x70,6  ;Check the number's bit 6, if 1, increment parity counter, if 0, skip increment
    INCF    0x60    ;Parity counter increment
    
    BTFSC   0x70,7  ;Check the number's bit 7, if 1, increment parity counter, if 0, skip increment
    INCF    0x60    ;Parity counter increment
    
CHECK
    BTFSC   0x60,0  ;if 0x60 is even, i.e. bit 0 is set to 0, skip next instruction, i.e. skip odd, execute even
    GOTO    ODD	    ;if Odd functionality
    GOTO    EVEN    ;if Even functionality
	
EVEN
    MOVLW   0xEE    ;Value of an even result
    MOVWF   0x50    ;Move to destination address of 0x50
    GOTO    HERE    ;End program
    
ODD
    MOVLW   0xDD    ;Value of an odd result
    MOVWF   0x50    ;Move to destination address of 0x50
    GOTO    HERE    ;End program

HERE
    BRA	    HERE
END