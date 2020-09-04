`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/21/2019 12:57:49 PM
// Design Name: 
// Module Name: cla_adder_tb
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


module cla_adder_tb();

  parameter bits = 3;
 
  reg [bits-1:0] x;
  reg [bits-1:0] y;
  wire [bits-1:0] sum;
  wire carry_out;
   
  N_bit_CLA_Adder #(bits) uut
    (
     .x(x),
     .y(y),
     .sum(sum),
     .carry_out(carry_out)
     );
 
  initial
    begin
      #1;
      x = 1;
      y = 3;
      #1;
      x = 7;
      y = 1;
      #1;
      x = 5;
      y = 5;
      #1;
      x = 7;
      y = 7;
    end

endmodule
