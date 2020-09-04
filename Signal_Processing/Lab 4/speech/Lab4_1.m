% Lab 4
% Part 1 - Image Quantization

% purge
clear;
close all;

% initially load image
y = imread('moon.tif');
figure();
image(y);
colormap(gray(256));
axis('image');
z=double(y);

% delta = Max(x) - Min(x) / N - 1
% x = signal to be quantized
% N = number of quantization levels

% To force data to have uniform quantization step delta
% 1. Subtract Min(x) from data and divide result by delta
% 2. Round data to nearest integer
% 3. Multiply rounded data by delta and add Min(x) to convert
% the data back to original scale

% Define number of discrete levels (default N =8)
b = 1;
N = power(2,b);

% generate delta
minimum = min(min(z));
maximum = max(max(z));
delta = (maximum - minimum) / (N - 1);

for i=1:540
    for j=1:466
        z(i,j) = z(i,j) - minimum;
        z(i,j) = round(z(i,j));
        z(i,j) = z(i,j)*delta;
        z(i,j) = z(i,j)+minimum;        
    end
end

figure();
image(z);
colormap(gray(256));
axis('image');