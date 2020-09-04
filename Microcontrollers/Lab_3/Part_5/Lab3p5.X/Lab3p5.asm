#include<P18F4321.inc>
    
config OSC = INTIO2
config WDT = OFF
config LVP = OFF
config BOR = OFF
    
Color_PORTC	equ 0x04    ; D1 = PORTC = Red = 100 = 0x04
Color_PORTD	equ 0x07    ; D2 = PORTD = White = 111 = 0x07
Color_Off	equ 0x00    ; Off = 000 = 0x00
	
OUTER_VALUE	equ 0x06    ; Tune these value in order to get the desired period for the flashing of the LEDs
INNER_VALUE	equ 0x67    ; Make sure that OUTER_VALUE is small as it tends to overflow due to multiplication
						; In this case this gives a 20ms base flashing value
 
ORG 0x0000
 
; CODE STARTS FROM THE NEXT LINE
START:
	; set PORTC and PORTD as output
    MOVLW 0x00 			; Load W with 0x00
    MOVWF TRISC 		; Make PORTC as all output
    MOVWF TRISD 		; Make PORTD as all output
    
    ; set PORTB as input
    MOVLW 0xFF 			; Load W with 0xFF
    MOVWF TRISB 		; Set PORTB as all inputs
    
    MOVLW 0xFF 			; Load W with 0xFF
    MOVWF ADCON1 		; Make ADCON1 to be all digital
    
MAIN_LOOP:
    BTFSC PORTB, 1		; If bit 1 of PORTB is 0 then PBB1EQ1 will get skipped and PBB1EQ0 (Port_B_Bit_1_Equalto_0) Label is started
    GOTO PBB1EQ1		; If bit 1 of PORTB is 1 then PBB1EQ1 will not get skipped and PBB1EQ1 (Port_B_Bit_1_Equalto_1) Label is started
    GOTO PBB1EQ0		; Port_B_Bit_1_Equalto_0
    
    MOVLW OUTER_VALUE	; Load OUTER_VALUE into W
    MOVWF 0x24			; save it o register 0x24
    
    MOVLW INNER_VALUE	; Load INNER_VALUE into W
    MOVWF 0x25			; save it to register 0x25
    
PBB1EQ1:
    BTFSC PORTB, 0		; If bit 0 of PORTB is 0 then WHITE will get skipped and BLUE Label is started
    GOTO WHITE			; If bit 0 of PORTB is 1 then WHITE will not get skipped and WHITE Label is started
    GOTO BLUE			; BLUE Color Label

PBB1EQ0:
    BTFSC PORTB, 0		; If bit 0 of PORTB is 0 then GREEN will get skipped and RED Label is started
    GOTO GREEN			; If bit 0 of PORTB is 1 then GREEN will not get skipped and GREEN Label is started
    GOTO RED			; RED color lab
    
