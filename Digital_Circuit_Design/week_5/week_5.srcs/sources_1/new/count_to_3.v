`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/27/2018 03:29:28 PM
// Design Name: 
// Module Name: count_to_3
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


module count_to_3(
    input clock,
    output reg [1:0] count
    );

    always@ (posedge clock)
            count <= count + 1;
    
endmodule
