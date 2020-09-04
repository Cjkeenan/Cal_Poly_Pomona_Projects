`timescale 1ns / 1ps

module decoder_2x4_low(
    input [1:0] data,
    output reg[3:0] out
    );

    always @(data)
    begin
        out = 4'b1111;
        out[data] = 0;
    end
endmodule