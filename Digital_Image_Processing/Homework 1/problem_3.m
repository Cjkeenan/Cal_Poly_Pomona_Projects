close all
clear

% Import image
watch = imread('Im-1-3.tif');

% Downscaling image by a set factor
factor = 3;
x = 0;
for i=1:size(watch,1)
    y = 1;
    copyX = (mod(i,factor)==0);
    if(copyX)   x = x+1;    end
    for j=1:size(watch,2) 
        copyY = (mod(j,factor)==0);
        if(copyX && copyY)
            watch_downscaled(x,y) = watch(i,j);
            y = y + 1;
        end
    end
end

% Upscaling previously downscaled image by 3 times
x = -2;
watch_downscaled(1,1) = 0;
for i=1:size(watch_downscaled,1)
    y = 1;
    x = x + 3;
    for j=1:size(watch_downscaled,2)
        value = watch_downscaled(i,j);
        watch_upscaled(x,y)     = value;
        watch_upscaled(x,y+1)   = value;
        watch_upscaled(x,y+2)   = value;
        
        watch_upscaled(x+1,y)   = value;
        watch_upscaled(x+1,y+1) = value;
        watch_upscaled(x+1,y+2) = value;
        
        watch_upscaled(x+2,y)   = value;
        watch_upscaled(x+2,y+1) = value;
        watch_upscaled(x+2,y+2) = value;
        y = y + 3;
    end
end

% watch_downscaled = bilinearInterpolation(watch,[295 225]);
watch_upscaled = bilinearInterpolation(watch_downscaled,[886 675]);

% watch_downscaled_baseline = imresize(watch,1/3);
% watch_upscaled_baseline = imresize(watch_downscaled_baseline,3);

figure();
subplot(1,3,1)
imshow(watch);
title('Original Image');
subplot(1,3,2)
imshow(watch_downscaled);
title('1/3 Scaled Image');
subplot(1,3,3)
imshow(watch_upscaled);
title('x3 1/3 Scaled Image');

imwrite(watch_downscaled,'downscaled.tif');
imwrite(watch_upscaled,'upscaled.tif');
info_original = imfinfo('Im-1-3.tif');
info_downscaled = imfinfo('upscaled.tif');
info_upscaled = imfinfo('upscaled.tif');

dpi_original(1) = info_original.XResolution;
dpi_original(2) = info_original.YResolution;
dpi_downscaled(1) = info_downscaled.XResolution;
dpi_downscaled(2) = info_downscaled.YResolution;
dpi_upscaled(1) = info_upscaled.XResolution;
dpi_upscaled(2) = info_upscaled.YResolution;