clc
clear
n = 1:12;
A = 4;
T0 = 1E-3;
PW = 0.25E-3;
f0 = 1/T0;
f = n*f0;
f = [0 f];
w0 = 2*pi*f0;
d = PW/T0;

%define input x function
x = d*A .* sinc(n*d) .* exp(-1i*pi*n*d);
Cn = 2*abs(x);
theta = (180*angle(x))/pi;
x0 = (1/T0)*((A/2)*(T0*d) + (-1*((A/2)*(T0) - (A/2)*(T0*d))));
x = [x0 x];
Cn = [x0 Cn];
theta = [0 theta];
n = [0 n];

%define transfer function h
w3db = 2*pi*2300;
%h = w3db ./ ((1j*n*w0) + w3db);    %LPF transfer Function
h = (1j*n*w0) ./ ((1j*n*w0) + w3db);    %HPF transfer Function

%define output y function
Yn = x .* h;
y = Yn .* exp(-1i*w0*n);

d0 = x0 * h(1);
Dn = Cn .* abs(h);
phi = theta + angle(h);

CndbV=real(20*log10(Cn/sqrt(2)));
DndbV=real(20*log10(Dn/sqrt(2)));

figure, subplot (2,1,1)
stem(f,Cn) 
title('One-sided Fourier Coefficients') 
xlabel ('Frequencies (Hz)') 
ylabel('C_n (V)') 
subplot (2,1,2) 
stem(f,theta) 
title('One-side Fourier Phases') 
xlabel ('Frequencies (Hz)') 
ylabel('\theta_n (Degrees)')

figure, subplot (2,1,1)
stem(f,Dn) 
title('One-sided Trigonometric Fourier Coefficients') 
xlabel ('Frequencies (Hz)') 
ylabel('d_n (V)') 
subplot (2,1,2) 
stem(f,phi) 
title('One-side Trigonometric Fourier Phases') 
xlabel ('Frequencies (Hz)') 
ylabel('\phi_n (Degrees)') 