`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: Digilent Inc.
// Engineers: Michelle Yu
//				  Josh Sackos
// 
// Create Date:    11:38:09 06/12/2012 
// Module Name:    PmodENC 
// Project Name:  PmodENC
// Target Devices: Nexys3
// Tool versions: Xilinx ISE Design Suite 14.1
//
// Description: 
//	This project changes the seven segment display when the position of rotary shaft
// is changed. The number on the seven segment display is relative to the start position.
// When the rotary button is pressed, the program resets. The switch controls whether 
// the seven segment display turns on or off. LED 0 and 1 indicated the direction the 
// rotary shaft is turned. LED 0 is on when the shaft is turned right, LED 1 is on when
// the shaft is turned left.
//
// Revision: 
// Revision 0.01 - File Created
//
//////////////////////////////////////////////////////////////////////////////////
module PmodENC(
    clk,
    JA,
    an,
    seg,
    Led,
    EncO
    );

	 // ===========================================================================
	 // 										Port Declarations
	 // ===========================================================================
    input clk;
    input [7:4] JA;
    output [3:0] an;
    output [6:0] seg;
    output [1:0] Led;

	 // ===========================================================================
	 // 							  Parameters, Regsiters, and Wires
	 // ===========================================================================
	 wire [3:0] an;
	 wire [6:0] seg;
	 wire [1:0] Led;
	 
	 output [4:0] EncO;
	 
	 // ===========================================================================
	 // 										Implementation
	 // ===========================================================================
 	 Debouncer C0_Debouncer (
				  .clk(clk),
				  .Ain(JA[4]),
				  .Bin(JA[5]),
				  .Aout(AO),
				  .Bout(BO)
	 );
	 
 	 Encoder C1_Encoder (
				  .clk(clk),
				  .A(AO),
				  .B(BO),
				  .BTN(JA[6]),
				  .EncOut(EncO),
				  .LED(Led)
	 );

 	 DisplayController C2_DisplayController (
				  .clk(clk),
				  .SWT(JA[7]),
				  .DispVal(EncO),
				  .anode(an),
				  .segOut(seg)
	 );
endmodule
