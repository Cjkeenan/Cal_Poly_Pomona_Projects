`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/06/2018 01:43:25 PM
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


module display_decoder(
    input [2:0] data,
    output reg [6:0]seg,
    output reg [7:0]AN
    );
    
    wire [7:0]y;
    decoder D0 (data, y);

    always@(y)
        begin     
            casex(y)
                8'b0000_0001 : begin seg = 7'b000_0001; AN = 8'b1111_1110; end
                8'b0000_0010 : begin seg = 7'b100_1111; AN = 8'b1111_1101; end
                8'b0000_0100 : begin seg = 7'b001_0010; AN = 8'b1111_1011; end
                8'b0000_1000 : begin seg = 7'b000_0110; AN = 8'b1111_0111; end
                8'b0001_0000 : begin seg = 7'b100_1100; AN = 8'b1110_1111; end
                8'b0010_0000 : begin seg = 7'b010_0100; AN = 8'b1101_1111; end
                8'b0100_0000 : begin seg = 7'b010_0000; AN = 8'b1011_1111; end
                8'b1000_0000 : begin seg = 7'b000_1111; AN = 8'b0111_1111; end
                default: begin seg = 7'bxxx_xxxx; AN = 8'bxxxx_xxxx; end
            endcase
        end
endmodule
