`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/06/2018 10:27:32 PM
// Design Name: 
// Module Name: inverse_freq_clock
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


module inverse_freq_clock#(parameter first_freq = 1, 
                       parameter system_freq = 100_000_000)
    (
    input sys_clk,
    input resetSW,
    output reg new_clock
    );
    reg new_freq, old_freq, count;
    
    initial new_freq = first_freq;
    
    always@(posedge sys_clk)
    begin
        old_freq <= new_freq;
        count <= count + 1;
        
        if (resetSW)
        begin
            count <= 0;
            new_clock <= 0; 
        end
        
        else
        begin
            if(count == system_freq/(2*old_freq))
            begin
                new_clock <= ~new_clock;
                new_freq <= 0.5 * old_freq;
                count <= 0;
            end
        end
    end
    
endmodule
