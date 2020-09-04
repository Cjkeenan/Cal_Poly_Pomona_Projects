`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/20/2018 01:20:44 PM
// Design Name: 
// Module Name: sign_mag_add_implement
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


module sign_mag_add_implement
   #( parameter N=4 )
    (input wire [2*N-1:0] SW,
    output wire [6:0]seg,
    output wire [7:0]AN,
    output wire overflow,
    output reg sum_sign
    );
    wire [N-1:0] sum;
    sign_mag_add #(.N(4)) A0(.a(SW[N-1:0]), .b(SW[2*N-1:N]), .sum(sum), .overflow(overflow));
    
    reg [N-2:0] sum_mag;    
    
    always @(sum)
    begin
        sum_sign = sum[N-1];
        sum_mag = sum[N-2:0];
    end
    
    display_decoder DD0(.data(sum_mag), .seg(seg), .AN(AN));
    
endmodule
