`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 09/13/2019 06:27:53 PM
// Design Name: 
// Module Name: mux_32x1
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


module mux_32x1_1bit(
    input [4:0] selector,
    input [31:0] a,
    output out
    );
    
    wire [7:0] w;
    wire [3:0] y;
    wire [3:0] z;
    wire [1:0] zz;
    wire [1:0] zzz;
    
    mux_2x1 M0(a[0], a[1], selector[0], w[0]);
    mux_2x1 M1(a[2], a[3], selector[0], w[1]);
    mux_2x1 M2(a[4], a[5], selector[0], w[2]);
    mux_2x1 M3(a[6], a[7], selector[0], w[3]);
    mux_2x1 M4(a[8], a[9], selector[0], w[4]);
    mux_2x1 M5(a[10], a[11], selector[0], w[5]);
    mux_2x1 M6(a[12], a[13], selector[0], w[6]);
    mux_2x1 M7(a[14], a[15], selector[0], w[7]);
    mux_2x1 M8(a[16], a[17], selector[0], w[8]);
    mux_2x1 M9(a[18], a[19], selector[0], w[9]);
    mux_2x1 M10(a[20], a[21], selector[0], w[10]);
    mux_2x1 M11(a[22], a[23], selector[0], w[11]);
    mux_2x1 M12(a[24], a[25], selector[0], w[12]);
    mux_2x1 M13(a[26], a[27], selector[0], w[13]);
    mux_2x1 M14(a[28], a[29], selector[0], w[14]);
    mux_2x1 M15(a[30], a[31], selector[0], w[15]);
    
    mux_2x1 N0(w[0], w[1], selector[1], z[0]);
    mux_2x1 N1(w[2], w[3], selector[1], z[1]);
    mux_2x1 N2(w[4], w[5], selector[1], z[2]);
    mux_2x1 N3(w[6], w[7], selector[1], z[3]);
    mux_2x1 N4(w[8], w[9], selector[1], z[4]);
    mux_2x1 N5(w[10], w[11], selector[1], z[5]);
    mux_2x1 N6(w[12], w[13], selector[1], z[6]);
    mux_2x1 N7(w[14], w[15], selector[1], z[7]);
   
    mux_2x1 o0(z[0], z[1], selector[2], zz[0]);
    mux_2x1 o1(z[2], z[3], selector[2], zz[1]);
    mux_2x1 o2(z[4], z[5], selector[2], zz[2]);
    mux_2x1 o3(z[6], z[7], selector[2], zz[3]);
    
    mux_2x1 p0(zz[0], zz[1], selector[3], zzz[0]);
    mux_2x1 p1(zz[2], zz[3], selector[3], zzz[1]);
    
    mux_2x1 q0(zzz[0], zzz[1], selector[4], out);
    
endmodule