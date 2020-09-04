module mux_2x1_dataflow(
    input x0,
    input x1,
    input s,
    output f
    );

    assign f = (x0 & ~s) | (x1 & s);

endmodule