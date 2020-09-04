`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/28/2018 02:54:20 PM
// Design Name: 
// Module Name: decoder_3x8_low
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


module decoder_3x8_low(
    input [2:0] data,
    output reg [7:0] out 
    );
    
    always @(data)
    begin
        out = 8'b1111_1111;
        out[data] = 0;
    end
    
endmodule
