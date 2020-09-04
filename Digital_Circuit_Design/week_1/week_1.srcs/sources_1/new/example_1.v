`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 08/30/2018 02:23:40 PM
// Design Name: 
// Module Name: example_1
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


module example_1(
    input x1,
    input x2,
    input x3,
    output f
    );
    //Structural
    //and (g, x1, x2);
    //or (k, x2);
    //and (h, k, x3);
    //or (f, h, g);
    
    //Behavioural
    assign f = (x1 & x2)|(~x2 & x3);
endmodule
