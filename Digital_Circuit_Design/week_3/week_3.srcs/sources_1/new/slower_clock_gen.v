`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/13/2018 12:54:23 PM
// Design Name: 
// Module Name: slower_clock_gen
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


module slower_clock_gen(
    input clk,
    input resetSW,
    output reg outSignal
    );
    
    reg [26:0] counter;  
        always @ (posedge clk)
        begin
            if (resetSW)
              begin
                counter=0;
                outSignal=0;
              end
            else
                begin
                  counter = counter +1;
                  if (counter == 10_000_000) //adjust for speed of update
                  
                    begin
                        outSignal=~outSignal;
                        counter =0;
                    end
                end
        end
endmodule
