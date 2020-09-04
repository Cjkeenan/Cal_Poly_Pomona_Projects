`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 11/24/2018 04:05:45 PM
// Design Name: 
// Module Name: microphone_suite
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


module microphone_suite(
    input sys_clk,
    input mic_data,
    //input [6:4] JA,
    input mode_select,
    input reset,
    input channel_select,
    output aud_sd,
    output reg current_mode,
    output reg sampling_clock,
    output sampled_mic_data,
    //output reg [9:0] mic_sample,
    output clap_toggle
    );
    
//Generate Sampling Rates
    reg [25:0] used_sampling_freq;
    //wire [25:0] clap_sampling_freq;
    //wire [23:0] voice_sampling_freq;
    parameter clap_sampling_freq = 1_000_000;
    parameter voice_sampling_freq = 2_000_000;
    wire voice_clock;
    wire clap_clock;
    //sample_rate_selector #(1_000_000) voice_sampler (.sys_clk (sys_clk), .JA(JA), .reset(reset), .sampling_freq(voice_sampling_freq));
    
    clock_divider #(clap_sampling_freq) clk_gen_clap (.sys_clock(sys_clk), .reset(reset), .new_clock(clap_clock));
    clock_divider #(voice_sampling_freq) clk_gen_voice (.sys_clock(sys_clk), .reset(reset), .new_clock(voice_clock));

//Mode Select: 0 - Clap Detection, 1 - Voice Changer 
    always@(mode_select, reset)
    begin
        if(reset)
        begin
            //used_sampling_freq = clap_sampling_freq;
            current_mode = 0;
            sampling_clock = 0;
        end
        
        else if (mode_select)
        begin
            //used_sampling_freq = voice_sampling_freq;
            current_mode = 1;
            sampling_clock = voice_clock;
        end
        
        else
        begin
            //used_sampling_freq = clap_sampling_freq;
            current_mode = 0;
            sampling_clock = clap_clock;
        end
    end
    
/*Sampling Clock Generator
    parameter sys_freq = 100_000_000;
    reg [26:0] counter;
    reg sampling_clock;
    always@ (posedge sys_clk)
        begin
            if (reset)
              begin
                counter <= 0;
                sampling_clock <= 0; 
              end
            else
                begin
                  counter <= counter + 1;
                  if (counter == sys_freq/(2*used_sampling_freq))
                    begin
                        sampling_clock <= ~sampling_clock;
                        counter <= 0;
                    end
                end
        end
*/
        
//Voice Changer - NOT WORKING
    assign aud_sd = current_mode;   //if mode 1, then volume will be 1, if mode 0, no volume
    //assign aud_sd = 1;
    voice_changer VC1 (.sampling_clock(sampling_clock), .reset(reset), .mic_data(mic_data), .new_mic_data(sampled_mic_data));

    
//Clap Detection

    //48MHz Clock Generator
        //parameter intended_freq = 48_000_000;
        //wire clk_48MHz;
        //clock_divider #(intended_freq, sys_freq) clk_gen_48MHZ (.sys_clock(sys_clk), .reset(reset), .new_clock(clk_48MHz));
    clap_detector CD1(.clk(sampling_clock), .rst(reset), .mic_sample(mic_data), .toggle(clap_toggle));
    
endmodule
