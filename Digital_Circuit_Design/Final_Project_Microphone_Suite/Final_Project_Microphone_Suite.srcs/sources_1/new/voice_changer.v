`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 11/24/2018 04:05:45 PM
// Design Name: 
// Module Name: voice_changer
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


module voice_changer(
    //input sys_clk,
    input sampling_clock,
    input reset,
    input mic_data,
    output reg new_mic_data
    );
    
    reg sent;
    
    always@ (posedge sampling_clock, posedge reset)
    begin
        if(reset)
            new_mic_data <= 0;
            
        else
            new_mic_data <= mic_data;
    end
    
endmodule
