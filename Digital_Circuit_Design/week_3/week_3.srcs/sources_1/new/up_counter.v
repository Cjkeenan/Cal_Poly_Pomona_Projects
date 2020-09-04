`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/13/2018 01:00:03 PM
// Design Name: 
// Module Name: up_counter
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


module up_counter(
    input sys_clock,
    input reset,
    output [6:0] seg,
    output [7:0] AN
    );
    
    wire [2:0] number;
    wire [2:0] QBar;
    wire slow_clock;
    
    slower_clock_gen clockGen0 (.clk(sys_clock), .resetSW(reset), .outSignal(slow_clock));
    
    assign toggle = 1;
    T_Flip_Flop TFF0 (.T(toggle), .Clk(slow_clock), .Q(number[0]), .QBar(QBar[0]));
    T_Flip_Flop TFF1 (.T(toggle), .Clk(QBar[0]), .Q(number[1]), .QBar(QBar[1]));
    T_Flip_Flop TFF2 (.T(toggle), .Clk(QBar[1]), .Q(number[2]), .QBar(QBar[2]));
    
    display_decoder DD0(.data(number), .seg(seg), .AN(AN));
endmodule
