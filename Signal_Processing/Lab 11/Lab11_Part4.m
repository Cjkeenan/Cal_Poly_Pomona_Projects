% ECE 3101L
% Lab 11 - Transient and Steady-State Response
% Colin Keenan
% Dennis Getsie

clear;
close all;

%variables
n = 0:64;
w = -pi:0.01:pi;
z = exp(1j*w);

%Frequency Response
num = 0.5 - 0.25*z.^-1;
den = 1 + 0.5*z.^-1;
h_w = num ./ den;
plot(w,h_w);
title('Frequency Response');

%Transfer Function
w = [(2*pi)/8 (2*pi)/16 (2*pi)/32];
z = exp(1j*w);

num = 0.5 - 0.25*z.^-1;
den = 1 + 0.5*z.^-1;
h_z = num ./ den;
h_z_abs = abs(h_z);
h_z_ang = angle(h_z);

% Section 1 
% ?(?) = 0.5?(? ? 1) + ?(?)
% x(n) = 2 * cos((2*pi*n)/32) + 1 * cos((2*pi*n)/16) + 3 * cos((2*pi*n)/8)
x_1 = 2 * cos((2*pi*n)/32) + 1 * cos((2*pi*n)/16) + 3 * cos((2*pi*n)/8);
y_1 = h_z_abs(3)*2 * cos((2*pi*n)/32 + h_z_ang(3)) + h_z_abs(2)*1 * cos((2*pi*n)/16 + h_z_ang(2)) + h_z_abs(1)*3 * cos((2*pi*n)/8 + h_z_ang(1));
figure();
hold on
stem(n,x_1);
stem(n,y_1);
legend('Signal Input','Signal Output')
hold off
