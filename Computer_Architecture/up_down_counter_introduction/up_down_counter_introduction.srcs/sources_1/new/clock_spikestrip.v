`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/13/2019 08:20:13 PM
// Design Name: 
// Module Name: clock_spikestrip
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


module clock_spikestrip(
    input original_clock,
    output reg new_clock
    );
        reg [26:0] counter;
        
            always @ (posedge original_clock)
            begin
              counter <= counter + 1;
              if (counter == 1_000_000)
                begin
                    new_clock <= ~new_clock;
                    counter <= 0;
                end
            end 
     
endmodule