close all
clear
clc

syms z
h = ((z-((2^-0.5) + (2^-0.5)*1j))*(z-((2^-0.5) - (2^-0.5)*1j))*(z-(0 + 1j))*(z-(0 - 1j))*(z-(-(2^-0.5) + (2^-0.5)*1j))*(z-(-(2^-0.5) - (2^-0.5)*1j))*(z-(-1 + 0*1j)))/(z^7);
simplify(h)

theta = 0;
z = exp(1j*theta);
h = ((z-((2^-0.5) + (2^-0.5)*1j))*(z-((2^-0.5) - (2^-0.5)*1j))*(z-(0 + 1j))*(z-(0 - 1j))*(z-(-(2^-0.5) + (2^-0.5)*1j))*(z-(-(2^-0.5) - (2^-0.5)*1j))*(z-(-1 + 0*1j)))/(z^7);
b0 = real(1/h);
num = b0*[1 1 1 1 1 1 1 1];
den = [1];
figure();
zplane(num,den);
figure();
freqz(num,den);
type = "LPF";

n = 0:48;
x1 = cos(2*pi*n/24);
x2 = cos(2*pi*n/12);
x3 = cos(2*pi*n/6);
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
[x,Fs] = audioread('hideaway.au');
original = audioplayer(x,Fs);

y = filter(num, den, x);
filtered = audioplayer(y,Fs);

z = x + y;
added = audioplayer(z,Fs);