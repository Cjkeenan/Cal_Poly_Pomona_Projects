`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/01/2019 10:14:10 AM
// Design Name: 
// Module Name: main
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


module main(
    input sys_clock,
    input up_mode,
    input reset,
    input load,
    input [4:0] clock_select,
    input [7:0] load_value,
    output [7:0] Anodes,
    output [6:0] seg
    );
    
    //new clocks generation
    parameter sys_freq = 100_000_000;
    wire Clk_400Hz;
    parameter freq_400 = 400;
    clock_divider #(freq_400, sys_freq) clock_400hz(.sys_clock(sys_clock), .reset(~reset), .new_clock(Clk_400Hz));
    
    //Counter Clocks
    wire current_clock;
    wire [31:0] clocks;
//    wire Clk_1Hz;
//    parameter freq_1 = 1;
//    clock_divider #(freq_1, sys_freq) clock_1hz(.sys_clock(sys_clock), .reset(~reset), .new_clock(Clk_1Hz));
//    wire Clk_10Hz;
//    parameter freq_10 = 10;
//    clock_divider #(freq_10, sys_freq) clock_10hz(.sys_clock(sys_clock), .reset(~reset), .new_clock(Clk_10Hz));
    clk_wiz_0 base_wizard(.clk_in1(sys_clock), .reset(~reset), .clk_out1(clk_group1_base), .clk_out2(clk_group2_base), .clk_out3(clk_group3_base), .clk_out4(clk_group4_base), .clk_out5(clk_group5_base), .clk_out6(clk_group6_base));
    clk_wiz_0 clk_group1(.clk_in1(clk_group1_base), .reset(~reset), .clk_out1(clocks[0]), .clk_out2(clocks[1]), .clk_out3(clocks[2]), .clk_out4(clocks[3]), .clk_out5(clocks[4]), .clk_out6(clocks[5]));
    clk_wiz_0 clk_group2(.clk_in1(clk_group2_base), .reset(~reset), .clk_out1(clocks[6]), .clk_out2(clocks[7]), .clk_out3(clocks[8]), .clk_out4(clocks[9]), .clk_out5(clocks[10]), .clk_out6(clocks[11]));
    clk_wiz_0 clk_group3(.clk_in1(clk_group3_base), .reset(~reset), .clk_out1(clocks[12]), .clk_out2(clocks[13]), .clk_out3(clocks[14]), .clk_out4(clocks[15]), .clk_out5(clocks[16]), .clk_out6(clocks[17]));
    clk_wiz_0 clk_group4(.clk_in1(clk_group4_base), .reset(~reset), .clk_out1(clocks[18]), .clk_out2(clocks[19]), .clk_out3(clocks[20]), .clk_out4(clocks[21]), .clk_out5(clocks[22]), .clk_out6(clocks[23]));
    clk_wiz_0 clk_group5(.clk_in1(clk_group5_base), .reset(~reset), .clk_out1(clocks[24]), .clk_out2(clocks[25]), .clk_out3(clocks[26]), .clk_out4(clocks[27]), .clk_out5(clocks[28]), .clk_out6(clocks[29]));
    clk_wiz_0 clk_group6(.clk_in1(clk_group6_base), .reset(~reset), .clk_out1(clocks[30]), .clk_out2(clocks[31]));
 
//    clk_wiz_1 clk_group1(.clk_in1(sys_clock), .reset(~reset), .clk_out1(clocks[0]), .clk_out2(clocks[1]), .clk_out3(clocks[2]), .clk_out4(clocks[3]), .clk_out5(clocks[4]), .clk_out6(clocks[5]));
//    clk_wiz_2 clk_group2(.clk_in1(sys_clock), .reset(~reset), .clk_out1(clocks[6]), .clk_out2(clocks[7]), .clk_out3(clocks[8]), .clk_out4(clocks[9]), .clk_out5(clocks[10]), .clk_out6(clocks[11]));
//    clk_wiz_3 clk_group3(.clk_in1(sys_clock), .reset(~reset), .clk_out1(clocks[12]), .clk_out2(clocks[13]), .clk_out3(clocks[14]), .clk_out4(clocks[15]), .clk_out5(clocks[16]), .clk_out6(clocks[17]));
//    clk_wiz_4 clk_group4(.clk_in1(sys_clock), .reset(~reset), .clk_out1(clocks[18]), .clk_out2(clocks[19]), .clk_out3(clocks[20]), .clk_out4(clocks[21]), .clk_out5(clocks[22]), .clk_out6(clocks[23]));
//    clk_wiz_5 clk_group5(.clk_in1(sys_clock), .reset(~reset), .clk_out1(clocks[24]), .clk_out2(clocks[25]), .clk_out3(clocks[26]), .clk_out4(clocks[27]), .clk_out5(clocks[28]), .clk_out6(clocks[29]));
//    clk_wiz_6 clk_group6(.clk_in1(sys_clock), .reset(~reset), .clk_out1(clocks[30]), .clk_out2(clocks[31]));
    
    //Select Correct Mux
    mux_32x1_1bit clock_selector(.a(clocks), .selector(clock_select), .out(current_clock));
    
    //Slow Clock Down
    wire slower_current_clock;
    clock_spikestrip clock_spikestrip1(.original_clock(current_clock), .new_clock(slower_current_clock));
                   
    //Generate Counter Values w/ load option
    parameter counter_value_bit = 8;
    wire [counter_value_bit - 1:0] count;
    //1 second update
    //up_down_counter_n_bit #(counter_value_bit) counter_value(.clock(current_clock), .up_mode(up_mode), .reset(~reset), .load(load), .load_value(load_value), .count(count));
    //0.1 second update
    up_down_counter_n_bit #(counter_value_bit) counter_value(.clock(slower_current_clock), .up_mode(up_mode), .reset(~reset), .load(load), .load_value(load_value), .count(count));
               
    //Counter Display-Decoding
    wire [6:0] ones;
    wire [6:0] tens;
    wire [6:0] hundreds;
    wire [6:0] thousands;
    display_decoder_6_bit #(counter_value_bit) decoder_counter(.count(count), .thousands_display(thousands), .hundreds_display(hundreds), .tens_display(tens), .ones_display(ones));

    //Segment_anode Generation for 4 seven-segment displays
    wire [0:1] count_4;
    parameter counter_bit = 2;
    up_down_counter_n_bit #(counter_bit) counter_1_bit(.clock(Clk_400Hz), .up_mode(1), .reset(0), .count(count_4));
    decoder_3x8_low decoder1(.data(count_4), .out(Anodes));
    
    //Segment Generation for 4 seven-segment displays
    parameter bit = 7;
    mux_4x1 #(bit) seg_selector(.a(ones), .b(tens), .c(hundreds), .d(thousands), .selector(count_4), .out(seg));
endmodule
