`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 11/01/2018 02:33:14 PM
// Design Name: 
// Module Name: clock_divider
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


module clock_divider #(parameter intended_freq = 1,
                       parameter system_freq = 100_000_000)(
    input sys_clock,
    input reset,
    output reg new_clock      
    );
    reg [26:0] counter;

    always @ (posedge sys_clock)
    begin
        if (reset)
          begin
            counter <= 0;
            new_clock <= 0; 
          end
        else
            begin
              counter <= counter + 1;
              if (counter == system_freq/(2*intended_freq))
                begin
                    new_clock <= ~new_clock;
                    counter <= 0;
                end
            end
    end 
     
endmodule
