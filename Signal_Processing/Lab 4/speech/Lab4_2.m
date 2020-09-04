% Lab 4
% Part 2 - Audio Quantization

% purge
clc;
clear;
close all;

% Define number of discrete levels (default N =8)
N_7bit = power(2,7);
N_4bit = power(2,4);
N_2bit = power(2,2);
N_1bit = power(2,1);

% read audio file
[x,Fs] = audioread('music.au');
maximum = max(x);
minimum = min(x);
delta7 = (maximum - minimum) / (N_7bit-1);
delta4 = (maximum - minimum) / (N_4bit-1);
delta2 = (maximum - minimum) / (N_2bit-1);
delta1 = (maximum - minimum) / (N_1bit-1);

partition7 = minimum:delta7:maximum;
codebook7 = minimum-(delta7/2):delta7:maximum+(delta7/2);
[index7,quants7] = quantiz(x,partition7,codebook7);

partition4 = minimum:delta4:maximum;
codebook4 = minimum-(delta4/2):delta4:maximum+(delta4/2);
[index4,quants4] = quantiz(x,partition4,codebook4);

partition2 = minimum:delta2:maximum;
codebook2 = minimum-(delta2/2):delta2:maximum+(delta2/2);
[index2,quants2] = quantiz(x,partition2,codebook2);

partition1 = minimum:delta1:maximum;
codebook1 = minimum-(delta1/2):delta1:maximum+(delta1/2);
[index1,quants1] = quantiz(x,partition1,codebook1);

%hold on;
%plot(x);
%plot(quants);
%xlabel('Time (seconds)');
%ylabel('Amplitude (Volts)');
%hold off;

% calculate Error
E7 = transpose(quants7) - x;
E4 = transpose(quants4) - x;
E2 = transpose(quants2) - x;
E1 = transpose(quants1) - x;

% plot error
figure();
subplot(2,2,1), histogram(E7,20);
xlabel("Bins");
ylabel("Frequency of Occurrence");
title('7 bit Quantization Error');
subplot(2,2,2), histogram(E4,20);
xlabel("Bins");
ylabel("Frequency of Occurrence");
title('4 bit Quantization Error');
subplot(2,2,3), histogram(E2,20);
xlabel("Bins");
ylabel("Frequency of Occurrence");
title('2 bit Quantization Error');
subplot(2,2,4), histogram(E1,20);
xlabel("Bins");
ylabel("Frequency of Occurrence");
title('1 bit Quantization Error');

% calculate error correlation
[r7,lags7]=xcorr(E7,200,'unbiased');
[r4,lags4]=xcorr(E4,200,'unbiased');
[r2,lags2]=xcorr(E2,200,'unbiased');
[r1,lags1]=xcorr(E1,200,'unbiased');

% plot error correlation
figure();
subplot(2,2,1), plot(lags7,r7);
xlabel("Lags");
ylabel("Auto-Correlation");
title('7 bit Auto-Correlation');
subplot(2,2,2), plot(lags4,r4);
xlabel("Lags");
ylabel("Auto-Correlation");
title('4 bit Auto-Correlation');
subplot(2,2,3), plot(lags2,r2);
xlabel("Lags");
ylabel("Auto-Correlation");
title('2 bit Auto-Correlation');
subplot(2,2,4), plot(lags1,r1);
xlabel("Lags");
ylabel("Auto-Correlation");
title('1 bit Auto-Correlation');

[c7,lags7]=xcorr(E7,quants7,200,'unbiased');
[c4,lags4]=xcorr(E4,quants4,200,'unbiased');
[c2,lags2]=xcorr(E2,quants2,200,'unbiased');
[c1,lags1]=xcorr(E1,quants1,200,'unbiased');

% cross correlation
figure();
subplot(2,2,1), plot(lags7,c7);
xlabel("Lags");
ylabel("Cross-Correlation");
title('7 bit Cross-Correlation');
subplot(2,2,2), plot(lags4,c4);
xlabel("Lags");
ylabel("Cross-Correlation");
title('4 bit Cross-Correlation');
subplot(2,2,3), plot(lags2,c2);
xlabel("Lags");
ylabel("Cross-Correlation");
title('2 bit Cross-Correlation');
subplot(2,2,4), plot(lags1,c1);
xlabel("Lags");
ylabel("Cross-Correlation");
title('1 bit Cross-Correlation');

% Signal to Noise Ratio
% Sum of value*value from 1 to size()
% Divided by size()

% Calculate Py, the power in the output
Py7 = (sum(quants7.*quants7))./size(quants7);
Py4 = (sum(quants4.*quants4))./size(quants4);
Py2 = (sum(quants2.*quants2))./size(quants2);
Py1 = (sum(quants1.*quants1))./size(quants1);

% Calculate Pe, the power in the error signal
Pe7 = (sum(E7.*E7))./size(E7);
Pe4 = (sum(E4.*E4))./size(E4);
Pe2 = (sum(E2.*E2))./size(E2);
Pe1 = (sum(E1.*E1))./size(E1);

% PSNR = Py / Pe
PSNR7 = Py7/Pe7;
PSNR4 = Py4/Pe4;
PSNR2 = Py2/Pe2;
PSNR1 = Py1/Pe1;

PSNR = [PSNR7 PSNR4 PSNR2 PSNR1];
PSNR = 1 ./ PSNR;

figure();
plot(PSNR);