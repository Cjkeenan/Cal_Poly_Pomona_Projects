module mux_2x1_struct(
    input x0,
    input x1,
    input s,
    output f
    );

    not (sp, s);
    and (w0, x0, sp);
    and (w1, x1, s);
    or  (f, w0, w1);
    
endmodule