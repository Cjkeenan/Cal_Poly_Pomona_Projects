clear
clc

x = [0.00E+00
1.00E+03
2.00E+03
3.00E+03
4.00E+03
5.00E+03
6.00E+03
7.00E+03
8.00E+03
9.00E+03
1.00E+04
1.10E+04
1.20E+04];

y = [0
2.61
0
-6.933
0
-11.37
0
-14.292
0
-16.475
0
-18.218
0];

stem(x,y) 
title('One-sided Fourier Coefficients in dBV') 
xlabel ('Frequency (Hz)') 
ylabel('C_n (dBV)')