% ECE3101L
% Lab 6 - #3
% Colin Keenan & Dennis Getsie

close all
clear
clc

syms z
h = ((z-((2^-0.5) + (2^-0.5)*1j))*(z-((2^-0.5) - (2^-0.5)*1j))*(z-(-1 + 0j))*(z-(-(2^-0.5) + (2^-0.5)*1j))*(z-(-(2^-0.5) - (2^-0.5)*1j))*(z-(1 + 0*1j)))/(z^6);
simplify(h)

theta = pi/2;
z = exp(1j*theta);
h = ((z-((2^-0.5) + (2^-0.5)*1j))*(z-((2^-0.5) - (2^-0.5)*1j))*(z-(-1 + 0j))*(z-(-(2^-0.5) + (2^-0.5)*1j))*(z-(-(2^-0.5) - (2^-0.5)*1j))*(z-(1 + 0*1j)))/(z^6);
b0 = real(1/h);
num = b0*[1 0 -1 0 1 0 -1];
den = [1];
figure();
zplane(num,den);
figure();
freqz(num,den);
type = "BPF";

%Read Music
[x,Fs] = audioread('hideaway.au');
original = audioplayer(x,Fs);

% Apply filter #1-b
y = filter(num, den, x);
filtered = audioplayer(y,Fs);

% Plot Original & Filtered Signals
figure();
t=transpose((0:(1/Fs):(length(x)/Fs)));
t(length(t)) = [];
plot(t,x);
hold on;
plot(t,y);
xlabel('time [s] ');
ylabel('Magnitude of x(t), y(t)');
hold off;

% FFT
figure();
X=fft(x,length(x));
nf=Fs*(0:length(x)-1)/length(x);
plot(nf,abs(X));
Y=fft(y,length(y));
hold on;
nf=Fs*(0:length(x)-1)/length(x);
plot(nf,abs(Y),'r');
xlabel('f [Hz] ');
ylabel('Magnitude of X(f), Y(F)');
xlim([0 Fs/2]);
ylim([0 2000]);