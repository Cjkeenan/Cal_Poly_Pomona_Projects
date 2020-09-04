close all
clear
clc

filename = 'eagle.jpg';

f = imread(filename);
A = im2double(f);

X = [1 1 1; 1 -8 1;1 1 1];
Y = A - imfilter(A,X,'replicate');

subplot(1,2,1), imshow(f)
title('Original Image');
subplot(1,2,2), imshow(Y)
title('Spatial Filtered Image');