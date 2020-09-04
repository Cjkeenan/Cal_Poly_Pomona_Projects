clear
clc

% Problem 1
FMAX1_1 = 2000;
N1 = 2 * FMAX1_1;

FMAX1_2 = 1000;
N2 = 2 * FMAX1_2;

h3 = 1;
a3 = 10E-3;
f3 = -1000:0.01:1000;
w3 = 2*pi*f3;
x3 = h3*a3 .* sinc(f3*a3) .* exp(-1j*f3*a3*.5);

figure();
grid on;
plot(w3,x3);

n4 = 1:5;
T04 = 2E-3;
PW4 = 0.5E-3;
f04 = 1/T04;
f = n4*f04;
f = [0 f];
w0 = 2*pi*f04;
d4 = PW4/T04;
A4 = 2;

x4 = d4*A4 .* sinc(n4*d4) .* exp(-1i*pi*n4*d4);
x04 = (1/T04)*((A4/2)*(T04*d4) + (-1*((A4/2)*(T04) - (A4/2)*(T04*d4))));
Cn4 = 2 * abs(x4);
Cn4 = [x04, Cn4];

figure();
stem(f, Cn4);

% Problem 2
Fs2 = 10000;
Ts2 = 1/Fs2;
FMAX2 = 1000;
n2 = 0:24;
t2 = n2*Ts2;
xn2 = 2 .* cos(2 * pi * FMAX2 * t2);

figure();
stem(n2, xn2);

% Problem 3
Fs3 = 10000;
Ts3 = 1/Fs3;
FMAX3 = 1000;
T03 = 1/FMAX3;
t3 = -T03:T03/10:T03;
xt3 = 5 .* cos(2 * pi * FMAX3 * t3);
n3 = -10:10;
pt3 = stepfun(t3, n3*Ts3);
xs3 = xt3 .* pt3;
Fc3 = 4999;
[b,a] = butter(2, Fc3/(Fs3/2));
yt3 = filter(b,a,xs3);

figure();
hold on
grid on
plot(xt3);
stem(pt3);
stem(xs3);
plot(yt3);
hold off