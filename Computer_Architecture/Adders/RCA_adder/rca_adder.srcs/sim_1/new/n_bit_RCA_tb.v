`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/21/2019 12:37:33 PM
// Design Name: 
// Module Name: n_bit_RCA_tb
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


module n_bit_RCA_tb(
    );
 
 //Bit Size
 parameter bits = 8;
 
 // Inputs
 reg [bits-1:0] x;
 reg [bits-1:0] y;
 // Outputs
 wire [bits-1:0] sum;
 wire carry_out;

 // Instantiate the Unit Under Test (UUT)
 N_bit_RCA_Adder #(bits) uut (
  .x(x), 
  .y(y), 
  .sum(sum),
  .carry_out(carry_out)
 );

 initial begin
  // Initialize Inputs
  x = 250;
  y = 6;
  #100;
  // Add stimulus here
 end
    
endmodule
