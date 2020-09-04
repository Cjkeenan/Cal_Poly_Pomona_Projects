`timescale 1ns / 1ps

module clock_divider #(parameter intended_freq = 1, 
                       parameter system_freq = 100_000_000)
    (
    input sys_clk,
    input resetSW,
    output reg new_clock
    );
        reg [26:0] counter;
        
            always @ (posedge sys_clk)
            begin
                if (resetSW)
                  begin
                    counter <= 0;
                    new_clock <= 0; 
                  end
                else
                    begin
                      counter <= counter + 1;
                      if (counter == system_freq/(2*intended_freq))
                        begin
                            new_clock <= ~new_clock;
                            counter <= 0;
                        end
                    end
            end 
         
endmodule
