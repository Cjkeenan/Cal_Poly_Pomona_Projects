`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/03/2018 08:36:58 PM
// Design Name: 
// Module Name: digital_clock_tb
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


module digital_clock_tb(

    );
    
    
    initial #1000 $finish;
    
    
    reg sys_clock;
    reg load;
    reg [5:0] L;
    reg reset;
    wire [3:0] seg_anodes;
    wire [6:0] seg;

    initial
    begin 
    sys_clock = 0;
    reset = 0;
    load = 0;
    L = 0;
    end
    
    always
    #5 sys_clock = ~sys_clock;
    
    digital_clock DC1 (.sys_clock(sys_clock), .load(load), .L(L), .reset(reset), .seg_anodes(seg_anodes), .seg(seg));
    endmodule
