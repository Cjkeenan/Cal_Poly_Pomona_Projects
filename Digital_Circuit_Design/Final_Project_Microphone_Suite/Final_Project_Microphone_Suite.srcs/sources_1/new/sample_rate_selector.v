`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 11/24/2018 04:05:45 PM
// Design Name: 
// Module Name: sample_rate_selector
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


module sample_rate_selector #(parameter max_freq = 3_300_000)(
    input sys_clk,
    input [6:4] JA,
    input reset,
    output [4:0] EncO,
    output reg [21:0] sampling_freq     //max freq of 3.3MHz, which needs 22bits in binary
    );
//10MHz clock generation
    parameter intended_freq = 10_000_000;
    parameter sys_freq = 100_000_000;
    wire clk_10MHz;
    clock_divider #(intended_freq, sys_freq) clk_gen_10MHZ (.sys_clock(sys_clk), .reset(reset), .new_clock(clk_10MHz));

//Initialize the rotary encoder with EncOut output    
    wire [3:0] an;
    wire [6:0] seg;
    wire [1:0] Led;
    wire AO, BO;   
    Debouncer debouncer1 (.clk(clk_10MHz), .Ain(JA[4]), .Bin(JA[5]), .Aout(AO), .Bout(BO));
    Encoder rot_encoder1 (.clk(sys_clk), .A(AO), .B(BO), .BTN(JA[6]), .EncOut(EncO), .LED(Led));
    
//Generate intended sampling freq
    always @(posedge sys_clk, posedge reset)
    begin
        sampling_freq <= (EncO / 19) * max_freq;  //rotary encoder outputs 0-19, so in order to output up to 3.3MHz, it needs to be multiplied
        if(reset)
            sampling_freq <= 2_400_000;
        else if(sampling_freq > max_freq - 1)
            sampling_freq <= max_freq;
        else
            sampling_freq <= sampling_freq;     
    end
   
endmodule
