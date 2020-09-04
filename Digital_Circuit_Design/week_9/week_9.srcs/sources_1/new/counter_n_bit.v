`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/25/2018 12:55:36 PM
// Design Name: 
// Module Name: counter_2bit
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


module counter_n_bit #(parameter n = 2)(
    input clock,
    output reg [n-1:0] count
    );

    always@ (posedge clock)
            count <= count + 1;
    
endmodule
