`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/08/2018 02:20:49 PM
// Design Name: 
// Module Name: binary_adder4
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


module binary_adder4(
    input [3:0] x,
    input [3:0] y,
    input Cin,
    output [3:0] Sum,
    output Cout
    );
    wire [3:1] c;
    
    FA_1 F0 (x[0], y[0], Cin , Sum[0], c[1]);
    FA_1 F1 (x[1], y[1], c[1], Sum[1], c[2]);
    FA_1 F2 (x[2], y[2], c[2], Sum[2], c[3]);
    FA_1 F3 (x[3], y[3], c[3], Sum[3], Cout);
    
endmodule
