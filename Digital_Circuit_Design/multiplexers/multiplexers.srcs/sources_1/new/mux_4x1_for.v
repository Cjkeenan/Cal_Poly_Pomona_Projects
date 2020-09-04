module mux_4x1_for(
    input [3:0] x,
    input [1:0] s,
    output reg f
    );

    integer i;

    always @(*)
    begin
        for(i = 0; i < 4; i = i + 1)
        begin
            if (s == i)
                f = x[i];
        end
    end
endmodule