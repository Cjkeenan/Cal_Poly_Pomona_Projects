`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/07/2018 12:57:19 AM
// Design Name: 
// Module Name: display_decoder_tb
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


module display_decoder_tb;
    reg [2:0] data;
    wire [6:0] seg;
    wire [7:0] AN;

    display_decoder DD0(.data(data), .seg(seg), .AN(AN));
    
initial #10 $finish; 
    
initial begin
 data=0;
 #1 data=1;
 #1 data=2;
 #1 data=3;
 #1 data=4;
 #1 data=5;
 #1 data=6;
 #1 data=7;
 end
 
endmodule
