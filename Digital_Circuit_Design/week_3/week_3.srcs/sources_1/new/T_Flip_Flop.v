`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/13/2018 12:56:46 PM
// Design Name: 
// Module Name: T_Flip_Flop
// Project Name: 
// Target Devices: 
// Tool Versions: 
// Description: 
// 
// Dependencies: 
// 
// Revision:
// Revision 0.01 - File Created
// Additional Comments:
// 
//////////////////////////////////////////////////////////////////////////////////


module T_Flip_Flop(
    input T,
    input Clk, 
    output reg Q,
    output reg QBar
    );
   
	 always@(posedge Clk)
	 begin
	   if (T == 1)
	       begin
	             QBar = Q;
                 Q = ~Q;
                 
            end
        else
            begin
                Q = Q;
                QBar = QBar;
            end
	 end
endmodule

