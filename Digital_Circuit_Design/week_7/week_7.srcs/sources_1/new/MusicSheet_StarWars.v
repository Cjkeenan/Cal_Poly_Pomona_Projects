`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/12/2018 01:28:07 AM
// Design Name: 
// Module Name: MusicSheet_StarWars
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


module MusicSheet_StarWars( 
    input [9:0] number,
	output reg [21:0] note,
	output reg [21:0] duration
	);
parameter   SIXTEENTH = 1;
parameter   EIGHTH = SIXTEENTH * 2;
parameter   QUARTER = EIGHTH * 2; //quarter notes last one beat in 4/4
parameter	HALF = QUARTER * 2;
parameter	ONE = HALF * 2; 
parameter   D4 = 170303.6889,
            Ds4 = 160739.678,
            Ee4 = Ds4,
            E4 = 151712.7683,
            F4 = 143192.7969,
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
            Ee5 = Ds5,
            E5 = 75824.68251,
            F5 = 71566.47712,
            Fs5 = 67547.40644,
            Gg5 = Fs5,
            G5 = 63754.041,
            Gs5 = 60173.70552,   
            SP = 1;
 
always @ (number) begin

case(number) //Star Wars Theme
0: 	    begin note = D4; duration = EIGHTH;	        end
1:      begin note = SP; duration = SIXTEENTH;      end
2: 	    begin note = D4; duration = EIGHTH; 	    end	
3:      begin note = SP; duration = SIXTEENTH;      end
4: 	    begin note = D4; duration = EIGHTH; 	    end	
5:      begin note = SP; duration = SIXTEENTH;      end

6: 	    begin note = G4; duration = HALF; 	        end	
7:      begin note = SP; duration = QUARTER;        end
8: 	    begin note = D5; duration = HALF; 	        end	
9:      begin note = SP; duration = QUARTER;        end

10:     begin note = C5; duration = EIGHTH;         end 
11:     begin note = SP; duration = SIXTEENTH;      end
12: 	begin note = B5; duration = EIGHTH; 	    end
13:     begin note = SP; duration = SIXTEENTH;      end
14: 	begin note = A4; duration = EIGHTH; 	    end
15:     begin note = SP; duration = SIXTEENTH;      end
16: 	begin note = G5; duration = HALF; 	        end
17:     begin note = SP; duration = QUARTER;        end
18:  	begin note = D5; duration = QUARTER; 	    end
19:     begin note = SP; duration = EIGHTH;         end

20:        begin note = C5; duration = EIGHTH;      end 
21:        begin note = SP; duration = SIXTEENTH;   end
22: 	   begin note = B5; duration = EIGHTH; 	    end
23:        begin note = SP; duration = SIXTEENTH;   end
24: 	   begin note = A4; duration = EIGHTH; 	    end
25:        begin note = SP; duration = SIXTEENTH;   end
26: 	   begin note = G5; duration = HALF; 	    end
27:        begin note = SP; duration = QUARTER;     end
28:  	   begin note = D5; duration = QUARTER; 	end
29:        begin note = SP; duration = EIGHTH;      end

30: 	   begin note = C5; duration = EIGHTH;      end
31:        begin note = SP; duration = SIXTEENTH;   end
32: 	   begin note = B5; duration = EIGHTH;      end
33:        begin note = SP; duration = SIXTEENTH;   end
34: 	   begin note = C5; duration = EIGHTH; 	    end
35:        begin note = SP; duration = SIXTEENTH;   end
36:  	   begin note = A4; duration = HALF; 	    end
37:        begin note = SP; duration = QUARTER;     end
38:  	   begin note = D4; duration = QUARTER; 	end
39:        begin note = SP; duration = EIGHTH;      end
40:  	   begin note = D4; duration = EIGHTH; 	    end
41:        begin note = SP; duration = SIXTEENTH;   end

42: 	   begin note = G4; duration = HALF; 	    end	
43:        begin note = SP; duration = QUARTER;     end
44: 	   begin note = D5; duration = HALF; 	    end	
45:        begin note = SP; duration = QUARTER;     end

46:     begin note = C5; duration = EIGHTH;         end 
47:     begin note = SP; duration = SIXTEENTH;      end
48: 	begin note = B5; duration = EIGHTH; 	    end
49:     begin note = SP; duration = SIXTEENTH;      end
50: 	begin note = A4; duration = EIGHTH; 	    end
51:     begin note = SP; duration = SIXTEENTH;      end
52: 	begin note = G5; duration = HALF; 	        end
53:     begin note = SP; duration = QUARTER;        end
54:  	begin note = D5; duration = QUARTER; 	    end
55:     begin note = SP; duration = EIGHTH;         end

56:     begin note = C5; duration = EIGHTH;         end 
57:     begin note = SP; duration = SIXTEENTH;      end
58: 	begin note = B5; duration = EIGHTH; 	    end
59:     begin note = SP; duration = SIXTEENTH;      end
60: 	begin note = A4; duration = EIGHTH; 	    end
61:     begin note = SP; duration = SIXTEENTH;      end
62: 	begin note = G5; duration = HALF; 	        end
63:     begin note = SP; duration = QUARTER;        end
64:  	begin note = D5; duration = QUARTER; 	    end
65:     begin note = SP; duration = EIGHTH;         end

66: 	begin note = C5; duration = EIGHTH;         end
67:     begin note = SP; duration = SIXTEENTH;      end
68: 	begin note = B5; duration = EIGHTH;         end
69:     begin note = SP; duration = SIXTEENTH;      end
70: 	begin note = C5; duration = EIGHTH; 	    end
71:     begin note = SP; duration = SIXTEENTH;      end
72:  	begin note = A4; duration = HALF; 	        end
73:     begin note = SP; duration = QUARTER;        end
74:  	begin note = D4; duration = QUARTER; 	    end
75:     begin note = SP; duration = EIGHTH;         end
76:  	begin note = D4; duration = EIGHTH; 	    end
77:     begin note = SP; duration = SIXTEENTH;      end

78:         begin note = E4; duration = QUARTER;    end
79:         begin note = SP; duration = EIGHTH;     end
80:         begin note = E4; duration = EIGHTH;     end
81:         begin note = SP; duration = SIXTEENTH;  end
82:         begin note = E4; duration = EIGHTH;     end
83:         begin note = SP; duration = SIXTEENTH;  end
84:         begin note = C5; duration = EIGHTH;     end
85:         begin note = SP; duration = SIXTEENTH;  end
86:         begin note = B5; duration = EIGHTH;     end
87:         begin note = SP; duration = SIXTEENTH;  end
88:         begin note = A4; duration = EIGHTH;     end
89:         begin note = SP; duration = SIXTEENTH;  end
90:         begin note = G4; duration = EIGHTH;     end
91:         begin note = SP; duration = SIXTEENTH;  end

91:         begin note = G4; duration = EIGHTH;     end 
92:         begin note = SP; duration = SIXTEENTH;  end
93: 	    begin note = A4; duration = EIGHTH; 	end
94:         begin note = SP; duration = SIXTEENTH;  end
95: 	    begin note = B5; duration = EIGHTH; 	end
96:         begin note = SP; duration = SIXTEENTH;  end
97: 	    begin note = A4; duration = QUARTER;    end
98:         begin note = SP; duration = EIGHTH;     end
99:  	    begin note = E4; duration = EIGHTH;     end
100:        begin note = SP; duration = SIXTEENTH;  end
101:  	    begin note = Fs4; duration = QUARTER; 	end
102:        begin note = SP; duration = EIGHTH;     end
103: 	    begin note = D4; duration = QUARTER; 	end
104:        begin note = SP; duration = EIGHTH;     end
105:  	    begin note = D4; duration = EIGHTH; 	end
106:        begin note = SP; duration = SIXTEENTH;  end

107:     begin note = E4; duration = QUARTER;       end
108:     begin note = SP; duration = EIGHTH;        end
109:     begin note = E4; duration = EIGHTH;        end
110:     begin note = SP; duration = SIXTEENTH;     end
111:     begin note = E4; duration = EIGHTH;        end
112:     begin note = SP; duration = SIXTEENTH;     end
113:     begin note = C5; duration = EIGHTH;        end
114:     begin note = SP; duration = SIXTEENTH;     end
115:     begin note = B5; duration = EIGHTH;        end
116:     begin note = SP; duration = SIXTEENTH;     end
117:     begin note = A4; duration = EIGHTH;        end
118:     begin note = SP; duration = SIXTEENTH;     end
119:     begin note = G4; duration = EIGHTH;        end
120:     begin note = SP; duration = SIXTEENTH;     end

121: 	 begin note = D5; duration = QUARTER; 	    end
122:     begin note = SP; duration = EIGHTH;        end
123:  	 begin note = A4; duration = HALF; 	        end
124:     begin note = SP; duration = QUARTER;       end
125: 	 begin note = D4; duration = QUARTER; 	    end
126:     begin note = SP; duration = EIGHTH;        end
127:  	 begin note = D4; duration = EIGHTH; 	    end
128:     begin note = SP; duration = SIXTEENTH;     end

129:        begin note = E4; duration = QUARTER;     end
130:        begin note = SP; duration = EIGHTH;      end
131:        begin note = E4; duration = EIGHTH;      end
132:        begin note = SP; duration = SIXTEENTH;   end
133:        begin note = E4; duration = EIGHTH;      end
134:        begin note = SP; duration = SIXTEENTH;   end
135:        begin note = C5; duration = EIGHTH;      end
136:        begin note = SP; duration = SIXTEENTH;   end
137:        begin note = B5; duration = EIGHTH;      end
138:        begin note = SP; duration = SIXTEENTH;   end
139:        begin note = A4; duration = EIGHTH;      end
140:        begin note = SP; duration = SIXTEENTH;   end
141:        begin note = G4; duration = EIGHTH;      end
142:        begin note = SP; duration = SIXTEENTH;   end

143:        begin note = G4; duration = EIGHTH;      end 
144:        begin note = SP; duration = SIXTEENTH;   end
145: 	    begin note = A4; duration = EIGHTH; 	 end
146:        begin note = SP; duration = SIXTEENTH;   end
147: 	    begin note = B5; duration = EIGHTH; 	 end
148:        begin note = SP; duration = SIXTEENTH;   end
149: 	    begin note = A4; duration = QUARTER; 	 end
150:        begin note = SP; duration = EIGHTH;      end
151:  	    begin note = E4; duration = EIGHTH; 	 end
152:        begin note = SP; duration = SIXTEENTH;   end
153:  	    begin note = Fs4; duration = QUARTER; 	 end
154:        begin note = SP; duration = EIGHTH;      end
155: 	    begin note = D5; duration = QUARTER; 	 end
156:        begin note = SP; duration = EIGHTH;      end
157:  	    begin note = D5; duration = EIGHTH; 	 end
158:        begin note = SP; duration = SIXTEENTH;   end

159:     begin note = G5; duration = EIGHTH;         end 
160:     begin note = SP; duration = SIXTEENTH;      end
161: 	 begin note = F5; duration = EIGHTH; 	     end
162:     begin note = SP; duration = SIXTEENTH;      end
163: 	 begin note = Ee5; duration = EIGHTH; 	     end
164:     begin note = SP; duration = SIXTEENTH;      end
165: 	 begin note = D5; duration = EIGHTH; 	     end
166:     begin note = SP; duration = SIXTEENTH;      end
167:  	 begin note = C5; duration = EIGHTH; 	     end
168:     begin note = SP; duration = SIXTEENTH;      end
169:  	 begin note = Bb4; duration = EIGHTH; 	     end
170:     begin note = SP; duration = SIXTEENTH;      end
171: 	 begin note = A4; duration = EIGHTH; 	     end
172:     begin note = SP; duration = SIXTEENTH;      end
173:  	 begin note = G4; duration = EIGHTH; 	     end
174:     begin note = SP; duration = SIXTEENTH;      end

175:        begin note = D5; duration = HALF;        end
176:        begin note = SP; duration = QUARTER;     end
177:        begin note = D4; duration = QUARTER;     end
178:        begin note = SP; duration = EIGHTH;      end

//https://www.musicnotes.com/sheetmusic/mtd.asp?ppn=MN0127456
//https://www.musicnotes.com/blog/2014/04/11/how-to-read-sheet-music/

default: 	begin note = SP; duration = QUARTER; 	 end
endcase

end
endmodule
