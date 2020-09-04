`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/21/2019 12:19:30 PM
// Design Name: 
// Module Name: N-bit_RCA_Adder
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


module N_bit_RCA_Adder #(parameter n = 2)(
    input [n-1:0] x,
    input [n-1:0] y,
    output [n-1:0] sum,
    output carry_out
    );
    wire [n:0] carry;
    assign carry[0] = 0;
    
    genvar i;
    generate 
        for(i = 0; i <= n; i=i+1)
            begin: generate_N_bit_Adder
                full_adder f(.x(x[i]), .y(y[i]), .carry_in(carry[i]), .sum(sum[i]), .carry_out(carry[i+1]));
            end
        assign carry_out = carry[n];
    endgenerate
    
endmodule
