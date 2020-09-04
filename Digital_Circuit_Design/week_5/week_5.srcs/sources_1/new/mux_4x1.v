`timescale 1ns / 1ps

module mux_4x1_7bit(
    input [6:0] a,
    input [6:0] b,
    input [6:0] c,
    input [6:0] d,
    input [1:0] selector,
    output reg [6:0] out
    );
    
    always@(selector)
    begin
        case(selector)
            0: out = a;
            1: out = b;
            2: out = c;
            3: out = d;
        endcase
    end
endmodule