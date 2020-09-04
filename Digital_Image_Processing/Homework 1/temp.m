tim = imread('tim.png');

tim = 255 - tim;

imwrite(tim, 'inverted_tim.png');