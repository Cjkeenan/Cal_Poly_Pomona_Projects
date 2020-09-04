`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/25/2018 12:55:36 PM
// Design Name: 
// Module Name: display_decoder
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


module display_decoder_6_bit #(parameter count_bits = 6)(
    input [count_bits - 1:0] count,
    output reg [6:0] thousands_display,
    output reg [6:0] hundreds_display,
    output reg [6:0] tens_display,
    output reg [6:0] ones_display
    );
    
    reg [3:0] thousands;
    reg [3:0] hundreds;
    reg [3:0] tens;
    reg [3:0] ones;
    
    always@(count)
    begin
        ones = (count % 10) / 1;
        tens = (count % 100) / 10;
        hundreds = (count % 1000) / 100;
        thousands = (count % 10000) / 1000;
        
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
    default:
    ones_display = 7'b010_0101;
    endcase
                
    case(tens)
    0:  tens_display = 7'b000_0001;
    1:  tens_display = 7'b100_1111;
    2:  tens_display = 7'b001_0010;
    3:  tens_display = 7'b000_0110;
    4:  tens_display = 7'b100_1100;
    5:  tens_display = 7'b010_0100;
    6:  tens_display = 7'b010_0000;
    7:  tens_display = 7'b000_1111;
    8:  tens_display = 7'b000_0000;
    9:  tens_display = 7'b000_1100;
    default:
    tens_display = 7'b010_0101;
    endcase   
    
    case(hundreds)
    0:  hundreds_display = 7'b000_0001;
    1:  hundreds_display = 7'b100_1111;
    2:  hundreds_display = 7'b001_0010;
    3:  hundreds_display = 7'b000_0110;
    4:  hundreds_display = 7'b100_1100;
    5:  hundreds_display = 7'b010_0100;
    6:  hundreds_display = 7'b010_0000;
    7:  hundreds_display = 7'b000_1111;
    8:  hundreds_display = 7'b000_0000;
    9:  hundreds_display = 7'b000_1100;
    default:
    hundreds_display = 7'b010_0101;
    endcase
    
    case(thousands)
    0:  thousands_display = 7'b000_0001;
    1:  thousands_display = 7'b100_1111;
    2:  thousands_display = 7'b001_0010;
    3:  thousands_display = 7'b000_0110;
    4:  thousands_display = 7'b100_1100;
    5:  thousands_display = 7'b010_0100;
    6:  thousands_display = 7'b010_0000;
    7:  thousands_display = 7'b000_1111;
    8:  thousands_display = 7'b000_0000;
    9:  thousands_display = 7'b000_1100;
    default:
    thousands_display = 7'b010_0101;
    endcase    
    end
    
endmodule
