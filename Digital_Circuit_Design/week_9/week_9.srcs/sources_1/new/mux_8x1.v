`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/28/2018 02:41:31 PM
// Design Name: 
// Module Name: mux_8x1
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


module mux_8x1#(parameter bit = 7)(
    input [bit - 1:0] a,
    input [bit - 1:0] b,
    input [bit - 1:0] c,
    input [bit - 1:0] d,
    input [bit - 1:0] e,
    input [bit - 1:0] f,
    input [bit - 1:0] g,
    input [bit - 1:0] h,
    input [2:0] selector,
    output reg [bit - 1:0] out
    );
        
    always@(selector)
    begin
        case(selector)
            0: out = a;
            1: out = b;
            2: out = c;
            3: out = d;
            4: out = e;
            5: out = f;
            6: out = g;
            7: out = h;
        endcase
    end
endmodule

