% ECE 3101L
% Lab 11 - Difference Equation Solution with Initial Values in z-domain
% Colin Keenan
% Dennis Getsie

clear;
close all;

%variables
n = 0:64;

% Section 2 - a) Zero State Response

% Partial fraction expansion
a1 = [1 -0.9*exp(-1j*pi/3)];
a2 = [1 -0.9*exp(1j*pi/3)];
a3 = [1 -1];

b = [1];
a = conv(conv(a1,a2),a3);

% residues, poles, direct terms
% p = poles
% r = coefficients of the partial fraction expansion
[r_zs,p_zs,k_zs] = residuez(b,a);
abs_p_zs = abs(p_zs);
ang_p_zs = angle(p_zs);
abs_r_zs = abs(r_zs);
ang_r_zs = angle(r_zs);

% plotting
%syms z;
%F_zs = r_zs(1)/(1-z) + r_zs(2)/(1-0.9*exp(-1j*pi/3)*z) + r_zs(3)/(1-0.9*exp(1j*pi/3)*z);
%y_zs = iztrans(F_zs);

%stem(n,y_zs);
%title('Zero State Response');

%--------------------------------------------------------------------------
% Section 2 - e) Zero Input Response

% Partial fraction expansion
a1 = [1 -0.9*exp(-1j*pi/3)];
a2 = [1 -0.9*exp(1j*pi/3)];

b = [0.09 -0.81];
a = conv(a1,a2);

% residues, poles, direct terms
% p = poles
% r = coefficients of the partial fraction expansion
[r_zi,p_zi,k_zi] = residuez(b,a);
abs_p_zi = abs(p_zi);
ang_p_zi = angle(p_zi);
abs_r_zi = abs(r_zi);
ang_r_zi = angle(r_zi);

%--------------------------------------------------------------------------
% Section 2 - y(n) generation and plotting

% generate y(n)s
y_zi = (2*abs_r_zi(1)) .* abs_p_zi(1).^n .* cos(ang_p_zi(1).*n - ang_r_zi(1));
y_zs_natural = (2*abs_r_zs(2)) .* abs_p_zs(2).^n .* cos(ang_p_zs(2).*n - ang_r_zs(2));
y_zs_forced = abs_r_zs(1) .* (abs_p_zs(1)).^n;
y_zs = y_zs_forced + y_zs_natural;
y_total = y_zs + y_zi;

% Plotting
subplot(3,2,1)
stem(n,y_zi);
title('Zero Input Response');

subplot(3,2,2)
stem(n,y_zs);
title('Zero State Response');

subplot(3,2,3)
stem(n,y_zs_natural);
title('Zero State Natural Response');

subplot(3,2,4)
stem(n,y_zs_forced);
title('Zero State Forced Response');

subplot(3,2,[5 6])
stem(n,y_total);
title('Total Response');