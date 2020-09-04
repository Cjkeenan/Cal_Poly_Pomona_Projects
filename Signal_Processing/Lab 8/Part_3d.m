close all
clear
clc

filename = 'eagle.jpg';

f = imread(filename);
A = im2double(f);

A = im2double(A);
X = [-1 -1 -1;-1 8 -1;-1 -1 -1];
Y1 = imfilter(A,X,'replicate');
Y2 = A + imfilter(A,X,'replicate');

subplot(2,2,1), imshow(f)
title('Original Image');
subplot(2,2,2), imshow(Y1)
title('Laplacian Image');
subplot(2,2,4), imshow(Y2)
title('Scaled Image');
