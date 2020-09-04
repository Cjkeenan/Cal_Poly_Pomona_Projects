`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/27/2018 01:17:07 PM
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
// Additional Comments: Accelerate Clock not working, but is still intitialized and in constraints file.
// 
//////////////////////////////////////////////////////////////////////////////////


module digital_clock(
    input sys_clock,
    input load_sec,
    input load_min,
    input [5:0] L_sec,
    input [5:0] L_min,
    input reset,
    input accelerate_clock,
    //input slow_clock,
    output wire [3:0] seg_anodes,
    output wire [6:0] seg,
    output wire [3:0] AN_off
    );
    
    //Clocks Generation
    parameter sys_freq = 100_000_000;
    wire Clk_400Hz;
    parameter freq_400 = 400;
    wire Clk_1Hz;
    parameter freq_1 = 1;
    clock_divider #(freq_400, sys_freq) CLK1(.sys_clk(sys_clock), .resetSW(reset), .new_clock(Clk_400Hz));
    clock_divider #(freq_1, sys_freq) CLK2(.sys_clk(sys_clock), .resetSW(reset), .new_clock(Clk_1Hz));
    
    
    //accelerate and decellerate clocks
    wire Clk_faster;
    //wire Clk_slower;
    exponential_clock #(freq_1, sys_freq) CLK_fast(.sys_clk(sys_clock), .resetSW(reset), .new_clock(Clk_faster));
    //inverse_freq_clock #(freq_1, sys_freq) CLK_slow(.sys_clk(sys_clock), .resetSW(reset), .new_clock(Clk_slower));
    
    
    //Seg_anode Generation
    assign AN_off = 4'b1111;
    wire [1:0] count_3;
    count_to_3 counter3(.clock(Clk_400Hz), .count(count_3));
    decoder_2x4_low decoder1(.data(count_3), .out(seg_anodes));
    
    //Time Counter Generation
    reg [5:0] used_seconds;
    reg [5:0] used_minutes;
    
    wire [5:0] seconds;
    wire [5:0] minutes;   
    wire [5:0] seconds_fast;
    wire [5:0] minutes_fast;
    //wire [5:0] seconds_slow;
    //wire [5:0] minutes_slow;
    
    wire minute_increment;
    wire hour_increment;
    wire minute_increment_fast;
    wire hour_increment_fast;
    //wire minute_increment_slow;
    //wire hour_increment_slow;
    
    count_to_59 second_counter_faster(.clock(Clk_faster), .reset(reset), .load(load_sec), .L(L_sec), .count(seconds_fast), .carry(minute_increment_fast));
    count_to_59 minute_counter_faster(.clock(minute_increment_fast), .reset(reset), .load(load_min), .L(L_min), .count(minutes_fast), .carry(hour_increment_fast));
    //count_to_59 second_counter_slow(.clock(Clk_slower), .reset(reset), .load(load_sec), .L(L_sec), .count(seconds_slow), .carry(minute_increment_slow));
    //count_to_59 minute_counter_slow(.clock(minute_increment_slow), .reset(reset), .load(load_min), .L(L_min), .count(minutes_slow), .carry(hour_increment_slow));
    count_to_59 second_counter(.clock(Clk_1Hz), .reset(reset), .load(load_sec), .L(L_sec), .count(seconds), .carry(minute_increment));
    count_to_59 minute_counter(.clock(minute_increment), .reset(reset), .load(load_min), .L(L_min), .count(minutes), .carry(hour_increment));
  
    always@ (posedge sys_clock)
    begin
    if(accelerate_clock)
        begin
            used_seconds = seconds_fast;
            used_minutes = minutes_fast;
        end
        /*
        else if (slow_clock)
        begin
            used_seconds = seconds_slow;
            used_minutes = minutes_slow;
        end
        */
        else
        begin
            used_seconds = seconds;
            used_minutes = minutes;
        end
    end
    
    //Time Display-Decoding
    wire [6:0] sec_ones;
    wire [6:0] sec_tens;
    wire [6:0] min_ones;
    wire [6:0] min_tens;
    display_decoder_6_bit decoder_seconds(.count(used_seconds), .tens_display(sec_tens), .ones_display(sec_ones));
    display_decoder_6_bit decoder_minutes(.count(used_minutes), .tens_display(min_tens), .ones_display(min_ones));
    //display_decoder_6_bit decoder_seconds(.count(seconds), .tens_display(sec_tens), .ones_display(sec_ones));
    //display_decoder_6_bit decoder_minutes(.count(minutes), .tens_display(min_tens), .ones_display(min_ones));
    
    //Seg Generation
    mux_4x1_7bit Mux1(.a(sec_ones), .b(sec_tens), .c(min_ones), .d(min_tens), .selector(count_3), .out(seg));
    
endmodule
