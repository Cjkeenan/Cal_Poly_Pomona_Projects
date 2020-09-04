close all
clear
clc

filename = 'eagle.jpg';

f = imread(filename);
A = im2double(f);

X = [-1 -1 -1; -1 8 -1;-1 -1 -1];
Y = imfilter(A,X);
X = [0 -1 0; -1 4 -1;0 -1 0];
Z = imfilter(A,X);
E = A + Y;

subplot(2,2,1), imshow(f)
title('Original Image');
subplot(2,2,2), imshow(Y)
title('Highpass 1 Filtered Image');
subplot(2,2,4), imshow(Z)
title('Highpass 2 Filtered Image');
subplot(2,2,3), imshow(E)
title('Enhanced Image');