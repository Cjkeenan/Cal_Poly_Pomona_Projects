function [sum] = summation(array, from, to)
%Summation calculates the summation from 'from' to 'to' in array 'array'
    sum = 0;
    for i = from:to+1
        sum = sum + array(i);
    end
end