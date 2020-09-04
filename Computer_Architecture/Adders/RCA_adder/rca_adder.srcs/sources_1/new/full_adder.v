`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/21/2019 12:19:30 PM
// Design Name: 
// Module Name: full_adder
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


module full_adder(
    input x,y,carry_in,
    output sum,carry_out
    );
    
    assign sum = (x^y) ^ carry_in;
    assign carry_out = (y&carry_in) | (x&y) | (x&carry_in);
    
endmodule
