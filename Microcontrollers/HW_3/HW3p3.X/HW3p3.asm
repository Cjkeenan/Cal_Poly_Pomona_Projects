INCLUDE <P18F4321.INC>
ORG 0x00

		MOVLW   D'80'	    ;Number of bytes to be set
		MOVWF   0x80	    ;Store counter outside the range of loop to be set
		LFSR    0,0x0000    ;Start setting at address 0, i.e. set LFSR0 to 0 intitially
    
REPEAT_SET	SETF	POSTINC0    ;Set value to 1 at address denoted by LFSR0, then increment LFSR0 after
		DECF	0x80,F	    ;Decrement counter
		BNZ	REPEAT_SET  ;Repeat until the counter reaches zero
		
		MOVLW   D'50'	    ;Number of bytes to be cleared
		MOVWF   0x80	    ;Store counter outside the range of loop to be cleared
		LFSR    1,0x0009    ;Start setting at address 9, i.e. set LFSR1 to 9 intitially, since the clearing involves preincrement, and we want to start clearing at address 10
    
REPEAT_CLEAR	INCF	PREINC1	    ;Set value to 0 at address denoted by LFSR0, then increment LFSR0 after
		DECF	0x80,F	    ;Decrement counter
		BNZ	REPEAT_CLEAR;Repeat until the counter reaches zero
    
HERE     BRA HERE
END