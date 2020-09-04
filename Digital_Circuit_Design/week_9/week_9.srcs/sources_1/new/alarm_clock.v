`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/25/2018 01:00:26 PM
// Design Name: 
// Module Name: alarm_clock
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

module alarm_clock(
    input sys_clock,
    input [5:0] L_sec,
    input [5:0] L_min,
    input load_clock,
    input load_alarm,
    input alarm_on,
    input dismiss,
    input reset,
    output [7:0] Anodes,
    output [6:0] seg,
    output reg alarm_display,
    output aud_sd,
    output audio_out
    );
        
        //new clocks generation
        parameter sys_freq = 100_000_000;
        wire Clk_400Hz;
        parameter freq_400 = 400;
        clock_divider #(freq_400, sys_freq) clock_400hz(.sys_clock(sys_clock), .reset(~reset), .new_clock(Clk_400Hz));
        
        //Digital Clock
        wire [5:0] clock_min;
        wire [5:0] clock_sec;
        wire [6:0] clock_sec_ones;
        wire [6:0] clock_sec_tens;
        wire [6:0] clock_min_ones;
        wire [6:0] clock_min_tens;
        digital_clock DC1(.sys_clock(sys_clock), .L_sec(L_sec), .L_min(L_min), .load_clock(load_clock), .reset(~reset), .clock_sec_ones(clock_sec_ones),
                          .clock_sec_tens(clock_sec_tens), .clock_min_ones(clock_min_ones), .clock_min_tens(clock_min_tens), .clock_sec(clock_sec),
                          .clock_min(clock_min));          
            
        //Load Alarm Values
        wire [5:0] alarm_sec;
        wire [5:0] alarm_min;
        loader alarm_sec_loader(.sys_clock(sys_clock), .load_value(L_sec), .load(load_alarm), .loaded_value(alarm_sec), .reset(~reset));
        loader alarm_min_loader(.sys_clock(sys_clock), .load_value(L_min), .load(load_alarm), .loaded_value(alarm_min), .reset(~reset));
        
        //Alarm Display-Decoding
        wire [6:0] alarm_sec_ones;
        wire [6:0] alarm_sec_tens;
        wire [6:0] alarm_min_ones;
        wire [6:0] alarm_min_tens;
        display_decoder_6_bit decoder_alarm_seconds(.count(alarm_sec), .tens_display(alarm_sec_tens), .ones_display(alarm_sec_ones));
        display_decoder_6_bit decoder_alarm_minutes(.count(alarm_min), .tens_display(alarm_min_tens), .ones_display(alarm_min_ones));
        
        //Seg_anode Generation
        wire [2:0] count_7;
        parameter counter_bit = 3;
        counter_n_bit #(counter_bit) counter_3_bit(.clock(Clk_400Hz), .count(count_7));
        decoder_3x8_low decoder1(.data(count_7), .out(Anodes));
        
        //Segment Generation
        parameter bit = 7;
        mux_8x1 #(bit) seg_selector(.a(clock_sec_ones), .b(clock_sec_tens), .c(clock_min_ones), .d(clock_min_tens),
                                    .e(alarm_sec_ones), .f(alarm_sec_tens), .g(alarm_min_ones), .h(alarm_min_tens),
                                    .selector(count_7), .out(seg));
        
        //Alarm Enabler
        wire alarm_play;
        alarm_enabler enabler1(.clock(sys_clock), .alarm_on(alarm_on), .clock_sec(clock_sec), .clock_min(clock_min), .alarm_sec(alarm_sec), .alarm_min(alarm_min), .dismiss(dismiss),
                               .alarm_play(alarm_play));
        always@ (alarm_on) alarm_display = alarm_on;
        
        //Song Player
        parameter tempo = 120;
        song_player #(.tempo(tempo), .clockFrequency(sys_freq)) song_player1(.sys_clock(sys_clock), .playSound(alarm_play), .audio_out(audio_out), .aud_sd(aud_sd));      

endmodule
