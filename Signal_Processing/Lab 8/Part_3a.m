close all
clear
clc

filename = 'eagle.jpg';

f = imread(filename);
A = im2double(f);

X = [1 1 1; 1 1 1;1 1 1]/9;
Y = imfilter(A,X);
X = [1 2 1; 2 4 2;1 2 1]/16;
Z = imfilter(A,X);

subplot(2,2,1), imshow(f)
title('Original Image');
subplot(2,2,2), imshow(Y)
title('Lowpass 1 Filtered Image');
subplot(2,2,4), imshow(Z)
title('Lowpass 2 Filtered Image');