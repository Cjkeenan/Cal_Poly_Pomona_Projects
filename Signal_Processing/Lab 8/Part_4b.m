close all
clear
clc

filename = 'eagle.jpg';

f = imread(filename);
subplot(1,2,1), imshow(f)
title('Original Image');

[M,N] = size(f);
F = fft2(im2double(f));
sig = 20;
u = 0:(M-1);
v = 0:(N-1);
idx = find(u>M/2);
u(idx)= u(idx)-M;
idy = find(v>N/2);
v(idy)= v(idy)-N;
[U,V] = meshgrid(v,u);
D0 = sig;
D = sqrt(U.^2+V.^2);
H = exp(-D.^2/(2*D0.^2));
G = F.*H;
g = real(ifft2(G));

subplot(1,2,2), imshow(g, [])
title('Lowpass Filtered Image');