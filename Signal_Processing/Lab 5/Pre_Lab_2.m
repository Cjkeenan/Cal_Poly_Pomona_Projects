close all
clear
clc

z = -1;
b0 = (1+0.9*z^-1)/(1-z^-1);
num = b0*[1 -1];
den = [1 0.9];
figure();
zplane(num,den);
figure();
freqz(num,den);
type = "HPF";

n = 0:32;
x1 = cos(2*pi*n/16);
x2 = cos(2*pi*n/8);
x3 = cos(2*pi*n/4);
y1 = filter(num,den,x1);
y2 = filter(num,den,x2);
y3 = filter(num,den,x3);

%X1 response
figure('Name', 'X1 Response')
subplot(2,1,1)
stem(n,x1)
title 'X(n)'
xlabel n
ylabel x(n)
subplot(2,1,2)
stem(n,y1)
title 'Y(n)'
xlabel n
ylabel y(n)

%X2 response
figure('Name', 'X2 Response')
subplot(2,1,1)
stem(n,x2)
title 'X(n)'
xlabel n
ylabel x(n)
subplot(2,1,2)
stem(n,y2)
title 'Y(n)'
xlabel n
ylabel y(n)

%X3 response
figure('Name', 'X3 Response')
subplot(2,1,1)
stem(n,x3)
title 'X(n)'
xlabel n
ylabel x(n)
subplot(2,1,2)
stem(n,y3)
title 'Y(n)'
xlabel n
ylabel y(n)

%Read Music
[x,Fs] = audioread('hideaway.mp3');
original = audioplayer(x,Fs);

y = filter(num, den, x);
filtered = audioplayer(y,Fs);