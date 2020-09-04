`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/15/2018 02:39:50 PM
// Design Name: 
// Module Name: mux_4x1_hierarchical
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


module mux_4x1_hierarchical(
    input [3:0] x,
    input [1:0] s,
    output f
    );

    wire w0, w1;

    // Hierarchical verilog code using different sub modules
    mux_2x1_struct      M0(x[0], x[1], s[0], w0);
    mux_2x1_dataflow    M1(x[2], x[3], s[0], w1);
    mux_2x1_behav       M2(w0, w1, s[1], f);

endmodule