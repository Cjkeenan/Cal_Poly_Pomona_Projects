module mux_2x1_4bit(
    input [3:0] x,
    input [3:0] y,
    input s,
    output reg [3:0] f
    );
    
    always@(x,y)
    begin
        case(s)    
            0: f = x;
            1: f = y;
        endcase
    end
    
endmodule