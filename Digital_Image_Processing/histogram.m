function hist = histogram(image)
% Histogram generates an array containing the occurances at each intensity
% value of a given image input

    hist = zeros(256,1);

    for i = 1:size(image,1)
        for j = 1:size(image,2)
            r = image(i,j);
            hist(r+1) = hist(r+1) + 1;
        end
    end
end