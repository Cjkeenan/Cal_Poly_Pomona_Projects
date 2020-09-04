`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/21/2019 01:01:41 PM
// Design Name: 
// Module Name: N_bit_CLA_Adder
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


module N_bit_CLA_Adder #(parameter bits = 2)(
   input [bits-1:0] x,
   input [bits-1:0] y,
   output [bits - 1:0] sum,
   output carry_out
   );
     
  wire [bits:0] carry;
  wire [bits-1:0] gen, prop;
 
  assign carry[0] = 0; // no carry input on first adder
 
  // Create the Full Adders
  genvar i;
  generate
    for (i=0; i<bits; i=i+1) 
      begin
        full_adder full_adder_inst(.x(x[i]), .y(y[i]), .carry_in(carry[i]), .sum(sum[i]), .carry_out());
      end
  endgenerate
 
  // Create the Generate (G) Terms:  Gi=Ai*Bi
  // Create the Propagate Terms: Pi=Ai+Bi
  // Create the Carry Terms:
  genvar j;
  generate
    for (j=0; j<bits; j=j+1) 
      begin
        assign gen[j] = x[j] & y[j];
        assign prop[j] = x[j] | y[j];
        assign carry[j+1] = gen[j] | (prop[j] & carry[j]);
      end
  endgenerate
   
  assign carry_out = carry[bits];
 
endmodule
