`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/25/2018 12:55:36 PM
// Design Name: 
// Module Name: counter_n_bit
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


module up_down_counter_n_bit #(parameter n = 2)(
    input clock,
    input up_mode,
    input reset,
    input load,
    input [n-1:0] load_value,
    output reg [n-1:0] count
    );
    
    always@ (posedge clock)
    if(reset)
        count <= 0;
    else if(load)
        count <= load_value;
    else
        if(up_mode == 1)
            count <= count + 1;
        else
            count <= count - 1;
    
endmodule
