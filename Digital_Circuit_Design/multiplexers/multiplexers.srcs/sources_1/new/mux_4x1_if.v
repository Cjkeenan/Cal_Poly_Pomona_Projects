module mux_4x1_if(
    input [3:0] x,
    input [1:0] s,
    output reg f
    );

    always @(*)
    begin
        if (s == 2'b00)
            f = x[0];
        else if (s == 2'b01)
            f = x[1];
        else if (s == 2'b10)
            f = x[2];
        else
            f = x[3];
    end
endmodule