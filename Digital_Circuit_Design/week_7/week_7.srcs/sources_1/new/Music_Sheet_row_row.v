`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/11/2018 01:20:34 PM
// Design Name: 
// Module Name: Music_Sheet_row_row
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


module MusicSheet_row_row( input [9:0] number, 
	output reg [19:0] note,//max 32 different musical notes
	output reg [4:0] duration);
parameter   QUARTER = 1;//2 Hz
parameter	HALF = QUARTER * 2;
parameter	ONE = 2* HALF;
parameter	TWO = 2* ONE;
parameter	FOUR = 2* TWO;
parameter C4=191172.7455, D4=170303.6889, E4 = 151712.7683, F4=143192.7969, G4 = 127561.392,C5 = 95546.4256, SP = 1;  
 
always @ (number) begin
case(number) //Row Row Row your boat
0: 	    begin note = C4;  duration = HALF;	end	//row
1: 	    begin note = SP; duration = HALF; 	end	//
2: 	    begin note = C4; duration = HALF; 	end	//row
3: 	    begin note = SP;  duration = HALF;	end	//
4: 	    begin note = C4; duration = HALF; 	end	//row
5: 	    begin note = SP; duration = HALF; 	end	//
6: 	    begin note = D4; duration = HALF; 	end	//your
7: 	    begin note = E4; duration = HALF; 	end	//boat
8: 	    begin note = SP; duration = HALF; 	end	//
9:  	begin note = E4; duration = HALF; 	end	//gently
10: 	begin note = SP; duration = HALF; 	end	//
11: 	begin note = D4; duration = HALF; 	end	//down
12: 	begin note = E4; duration = HALF; 	end	//
13: 	begin note = SP;  duration = HALF;	end	//
14: 	begin note = F4; duration = HALF; 	end	//the
15: 	begin note = G4; duration = HALF; 	end	//stream
16: 	begin note = SP;  duration = HALF;	end	//
	
17: 	begin note = C5; duration = HALF; 	end	//merrily
18: 	begin note = SP; duration = QUARTER; 	end	//
19: 	begin note = C5; duration = HALF; 	end	//
20: 	begin note = SP; duration = QUARTER; 	end	//
21: 	begin note = C5; duration = HALF; 	end	//
22: 	begin note = SP; duration = QUARTER; 	end	//

23: 	begin note = G4; duration = HALF; 	end	//
24: 	begin note = SP; duration = QUARTER; 	end	//
25: 	begin note = G4; duration = HALF; 	end	//
26: 	begin note = SP; duration = QUARTER; 	end	//
27: 	begin note = G4; duration = HALF; 	end	//
28: 	begin note = SP; duration = QUARTER; 	end	//

29: 	begin note = E4; duration = HALF; 	end	//
30: 	begin note = SP; duration = QUARTER; 	end	//
31: 	begin note = E4; duration = HALF; 	end	//
32: 	begin note = SP; duration = QUARTER; 	end	//
33: 	begin note = E4; duration = HALF; 	end	//
34: 	begin note = SP; duration = QUARTER; 	end	//

35: 	begin note = C4; duration = HALF; 	end	//
36: 	begin note = SP; duration = QUARTER; 	end	//
37: 	begin note = C4; duration = HALF; 	end	//
38: 	begin note = SP; duration = QUARTER; 	end	//
39: 	begin note = C4; duration = HALF; 	end	//
40: 	begin note = SP; duration = QUARTER; 	end	//

41: 	begin note = G4; duration = ONE; 	end	//Life
42: 	begin note = SP; duration = HALF; 	end	//
43: 	begin note = F4; duration = HALF; 	end	//is
44: 	begin note = E4; duration = HALF; 	end	//but
45: 	begin note = SP; duration = HALF; 	end	//
46: 	begin note = D4; duration = HALF; 	end	//a
47: 	begin note = C4; duration = HALF; 	end	//dream
default: 	begin note = C4; duration = FOUR; 	end
endcase
end
endmodule

