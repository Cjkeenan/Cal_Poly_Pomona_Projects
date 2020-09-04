INCLUDE <P18F4321.INC>
   
ORG 0x200
START:
    ;Data Initialization
    CLRF    STATUS
    
    ;Value to multiply by 16
    MOVLW   0xFF    ;lower byte of data
    MOVWF   0x20    ;lower byte location
    MOVLW   0x07    ;upper byte of data
    MOVWF   0x21    ;upper byte location
    
    ;Negative Value to check sign
    MOVLW   0xF7    ;lower byte of data
    MOVWF   0x30    ;lower byte location
    MOVLW   0xF1    ;upper byte of data
    MOVWF   0x31    ;upper byte location
    
    ;Positive Value to check sign
    ;MOVLW   0xF7    ;lower byte of data
    ;MOVWF   0x30    ;lower byte location
    ;MOVLW   0x01    ;upper byte of data
    ;MOVWF   0x31    ;upper byte location
    
CHECK
    BTFSC   0x31,7	;Check bit 16 of 16 bit number in 0x30 and 0x31, since little endian, 0x31 stores bit 16 which is bit 8 for 0x31
    GOTO    NEGATIVE	;if bit 16 (8) is 1, this will run
    GOTO    POSITIVE	;if bit 16 (8) is 0, this will run
    
NEGATIVE
    SETF    0x40    ;set address 0x40 to all ones
    GOTO    HERE
    
POSITIVE    
    RLCF    0x20	;double the lower value of the number, rotating through carry
    RLNCF   0x21	;double the upper value of the number, not using carry
    BTFSC   STATUS, C	;check if the status has a carry from the lower value rotation
    BSF	    0x21,0	;carry over the shifting from the lower value into the upper value
    BCF	    STATUS, C	;clear the carry
    
    RLCF    0x20	;double the lower value of the number, rotating through carry
    RLNCF   0x21	;double the upper value of the number, not using carry
    BTFSC   STATUS, C	;check if the status has a carry from the lower value rotation
    BSF	    0x21,0	;carry over the shifting from the lower value into the upper value
    BCF	    STATUS, C	;clear the carry
    
    RLCF    0x20	;double the lower value of the number, rotating through carry
    RLNCF   0x21	;double the upper value of the number, not using carry
    BTFSC   STATUS, C	;check if the status has a carry from the lower value rotation
    BSF	    0x21,0	;carry over the shifting from the lower value into the upper value
    BCF	    STATUS, C	;clear the carry
    
    RLCF    0x20	;double the lower value of the number, rotating through carry
    RLNCF   0x21	;double the upper value of the number, not using carry
    BTFSC   STATUS, C	;check if the status has a carry from the lower value rotation
    BSF	    0x21,0	;carry over the shifting from the lower value into the upper value
    BCF	    STATUS, C	;clear the carry
    
    GOTO    HERE

HERE
    BRA	    HERE
END