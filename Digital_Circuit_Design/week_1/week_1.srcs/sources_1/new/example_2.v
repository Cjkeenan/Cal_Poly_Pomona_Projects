`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 08/30/2018 02:36:37 PM
// Design Name: 
// Module Name: example_2
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


module example_2(
    input x1,
    input x2,
    input x3,
    input x4,
    output f,
    output g,
    output h
    );
    
    //Structural
    and (z1, x1, x3);
    and (z2, x2, x4);
    or (z3, x1, ~x2);
    or (z4, ~x3, x4);
    or (g, z1, z2);
    and (h, z3, z4);
    or (f, g, h);
endmodule
