`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/06/2018 10:25:59 PM
// Design Name: 
// Module Name: exponential_clock
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


module exponential_clock#(parameter first_freq = 1, 
                          parameter system_freq = 100_000_000,
                          parameter max_freq = 5_000)
    (   
    input sys_clk,
    input resetSW,
    output reg new_clock
    );
    reg [12:0] new_freq, old_freq;
    reg [26:0] count;
    
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
        
        else if(old_freq == max_freq)
        begin
            new_clock <= ~new_clock;
            count <= 0;
        end
        
        else
        begin
            if(count == system_freq/(2*old_freq))
            begin
                new_clock <= ~new_clock;
                new_freq <= old_freq * 2;
                count <= 0;
            end
        end
    end
    
endmodule
