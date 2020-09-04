`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/03/2018 08:52:36 PM
// Design Name: 
// Module Name: clk_divider_tb
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


module clk_divider_tb(

    );
    
    initial #1000 $finish;
    
    reg sys_clock;
    reg reset;
    wire [26:0] counter;

    initial
    begin 
    sys_clock = 0;
    reset = 0;
    end
    
    always
    #5 sys_clock = ~sys_clock;

    //Clocks Generation
    parameter sys_freq = 100_000_000;
    wire Clk_400Hz = 0;
    parameter freq_400 = 400;
    wire Clk_1Hz = 0;
    parameter freq_1 = 1;
    clock_divider #(freq_400, sys_freq) CLK1(.sys_clk(sys_clock), .resetSW(reset), .new_clock(Clk_400Hz));
    clock_divider #(freq_1, sys_freq)CLK2(.sys_clk(sys_clock), .resetSW(reset), .new_clock(Clk_1Hz));

endmodule
