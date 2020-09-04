`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/03/2018 11:13:00 AM
// Design Name: 
// Module Name: FA_1
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


module FA_1(
    input x,
    input y,
    input Cin,
    output Sum,
    output Cout
    );
    
    HA A1 (x, y, Sum1, Cout1);
    HA A2 (Cin, Sum1, Sum, Cout2);
    or G1 (Cout, Cout1, Cout2);
endmodule
