close all
clear

% initially load image
y = imread('Im-1-4.tif');
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
b = 7;
N = power(2,b);

% generate delta
minimum = min(min(z));
maximum = max(max(z));
delta = (maximum - minimum) / (N - 1);

for i=1:size(y,1)
    for j=1:size(y,2)
        z(i,j) = z(i,j) - minimum;
        z(i,j) = z(i,j)/delta;
        z(i,j) = round(z(i,j));
        z(i,j) = z(i,j)*delta;
        z(i,j) = z(i,j)+minimum;        
    end
end

subplot(1,2,1)
image(y);
colormap(gray(256));
axis('image');
title('Original Image');
subplot(1,2,2)
image(z);
colormap(gray(256));
axis('image');
title(['Modified Image: ', num2str(N),' levels']);