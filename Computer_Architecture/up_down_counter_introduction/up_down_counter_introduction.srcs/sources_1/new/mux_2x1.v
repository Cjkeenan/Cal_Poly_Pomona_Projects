`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/13/2019 06:36:32 PM
// Design Name: 
// Module Name: mux_2x1
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

module mux_2x1(
    input a,
    input b,
    input selector,
    output out
    );

    wire p0, p1;

    assign out = p0 | p1;
    assign p0 = a & ~selector;
    assign p1 = b & selector;
endmodule