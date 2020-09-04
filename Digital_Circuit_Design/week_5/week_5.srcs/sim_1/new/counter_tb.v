`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/27/2018 01:52:19 PM
// Design Name: 
// Module Name: counter_tb
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


module counter_tb(

    );
    
    reg clock;
    reg load;
    reg reset;
    reg [5:0] L;
    wire [6:0] seg;
    wire [3:0] seg_anodes;
    
    digital_clock DC1 (.sys_clock(clock), .load(load), .reset(reset), .L(L), .seg_anodes(seg_anodes), .seg(seg));
    
    initial #120 $finish;
    
    initial
    begin 
    clock = 0;
    reset = 0;
    load = 0;
    L = 0;
    end
    
    always
    #0.5 clock = ~clock;
    
endmodule
