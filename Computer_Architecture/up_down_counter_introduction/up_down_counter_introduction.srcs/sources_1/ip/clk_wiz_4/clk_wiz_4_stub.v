// Copyright 1986-2019 Xilinx, Inc. All Rights Reserved.
// --------------------------------------------------------------------------------
// Tool Version: Vivado v.2019.1.1 (win64) Build 2580384 Sat Jun 29 08:12:21 MDT 2019
// Date        : Fri Sep 13 18:12:09 2019
// Host        : ColinKeenan-PC running 64-bit major release  (build 9200)
// Command     : write_verilog -force -mode synth_stub
//               f:/OneDrive/Vivado_Workspace/ECE_4300/up_down_counter_introduction/up_down_counter_introduction.srcs/sources_1/ip/clk_wiz_4/clk_wiz_4_stub.v
// Design      : clk_wiz_4
// Purpose     : Stub declaration of top-level module interface
// Device      : xc7a100tcsg324-1
// --------------------------------------------------------------------------------

// This empty module with port declaration file causes synthesis tools to infer a black box for IP.
// The synthesis directives are for Synopsys Synplify support to prevent IO buffer insertion.
// Please paste the declaration into a Verilog source file or add the file as an additional source.
module clk_wiz_4(clk_out1, clk_out2, clk_out3, clk_out4, clk_out5, 
  clk_out6, reset, locked, clk_in1)
/* synthesis syn_black_box black_box_pad_pin="clk_out1,clk_out2,clk_out3,clk_out4,clk_out5,clk_out6,reset,locked,clk_in1" */;
  output clk_out1;
  output clk_out2;
  output clk_out3;
  output clk_out4;
  output clk_out5;
  output clk_out6;
  input reset;
  output locked;
  input clk_in1;
endmodule