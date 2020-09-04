`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/25/2018 03:17:05 PM
// Design Name: 
// Module Name: digital_clock
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


module digital_clock(
    input sys_clock,
    input [5:0] L_sec,
    input [5:0] L_min,
    input load_clock,
    input reset,
    output [6:0] clock_sec_ones,
    output [6:0] clock_sec_tens,
    output [6:0] clock_min_ones,
    output [6:0] clock_min_tens,
    output [5:0] clock_sec,
    output [5:0] clock_min
    );
    
    //Clocks Generation
    parameter sys_freq = 100_000_000;
    wire Clk_1Hz;
    parameter freq_1 = 1;
    clock_divider #(freq_1, sys_freq) clock_1hz(.sys_clock(sys_clock), .reset(reset), .new_clock(Clk_1Hz));
    
    //Time Counter Generation                 
    wire minute_increment;
    wire hour_increment;
    count_to_59 second_counter(.clock(Clk_1Hz), .reset(reset), .load(load_clock), .L(L_sec), .count(clock_sec), .carry(minute_increment));
    count_to_59 minute_counter(.clock(minute_increment), .reset(reset), .load(load_clock), .L(L_min), .count(clock_min), .carry(hour_increment)); 
    
    //Clock Display-Decoding
    display_decoder_6_bit decoder_clock_seconds(.count(clock_sec), .tens_display(clock_sec_tens), .ones_display(clock_sec_ones));
    display_decoder_6_bit decoder_clock_minutes(.count(clock_min), .tens_display(clock_min_tens), .ones_display(clock_min_ones));
     
endmodule
