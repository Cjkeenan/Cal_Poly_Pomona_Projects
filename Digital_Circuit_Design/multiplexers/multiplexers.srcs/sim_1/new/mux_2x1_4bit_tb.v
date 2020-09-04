`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/15/2018 02:53:13 PM
// Design Name: 
// Module Name: mux_2x1_4bit_tb
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


module mux_2x1_4bit_tb(
    );

    // Declare local wire and reg identifiers
    reg [3:0] x;
    reg [3:0] y;
    reg  s;
    wire [3:0] f;

    // Instantiate the module under test
    mux_2x1_4bit M0(.x(x), .y(y), .s(s), .f(f));

    // Specify a stopwatch
    initial #5 $finish;

    // Generate stimuli
    initial
    begin
           s = 0; x = 4'b1010; y = 4'b1111;
        #1 s = 1; x = 4'b0101; y = 4'b0000;
        #1 s = 1; x = 4'b1010; y = 4'b1111;
        #1 s = 0; x = 4'b0101; y = 4'b0000;

    end
endmodule
