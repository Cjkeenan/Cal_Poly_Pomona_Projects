clc
close all
clear

% Quantize audio signal and store Error along with quantized signal
[quants1, E1, Fs(1)] = AudioQuantization('hideaway.au', 1);
[quants2, E2, Fs(2)] = AudioQuantization('hideaway.au', 2);
[quants3, E3, Fs(3)] = AudioQuantization('hideaway.au', 3);
[quants4, E4, Fs(4)] = AudioQuantization('hideaway.au', 4);
[quants5, E5, Fs(5)] = AudioQuantization('hideaway.au', 5);
[quants6, E6, Fs(6)] = AudioQuantization('hideaway.au', 6);
[quants7, E7, Fs(7)] = AudioQuantization('hideaway.au', 7);
E = cat(2,E1,E2,E3,E4,E5,E6,E7);
quants = cat(2,transpose(quants1),transpose(quants2),transpose(quants3),transpose(quants4),transpose(quants5),transpose(quants6),transpose(quants7));

clearvars E7 E1 E2 E3 E4 E5 E6
clearvars quants7 quants1 quants2 quants3 quants4 quants5 quants6


% Signal to Noise Ratio
% Sum of value*value from 1 to size()
% Divided by size()

% Calculate Py, the power in the output
Py = (sum(quants.*quants))./size(quants,1);
% Calculate Pe, the power in the error signal
Pe = (sum(E.*E))./size(E,1);
% PSNR = Py / Pe
PSNR = Py ./ Pe;
% Signal Distortion
PSNR = 1 ./ PSNR;

%%Plot Distortion Curve
bit = 1:7;
Kbps = (Fs.*bit) ./ power(2,10);

% Fit: 'Distortion Rate Fit Curve'.
[xData, yData] = prepareCurveData( Kbps, PSNR );
% Set up fittype and options.
ft = fittype( 'power1' );
opts = fitoptions( 'Method', 'NonlinearLeastSquares' );
opts.Display = 'Off';
opts.StartPoint = [226149.65708724 -4.63159278137297];
% Fit model to data.
[fitresult, gof] = fit( xData, yData, ft, opts );
% Plot fit with data.
figure( 'Name', 'Rate-Distortion Curve' );
h = plot( fitresult, xData, yData );
legend( h, 'PSNR vs. Kbps', 'Rate-Distortion Curve', 'Location', 'NorthEast' );
% Label axes
xlabel 'Bit-Rate(Kbps)'
ylabel 'Signal Distortion(PSNR)'
grid on
% Label curve equation
xpos=9;
ypos=9;
txt = sprintf('y = %.3f*x^{%.3f}',fitresult.a, fitresult.b);
text(xpos,ypos,txt);
