%Histogram Equalization
close all
clear
clc

filename = 'cheetah.jpg';

f = imread(filename);

figure, imshow(f) %original Image
title('Original Image');

figure, imhist(f)
title('Histogram Image');

g=histeq(f,256);
figure, imshow(g)
title('Histogram Equationed Image');

figure, imhist(g)
title('His Histogram Equationed Image');

hnorm=imhist(f)./numel(f); % Nomalized
cdf=cumsum(hnorm);
x=linspace(0,1,256);
figure,plot(x,cdf);
title('x vs. cdf');