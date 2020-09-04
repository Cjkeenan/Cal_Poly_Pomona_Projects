`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/25/2018 12:55:36 PM
// Design Name: 
// Module Name: count_to_59
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


module count_to_59(
    input clock,
    input reset,
    input load,
    input [5:0] L,
    output reg [5:0] count,
    output reg carry    
    );
        
    initial 
    begin
    count = 0;
    carry = 0;
    end
    
    always @(posedge clock, posedge reset, posedge load)
    begin       
        if (reset)
        begin
            count <= 0;
            carry <= 0;
        end
        
        else if (load)
        begin
            count <= L;
        end
        
        else
        begin
            count <= count + 1;
            carry <= 0;
            
            if (count == 59)
            begin
                count <= 0;
                carry <= 1;
            end
        end
        
    end
    
endmodule
