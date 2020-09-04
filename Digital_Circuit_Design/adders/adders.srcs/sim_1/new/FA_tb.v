`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/08/2018 02:16:05 PM
// Design Name: 
// Module Name: FA_tb
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


module FA_tb(

    );
    // Declare local reg and wire identifiers
    reg x, y, Cin;
    wire s, Cout;

    // Instantiate the module under test
    FA_1 A0(.x(x), .y(y), .Cin(Cin), .Sum(s), .Cout(Cout));

    // Specify a stopwatch to stop the simulation
    initial #80 $finish;

    // Generate stimuli, using initial and always
    initial
    begin
            Cin = 0; y = 0; x = 0;
        #10 Cin = 0; y = 0; x = 1;
        #10 Cin = 0; y = 1; x = 0;
        #10 Cin = 0; y = 1; x = 1;
        #10 Cin = 1; y = 0; x = 0;
        #10 Cin = 1; y = 0; x = 1;
        #10 Cin = 1; y = 1; x = 0;
        #10 Cin = 1; y = 1; x = 1;
    end

    // Display the output response (text or graphics (or both))
    // This can be skipped if only reading timing diagrams
    initial
    begin
        $display("time \t|Cin \t|y \t|x \t||s \t|Cin \t");
        $monitor("%0d \t|%b \t|%b \t|%b \t||%b \t|%b \t", $time, Cin, y, x,s, Cin);
    end
endmodule