WHITE:
    MOVLW 0x07				; Load 0x07 or 111 into W, this is the RGB code for white
    MOVWF 0x22				; Save white color value into register 0x22 (D1's register)
    
    MOVLW 0x07				; Load 0x07 or 111 into W, this is the RGB code for white
    MOVWF 0x23				; Save white color value into register 0x22 (D2's register)
    
    MOVLW OUTER_VALUE * 8	; Load 8 times the delay of the outer value delay into W
    MOVWF 0x24				; Save W into register 0x24
    
    MOVLW INNER_VALUE		; Load the delay of the inner value delay into W
    MOVWF 0x25				; Save W into register 0x25
    
    GOTO COLOR_LOOP			; Initiate Color loop using the above parameters
    
BLUE:
    MOVLW 0x04				; Load 0x04 or 100 into W, this is the RGB code for blue
    MOVWF 0x22				; Save blue color value into register 0x22 (D1's register)
    
    MOVLW 0x07				; Load 0x07 or 111 into W, this is the RGB code for white
    MOVWF 0x23				; Save white color value into register 0x22 (D2's register)
    
    MOVLW OUTER_VALUE * 4	; Load 4 times the delay of the outer value delay into W
    MOVWF 0x24				; Save W into register 0x24
    
    MOVLW INNER_VALUE		; Load  the delay of the inner value delay into W
    MOVWF 0x25				; Save W into register 0x25
    
    GOTO COLOR_LOOP			; Initiate Color loop using the above parameters
    
RED:
    MOVLW 0x01				; Load 0x01 or 001 into W, this is the RGB code for red
    MOVWF 0x22				; Save red color value into register 0x22 (D1's register)
    
    MOVLW 0x07				; Load 0x07 or 111 into W, this is the RGB code for white
    MOVWF 0x23				; Save white color value into register 0x22 (D2's register)
    
    MOVLW OUTER_VALUE		; Load the delay of the outer value delay into W
    MOVWF 0x24				; Save W into register 0x24
    
    MOVLW INNER_VALUE		; Load  the delay of the inner value delay into W
    MOVWF 0x25				; Save W into register 0x25
    
    GOTO COLOR_LOOP			; Initiate Color loop using the above parameters
    
GREEN:
    MOVLW 0x02				; Load 0x02 or 010 into W, this is the RGB code for green
    MOVWF 0x22				; Save green color value into register 0x22 (D1's register)
    
    MOVLW 0x07				; Load 0x07 or 111 into W, this is the RGB code for white
    MOVWF 0x23				; Save white color value into register 0x22 (D2's register)
    
    MOVLW OUTER_VALUE * 2	; Load 2 times the delay of the outer value delay into W
    MOVWF 0x24				; Save W into register 0x24
    
    MOVLW INNER_VALUE		; Load  the delay of the inner value delay into W
    MOVWF 0x25				; Save W into register 0x25
    
    GOTO COLOR_LOOP			; Initiate Color loop using the above parameters
    
COLOR_LOOP:
    MOVFF 0x22,PORTC 	; Get saved color of PORTC and output to that Port
    MOVFF 0x23,PORTD 	; Get saved color of PORTD and output to that Port
    MOVFF 0x24,0x21 	; Copy saved outer loop cnt from 0x24 to 0x21
    
    
; NESTED DELAY LOOP TO HAVE THE FIRST HALF OF WAVEFORM
LOOP_OUTER_1:
    NOP 				; Do nothing
    MOVFF 0x25,0x20 	; Load saved inner loop cnt from 0x25 to 0x20
    
LOOP_INNER_1:
    NOP 				; Do nothing
    DECF 0x20,F 		; Decrement memory location 0x20
    BNZ LOOP_INNER_1 	; If value not zero, go back to LOOP_INNER_1
    
    DECF 0x21,F 		; Decrement memory location 0x21
    BNZ LOOP_OUTER_1 	; If value not zero, go back to LOOP_OUTER_1
    
    MOVLW Color_Off 	; Load W with the second desired color
    MOVWF PORTC 		; Output to PORT C to turn off the RGB LED D1
    MOVWF PORTD 		; Output to PORT D to turn off the RGB LED D2
    MOVFF 0x24,0x21 	; Copy saved outer loop cnt from 0x24 to 0x21
    
    
; NESTED DELAY LOOP TO HAVE THE FIRST HALF OF WAVEFORM BEING LOW
LOOP_OUTER_2:
    NOP 				; Do nothing
    MOVFF 0x25,0x20 	; Load saved inner loop cnt from 0x25 to 0x20
    
LOOP_INNER_2:
    NOP 				; Do nothing
    DECF 0x20,F 		; Decrement memory location 0x20
    BNZ LOOP_INNER_2 	; If value not zero, go back to LOOP_INNER_2
    
    DECF 0x21,F 		; Decrement memory location 0x21
    BNZ LOOP_OUTER_2 	; If value not zero, go back to LOOP_OUTER_2
    
    
    ; START ALL OVER AGAIN
    GOTO MAIN_LOOP 		; Go back to main loop
END