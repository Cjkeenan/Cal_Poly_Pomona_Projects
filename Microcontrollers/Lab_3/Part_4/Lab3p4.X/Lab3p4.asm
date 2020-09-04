#include<P18F4321.inc>
    
config OSC = INTIO2
config WDT = OFF
config LVP = OFF
config BOR = OFF
    
Color_PORTC	equ 0x01    ; D1 = PORTC = Red = 100 = 0x04
Color_PORTD	equ 0x07    ; D2 = PORTD = White = 111 = 0x07
Color_Off	equ 0x00    ; Off = 000 = 0x00
	
OUTER_VALUE	equ 0x0A    ; find period of 0xFF in Part 1, T(0xFF)*(20/1000)
INNER_VALUE	equ 0x3D    ; then divide that number into integer parts and represent as Hex
 
ORG 0x0000
 
; CODE STARTS FROM THE NEXT LINE
START:
    MOVLW 0x00 			; Load W with 0x00
    MOVWF TRISC 		; Make PORT C bits 0-7 as outputs
    MOVWF TRISD 		; Make PORT D bits 0-7 as outputs
    
MAIN_LOOP:
    MOVLW Color_PORTC 	; Load W with the desired color for PORTC
    MOVWF 0x22 			; save desired color into register 0x22
    
    MOVLW Color_PORTD 	; Load W with the desired color for PORTD
    MOVWF 0x23 			; save desired color into register 0x23
    
    MOVLW OUTER_VALUE 	; Load OUTER_VALUE into W
    MOVWF 0x24 			; save it to register 0x24
    
    MOVLW INNER_VALUE 	; Load INNER_VALUE into W
    MOVWF 0x25 			; save it to register 0x25
    
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