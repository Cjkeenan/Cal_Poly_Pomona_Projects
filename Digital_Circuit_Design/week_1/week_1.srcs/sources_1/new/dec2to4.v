`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 08/30/2018 02:58:12 PM
// Design Name: 
// Module Name: dec2to4
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


module dec2to4(
    input [1:0] W,
    output reg [0:3] Y,
    input En
    );
    integer k;
    
    always @(W, En)
        for(k=0; k <= 3; k = k + 1)
        if((W==k)&&(En==1))
            Y[k] = 1;
        else
            Y[k] = 0;
endmodule
