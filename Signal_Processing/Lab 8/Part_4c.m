close all
clear
clc

filename = 'eagle.jpg';

f = imread(filename);
subplot(2,2,1), imshow(f)
title('Original Image');

[M,N] = size(f);
F = fft2(im2double(f));
sig = 20;
u = 0:(M-1);
v = 0:(N-1);
idx = find(u>M/2);
u(idx) = u(idx) - M;
idy = find(v>N/2);
v(idy) = v(idy) - N;
[U,V] = meshgrid(v,u);
D0 = sig;
D = sqrt(U.^2+V.^2);
H = 1 - exp(-D.^2/(2*D0.^2));
G = F.*H;
g = real(ifft2(G));

subplot(2,2,2), imshow(g, [])
title('Highpass Filtered Image');

g2=double(g);
g3=g2.^0.5;
subplot(2,2,4), imshow(g3, [])
title('Highpass Filtered Varianced Image');

g4 = double(f) - g3;
subplot(2,2,3), imshow(g4, [])
title('Enhanced Image');

diff = abs(g4-double(f));
figure, imshow(diff);