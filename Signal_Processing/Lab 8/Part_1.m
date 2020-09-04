close all
clear
clc

filename = 'fig-2.jpg';

A = imread(filename);
figure; % New figure window
imshow(A); % Show image
B = A;
C = A;

% Enter the # of bits to the program
N=input('Please Enter the number of bits in gray scale (1-8): ');
Bits=2^N; % Convert the # of bits to grayscale

[X,map] = gray2ind(A,Bits); % Gray level to index conversion
Imag = ind2gray(X,map); % Index to gray level conversion

figure; % New figure window
imshow(Imag); % Show image


B = imresize(B, 0.25);
figure; % New figure window
imshow(B); % Show image

B = imresize(B, 4);
figure; % New figure window
imshow(B); % Show image