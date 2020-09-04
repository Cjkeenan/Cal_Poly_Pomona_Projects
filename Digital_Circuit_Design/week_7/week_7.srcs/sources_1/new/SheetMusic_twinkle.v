`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/11/2018 02:38:04 PM
// Design Name: 
// Module Name: SheetMusic_twinkle
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


module MusicSheet_twinkle #(parameter tempo = 100)( input [9:0] number,
	output reg [19:0] note,//max 32 different musical notes
	output reg [4:0] duration);
parameter   EIGHTH = QUARTER / 2;
parameter   QUARTER = tempo; //beats per second (quarter notes last one beat)
parameter	HALF = QUARTER * 2;
parameter	ONE = HALF * 2; 
parameter	TWO = 2 * ONE;
parameter	FOUR = 2 * TWO;
parameter   F4 = 143192.7969,
            Fs4 = 135151.2949,
            Gg4 = Fs4, 
            G4 = 127561.392,
            Gs4 = 120397.7273,
            Aa4 = Gs4,
            A4 = 113636.3636,
            As4 = 107254.7085,
            Bb4 = As4,
            B5 = 101231.4379,
            C5 = 95546.4256,
            Cs5 = 90180.67541,
            Dd5 = Cs5,
            D5 = 85116.25806,
            Ds5 = 80336.25112,   
            SP = 1;  
 
always @ (number) begin
case(number) //Twinkle Twinkle Little Star
0: 	    begin note = F4; duration = QUARTER;	end	//Twinkle
1:      begin note = SP; duration = QUARTER;    end
2: 	    begin note = F4; duration = QUARTER; 	end	//
3:      begin note = SP; duration = QUARTER;    end
4: 	    begin note = C5; duration = QUARTER; 	end	//Twinkle
5:      begin note = SP; duration = QUARTER;    end
6: 	    begin note = C5; duration = QUARTER;	end	//
7:      begin note = SP; duration = QUARTER;    end

8: 	    begin note = D5; duration = QUARTER; 	end	//little
9:      begin note = SP; duration = QUARTER;    end
10: 	begin note = D5; duration = QUARTER; 	end	//
11:     begin note = SP; duration = QUARTER;    end
12:     begin note = C5; duration = HALF;       end //star
13:     begin note = SP; duration = HALF;       end //end of 4 count + missing beat in song

14: 	begin note = Bb4; duration = QUARTER; 	end	//How
15:     begin note = SP; duration = QUARTER;    end
16: 	begin note = Bb4; duration = QUARTER; 	end	//I
17:     begin note = SP; duration = QUARTER;    end
18: 	begin note = A4; duration = QUARTER; 	end	//wonder
19:     begin note = SP; duration = QUARTER;    end
20:  	begin note = A4; duration = QUARTER; 	end	//
21:     begin note = SP; duration = QUARTER;    end


22: 	   begin note = G4; duration = QUARTER; end	//what
23:        begin note = SP; duration = QUARTER; end
24: 	   begin note = G4; duration = QUARTER; end	//you
25:        begin note = SP; duration = QUARTER;    end
26: 	   begin note = F4; duration = HALF; 	end	//are
27:        begin note = SP; duration = HALF;    end //end of 4 count + missing beat in song


28: 	   begin note = C5;  duration = QUARTER;	end	//up
29:        begin note = SP; duration = QUARTER; end
30: 	   begin note = C5; duration = QUARTER; 	end	//above
31:        begin note = SP; duration = QUARTER; end
32: 	   begin note = Bb4; duration = QUARTER; 	end	//
33:        begin note = SP; duration = QUARTER; end
34: 	   begin note = Bb4;  duration = QUARTER;	end	//the
35:        begin note = SP; duration = QUARTER;    end

36: 	   begin note = A4;  duration = QUARTER;end	//world
37:        begin note = SP; duration = QUARTER; end
38: 	   begin note = A4;  duration = QUARTER;end	//so
39:        begin note = SP; duration = QUARTER;    end
40: 	   begin note = G4;  duration = HALF;	end	//high
41:        begin note = SP; duration = HALF;    end //end of 4 count + missing beat in song

42:     begin note = C5;  duration = QUARTER;	    end	//like
43:     begin note = SP; duration = QUARTER;    end
44: 	begin note = C5; duration = QUARTER; 	    end	//a
45:     begin note = SP; duration = QUARTER;    end
46: 	begin note = Bb4; duration = QUARTER; 	    end	//diamond
47:     begin note = SP; duration = QUARTER;    end
48: 	begin note = Bb4;  duration = QUARTER;	    end	//
49:     begin note = SP; duration = QUARTER;    end

50: 	begin note = A4;  duration = QUARTER;	end	//in
51:     begin note = SP; duration = QUARTER;    end
52: 	begin note = A4;  duration = QUARTER;	end	//the
53:     begin note = SP; duration = QUARTER;    end
54: 	begin note = G4;  duration = ONE;	    end	//sky
55:     begin note = SP; duration = HALF;    end //end of 4 count + missing beat in song

default: 	begin note = F4; duration = FOUR; 	end
endcase
end
endmodule
