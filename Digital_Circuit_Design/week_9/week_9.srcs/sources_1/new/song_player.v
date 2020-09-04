`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 10/25/2018 12:55:36 PM
// Design Name: 
// Module Name: song_player
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


module song_player #(parameter clockFrequency = 100_000_000,	//100 MHz,
                    parameter tempo = 120)
    ( 
    input sys_clock,  
    input playSound, 
    output reg audio_out, 
    output wire aud_sd
    );
    reg [19:0] counter;
    reg [31:0] time1, noteTime;
    reg [9:0] number;    //millisecond counter, and sequence number of musical note.
    wire [21:0] duration;
    wire [21:0] notePeriod;
    
    assign aud_sd = 1; //volume adjustment (1 is loudest)
    
    sheet_music_StarWars SW_SM(.number(number), .note(notePeriod), .duration(duration));
    
    always @ (posedge sys_clock)
    begin
    	if(~playSound) 
         begin 
            counter <= 0;  
            time1<= 0;  
            number <= 0;  
            audio_out <= 1;    
         end
        else 
          begin
            counter <= counter + 1; 
            time1 <= time1 + 1;
            
            if( counter >= notePeriod) 
            begin
                counter <= 0;  
                audio_out <= ~audio_out ; 
            end    //toggle audio output
             
            if( time1 >= noteTime) 
            begin    
                time1 <= 0;  
                number <= number + 1; 
            end  //play next note
            
            if(number == 179) number <= 0; // Make the number reset at the end of the song
          end
      end
             
      always @(duration) noteTime = (duration * (clockFrequency / (2 * (tempo/60)))) / 4; //since sixteenth is 1, quarter will be 4, and quarter last one note, so the total is divided by 4 for one note
           //number of   FPGA clock periods in one note.
           
endmodule
