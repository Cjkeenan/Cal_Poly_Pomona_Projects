`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/03/2018 11:30:41 AM
// Design Name: 
// Module Name: lab1_sim
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


module lab1_sim;
  reg [2:0] data;
  wire [7:0] y;
  decoder uut(.data(data), .y(y)
  );
  
initial begin
       data=0;
    #1 data=1;
    #1 data=2;
    #1 data=3;
    #1 data=4;
    #1 data=5;
    #1 data=6;
    #1 data=7;
end
 
endmodule
