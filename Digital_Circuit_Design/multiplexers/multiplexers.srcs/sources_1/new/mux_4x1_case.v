module mux_4x1_case(
    input [3:0] x,
    input [1:0] s,
    output reg f
    );

    always @(*)
    begin
        case(s)
        2'b00: f = x[0];
        2'b01: f = x[1];
        2'b10: f = x[2];
        2'b11: f = x[3];
        default: f = x[0]; //optional
        endcase
    end
endmodule