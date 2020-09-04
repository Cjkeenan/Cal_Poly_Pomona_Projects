`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/03/2018 11:18:46 PM
// Design Name: 
// Module Name: display_decoder_tb
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


module display_decoder_tb(

    );
    
    reg [6:0] tens_display;
    reg [6:0] ones_display;
    reg [5:0] count;
    reg [5:0] tens;
    reg [5:0] ones;
    
    initial
    begin
    tens_display = 0;
    ones_display = 0;
    count = 0;
    tens = 0;
    ones = 0;
    end
    
    always #1 count = count + 1;
    
    always@(count)
    begin
        tens = count / 10;
        ones = count % 10;            
        case(tens)
            0:  tens_display = 7'b000_0001;
            1:  tens_display = 7'b100_1111;
            2:  tens_display = 7'b001_0010;
            3:  tens_display = 7'b000_0110;
            4:  tens_display = 7'b100_1100;
            5:  tens_display = 7'b010_0100;
        endcase
        
        case(ones)
            0:  ones_display = 7'b000_0001;
            1:  ones_display = 7'b100_1111;
            2:  ones_display = 7'b001_0010;
            3:  ones_display = 7'b000_0110;
            4:  ones_display = 7'b100_1100;
            5:  ones_display = 7'b010_0100;
            6:  ones_display = 7'b010_0000;
            7:  ones_display = 7'b000_1111;
            8:  ones_display = 7'b000_0000;
            9:  ones_display = 7'b000_0100;
         endcase      
    end
    
endmodule
