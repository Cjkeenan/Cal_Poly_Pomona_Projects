% ECE 3101L
% Lab 11 - Transient and Steady-State Response
% Colin Keenan
% Dennis Getsie

clear;
close all;

%variables
n = 0:64;
w = [(2*pi)/8 (2*pi)/16 (2*pi)/32];
z = exp(1j*w);

num = 1;
den = 1 - 0.5*z.^-1;
h_z = num ./ den;
h_z_abs = abs(h_z);
h_z_ang = angle(h_z);

% Section 1 
% ?(?) = 0.5?(? ? 1) + ?(?)
% x(n) = 10 * cos((2*pi*n)/8)*u(n)
% Partial fraction expansion
a1 = [1 -0.5];
a2 = [1 -2*cos(pi/4) 1];

b = [10 -10*cos(pi/4)];
a = conv(a1,a2);

% residues, poles, direct terms
% p = poles
% r = coefficients of the partial fraction expansion
[r_1,p_1,k_1] = residuez(b,a);
abs_p_1 = abs(p_1);
ang_p_1 = angle(p_1);
abs_r_1 = abs(r_1);
ang_r_1 = angle(r_1);

y_1_ss = (2*abs_r_1(2)) .* abs_p_1(2).^n .* cos(ang_p_1(2).*n - ang_r_1(2));
y_1_tran = abs_r_1(3) .* (abs_p_1(3)).^n;
y_1_total = y_1_ss + y_1_tran;

subplot(3,1,1)
stem(n,y_1_ss);
title('Steady State Response');
subplot(3,1,2)
stem(n,y_1_tran);
title('Transient Response');
subplot(3,1,3)
stem(n,y_1_total);
title('Total Response');

% Section 2
% ?(?) = 0.5?(? ? 1) + ?(?)
% x(n) = 10 * cos((2*pi*n)/32)*u(n)
% Partial fraction expansion
a1 = [1 -0.5];
a2 = [1 -2*cos(pi/16) 1];

b = [10 -10*cos(pi/16)];
a = conv(a1,a2);

% residues, poles, direct terms
% p = poles
% r = coefficients of the partial fraction expansion
[r_2,p_2,k_2] = residuez(b,a);
abs_p_2 = abs(p_2);
ang_p_2 = angle(p_2);
abs_r_2 = abs(r_2);
ang_r_2 = angle(r_2);

y_2_ss = (2*abs_r_2(2)) .* abs_p_2(2).^n .* cos(ang_p_2(2).*n - ang_r_2(2));
y_2_tran = abs_r_2(3) .* (abs_p_2(3)).^n;
y_2_total = y_2_ss + y_2_tran;

figure();
subplot(3,1,1)
stem(n,y_2_ss);
title('Steady State Response');
subplot(3,1,2)
stem(n,y_2_tran);
title('Transient Response');
subplot(3,1,3)
stem(n,y_2_total);
title('Total Response');
