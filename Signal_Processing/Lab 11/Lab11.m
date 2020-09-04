% ECE 3101L
% Lab 11 - Difference Equation Solution with Initial Values in z-domain
% Colin Keenan
% Dennis Getsie

clear;
close all;

% Section 1
% y(n) + 0.6y(n-1) + 0.08y(n-2) = x(n-1) + 0.5x(n-2)

% Find zero state response and plot for n=[0:64]
% y_zs = ((35/8)*((0.5)^n)) - (15/2)*((0.4)^n) + (25/8)).* heaviside(n);
n = 0:64;
y_zs = (((35/8)*((0.5).^n)) - (15/2)*((0.4).^n) + (25/8)) .* heaviside(n);

stem(n,y_zs);
title('Zero State Response');

% Find natural response and plot for n=[0:64]
% y_n = (((35/8)*((0.5).^n)) - (15/2)*((0.4).^n) + (25/8))

y_n = (((35/8)*((0.5).^n)) - (15/2)*((0.4).^n));
figure;
stem(n,y_n);
title('Natural Response');

% Find forced response and plot for n=[0:64]
% y_f = (25/8)).* heaviside(n)
y_f = (25/8).* heaviside(n);
figure;
stem(n,y_f);
title('Forced Response');

% Find zero input response and plot for n=[0:64]
% y_zi = ((1/25)*((1/5).^n) - (12/25)*((2/5).^n)).* heaviside(n);
y_zi = ((1/25)*((1/5).^n) - (12/25)*((2/5).^n)).* heaviside(n);
figure;
stem(n,y_zi);
title('Zero Input Response');

% Find total response and plot for n=[0:64]
% y_total = zero input response + zero state response
% y_total = y_zs + y_zi
y_total = y_zs + y_zi;
figure;
stem(n,y_total);
title('Total Response');