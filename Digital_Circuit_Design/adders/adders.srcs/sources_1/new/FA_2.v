`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/03/2018 11:13:00 AM
// Design Name: 
// Module Name: FA_2
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


module FA_2(
    input x,
    input y,
    input Cin,
    output Sum,
    output Cout
    );
    
    xor G1 (xor_1, x, y);
    and G2 (and_1, x, y);
    xor G3 (Sum, Cin, xor_1);
    and G4 (and_2, Cin, xor_1);
    or G5 (Cout, and_2, and_1);
endmodule
