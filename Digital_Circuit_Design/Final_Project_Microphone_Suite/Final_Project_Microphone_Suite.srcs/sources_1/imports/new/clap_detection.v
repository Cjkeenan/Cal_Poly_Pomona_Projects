`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 11/15/2018 01:11:22 PM
// Design Name: 
// Module Name: clap_detector
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


module clap_detector(
	input clk,
	input rst,
	input mic_sample,
	output reg toggle      
);
	
	// State variables
	reg [2:0] state, state_d;
	reg [2:0] state_after, state_after_d;
	reg [31:0] delay, delay_d;
	reg toggle_d;
	integer count;
	
	//parameter THRESHOLD = 10'd00000_00011;
	parameter sampling_freq = 1_000_000;
	parameter DELAY_BETWEEN = sampling_freq / 16; // 250_000 (1 MHz / 4 = 250_000)
	parameter DELAY_2SEC = sampling_freq; // 2_000_000 (double 1 Mhz, so 2 seconds)
	
	parameter WAIT_CLAP1 = 3'd0,
              DELAY_CLAP2 = 3'd1,
              WAIT_CLAP2 = 3'd2,
              TOGGLE_STATE = 3'd3,
              DELAY_RESET = 3'd4;
						
	// set state
	always @ (negedge clk, posedge rst) 
	begin
		if(rst)
		begin
			state <= WAIT_CLAP1;
			state_after <= WAIT_CLAP1;
			delay <= 32'h0;
			toggle <= 1'b0;
		end 
		
		else 
		begin
			state <= state_d;
			state_after <= state_after_d;
			delay <= delay_d;
			toggle <= toggle_d;
		end
	end
	
	// check for clap
	always @ (posedge clk)
	begin
		// set previous values
		state_d <= state;
		state_after_d <= state_after;
		delay_d <= delay;
		toggle_d <= toggle;
				
		case(state)
			WAIT_CLAP1: 
			begin
			    if(mic_sample == 1 && count < 000_025)      //250_000 with a clap length of 250ms ( count = 250ms*Sampling_Freq)
			    begin
			         count <= count + 1;
			         state_d <= WAIT_CLAP1;
			    end
			    
				else if(mic_sample == 1 && count >= 000_025)   //250_000 with a clap length of 250ms ( count = 250ms*Sampling_Freq)
				begin
				    count <= 0;
					state_d <= DELAY_CLAP2;
					delay_d <= DELAY_BETWEEN; // set up for delay
				end 
				
				else
				begin
					state_d <= WAIT_CLAP1;
					count <= 0;
                end
			end
			
			DELAY_CLAP2: 
			begin
				if(delay == 32'b0) 
				begin
					state_d <= WAIT_CLAP2;
					delay_d <= DELAY_2SEC; // set up for delay
				end 
				else
					delay_d <= delay - 1'b1;
			end
			
			WAIT_CLAP2: 
			begin
				if(delay == 32'b0) 
				begin
					state_d <= WAIT_CLAP1; // took too long for second clap
				end
				 
				else 
				begin
					delay_d <= delay - 1'b1;
					
                    if(mic_sample == 1 && count < 000_025)     //250_000 with a clap length of 250ms ( count = 250ms*Sampling_Freq)
                    begin
                         count <= count + 1;
                         state_d <= WAIT_CLAP2;
                    end
                    
                    else if(mic_sample == 1 && count >= 000_025)   //250_000 with a clap length of 250ms ( count = 250ms*Sampling_Freq)
                    begin
                        count <= 0;
                        state_d <= TOGGLE_STATE;
                    end 
                    
                    else
                    begin
                        state_d <= WAIT_CLAP2;
                        count <= 0;
                    end

				end
			end
			
			TOGGLE_STATE: 
			begin
				state_d <= DELAY_RESET;
				delay_d <= DELAY_2SEC;
				count <= 0;								
                toggle_d <= ~toggle;
			end
			
			DELAY_RESET: 
			begin
				if(delay == 32'b0)
					state_d <= WAIT_CLAP1;
				else
					delay_d <= delay - 1'b1;
			end
		endcase
	end
endmodule