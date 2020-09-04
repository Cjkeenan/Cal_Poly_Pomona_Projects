`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/25/2018 12:55:36 PM
// Design Name: 
// Module Name: alarm_enabler
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


module alarm_enabler(
    input clock,
    input alarm_on,
    input [5:0] clock_sec,
    input [5:0] clock_min,
    input [5:0] alarm_sec,
    input [5:0] alarm_min,
    input dismiss,
    output reg alarm_play
    );
    always@(posedge clock)
    begin
        if ((alarm_on) && (clock_sec == alarm_sec) && (clock_min == alarm_min) && (~alarm_play)) alarm_play <= 1;
        if (dismiss) alarm_play <= 0;
    end
endmodule
