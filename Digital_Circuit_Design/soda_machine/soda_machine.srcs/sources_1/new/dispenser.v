`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 11/26/2018 09:55:25 PM
// Design Name: 
// Module Name: dispenser
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


module dispenser(
    input nickel, dime, quarter,
    output reg dispense, returnNickel, returnDime, returnTwoDimes
    );
    
    reg [5:0] total;
    reg [4:0] change;
    reg state;
    
    always@(nickel, dime, quarter)
    begin
        dispense = 0;
        returnNickel = 0;
        returnDime = 0;
        returnTwoDimes = 0;
        
        case(state)
            0:              //accepting coins and couting total
            begin             
                total = total + nickel*5 + dime*10 + quarter*25;
                if(total >= 25)
                    state = 1;
                else
                    state = 0;
            end
            
            1:              //measure change and dispense
            begin
                change = total % 25;
                
                case(change)
                    0:  begin dispense = 1; end
                    5:  begin dispense = 1; returnNickel = 1; end
                    10: begin dispense = 1; returnDime = 1; end
                    15: begin dispense = 1; returnDime = 1; returnNickel = 1; end
                    20: begin dispense = 1; returnTwoDimes = 1; end
                    default: begin dispense = 0; returnNickel = 0; returnDime = 0; returnTwoDimes = 0; end
                endcase
                
                total = 0; 
                state = 0;
            end
        endcase
    end
    
endmodule
