close all
clear
clc

filename = 'eagle.jpg';

f = imread(filename);
subplot(2,2,1), imshow(f)
title('Original Image');

F = fft2(im2double(f));
S = abs(F);
subplot(2,2,2), imshow(S,[]);
title('Original FFT');

Fc = fftshift(F);
S = abs(Fc);
subplot(2,2,3), imshow(S,[]);
title('Shifted FFT');

S2 = 0.5*log(1+abs(Fc));
subplot(2,2,4), imshow(S2,[]);
title('Log-Scaled Shifted FFT');

% Average Value
[M,N]=size(f);
S=double(f);
sum=0;

for m=1:M
 for n=1:N
 sum=S(m,n)+sum;
 end
end

A=sum/(M*N);