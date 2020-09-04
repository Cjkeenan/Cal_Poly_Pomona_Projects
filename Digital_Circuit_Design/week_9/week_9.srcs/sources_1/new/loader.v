`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/25/2018 12:55:36 PM
// Design Name: 
// Module Name: loader
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


module loader(
    input sys_clock,
    input [5:0] load_value,
    input load,
    input reset,
    output reg [5:0] loaded_value
    );
        
    always@ (posedge sys_clock, posedge reset)
    begin
        if(reset)
            loaded_value <= 0;
        else if(load)
            loaded_value <= load_value;
    end
endmodule
