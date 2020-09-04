INCLUDE <P18F4321.INC>

WREG	EQU 0xFE8
	
Low_Byte	EQU 0x52
High_Byte	EQU 0x53
 
ORG 0x100
Setup
    MOVLW   0x05
    MOVWF   CCP1CON
    
    CLRF    T0CON
    
    BSF	    TRISC, CCP1
    
    BCF	    PIE1, TMR1IE
    BCF	    PIR1, TMR1IF
    
    CLRF    CCPR1H
    CLRF    CCPR1L
    
Loop_1
    BTFSC   PIR1, CCP1IF
    GOTO    Continue_1
    GOTO    Loop_1
    
Continue_1
    MOVFF   CCPR1L, Low_Byte
    MOVFF   CCPR1H, High_Byte
    BSF	    T1CON, TMR1ON
    BCF	    PIR1, CCP1IF
    
Loop_2
    BTFSC   PIR1, CCP1IF
    GOTO    Continue_2
    GOTO    Loop_2
    
Continue_2
    CLRF    CCP1CON
    BCF	    T1CON, TMR1ON
    
Calculation
    MOVF    CCPR1L, 0
    SUBFWB  Low_Byte, 1   
    MOVF    CCPR1H, 0
    SUBFWB  High_Byte, 1
    
HERE
    BRA	HERE
    
END