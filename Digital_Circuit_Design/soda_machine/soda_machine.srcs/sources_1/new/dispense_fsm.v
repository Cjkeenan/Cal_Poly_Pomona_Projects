`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 11/26/2018 10:34:16 PM
// Design Name: 
// Module Name: dispense_fsm
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


module dispense_fsm(
    input nickel, dime, quarter,
    output reg dispense, returnNickel, returnDime, returnTwoDimes
    );
    
    reg [5:0] total;
    
    always@(nickel, dime, quarter)
    begin
        dispense = 0;
        returnNickel = 0;
        returnDime = 0;
        returnTwoDimes = 0;
        total = total + nickel*5 + dime*10 + quarter*25;
        
        case(total)                                        
            25: begin total = 0; dispense = 1; end
            30: begin total = 0; dispense = 1; returnNickel = 1; end
            35: begin total = 0; dispense = 1; returnDime = 1; end
            40: begin total = 0; dispense = 1; returnDime = 1; returnNickel = 1; end
            45: begin total = 0; dispense = 1; returnTwoDimes = 1; end
            default: begin dispense = 0; returnNickel = 0; returnDime = 0; returnTwoDimes = 0; end                                                                                                                                   
        endcase
    end
    
endmodule
