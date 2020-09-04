`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 11/01/2018 01:45:01 PM
// Design Name: 
// Module Name: tlc_4way
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


module tlc_4way# (parameter sys_freq = 100_000_000)
    (
    input sys_clock, reset,
    input Sa1, Sa2, Sb1, Sb2,
    output reg Ga, Ya, Ra, Gb, Yb, Rb
    );
    reg [3:0] state;
    
    //1 second clock generator
    wire Clk_1Hz;
    parameter freq_1 = 1;
    clock_divider #(freq_1, sys_freq) clock_1hz(.sys_clock(sys_clock), .reset(reset), .new_clock(Clk_1Hz));
    
    always@ (posedge Clk_1Hz)
    begin
        if(reset)
        begin
            Ga <= 0;
            Ya <= 0;
            Ra <= 0;
            Gb <= 0;
            Yb <= 0;
            Rb <= 0;
        end
        
        Ga <= 0;
        Ya <= 0;
        Ra <= 0;
        Gb <= 0;
        Yb <= 0;
        Rb <= 0;
        
        case(state)
            0,1,2,3,4:
            begin
                Ga <= 1;
                Rb <= 1;
                state <= state + 1;
            end
            
            5:
            begin
                Ga <= 1;
                Rb <= 1;
                if(Sb1 || Sb2)
                    state <= state + 1;
                else if(~(Sb1 || Sb2))
                    state <= state;
            end
            
            6:
            begin
                Ya <= 1;
                Rb <= 1;
                state <= state + 1;
            end
            
            7,8,9,10:
            begin
                Ra <= 1;
                Gb <= 1;
                state <= state + 1;
            end
            
            11:
            begin
                Ra <= 1;
                Gb <= 1;
                if((Sa1 || Sa2) || (~(Sb1 || Sb2)))
                    state <= state + 1;
                else if((Sb1 || Sb2) && (~(Sa1 || Sa2)))
                    state <= state;
            end
            
            12:
            begin
                Ra <= 1;
                Yb <= 1;
                state <= 0;
            end
            
            default:
            begin
                Ga <= 1;
                Rb <= 1;
            end
            
        endcase
    end
endmodule
