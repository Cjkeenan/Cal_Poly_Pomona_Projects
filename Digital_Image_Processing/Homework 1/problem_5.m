close all
clear

xray_1 = imread('Im-1-5a.tif');
xray_2 = imread('Im-1-5b.tif');

xray_diff = abs(xray_1 - xray_2);
xray_diff_enhan = 255 - xray_diff;

subplot(2,2,1)
imshow(xray_1)
title('Image 1')
subplot(2,2,2)
imshow(xray_2)
title('Image 2')
subplot(2,2,3)
imshow(xray_diff)
title('Difference')
subplot(2,2,4)
imshow(xray_diff_enhan)
title('Enhanced Difference')