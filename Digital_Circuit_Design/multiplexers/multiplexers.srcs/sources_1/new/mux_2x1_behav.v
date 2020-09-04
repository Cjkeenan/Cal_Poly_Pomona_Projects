module mux_2x1_behav(
    input x0,
    input x1,
    input s,
    output reg f
    );

    always @(*)
    begin
        if (s == 0)
            f = x0;
        else
            f = x1;
    end

endmodule