`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/08/2018 02:25:30 PM
// Design Name: 
// Module Name: binary_adder4_tb
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


module binary_adder4_tb(

    );
    // Declare local wire, reg identifiers
    reg [3:0] x, y;
    reg Cin;
    wire [3:0] s;
    wire Cout;

    // Instantiate the module under test
    binary_adder4 BA0(.x(x), .y(y), .Cin(Cin), .Sum(s), .Cout(Cout));

    // Stopwatch
    initial #35 $finish;

    // Gnerate stimuli
    initial
    begin
            x = 5; y = 10; Cin =1;
        #10 x = 12; y = 3; Cin = 0;
        #10 x = 2; y = 3; Cin = 0;
    end
endmodule
