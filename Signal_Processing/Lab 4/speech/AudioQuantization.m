function [quants, E, Fs] = AudioQuantization(audiofile,bits)
    N = power(2,bits);
    
    % read audio file
    [x,Fs] = audioread(audiofile);
    maximum = max(x);
    minimum = min(x);
    delta = (maximum - minimum) / (N - 1);
    
    partition = minimum:delta:maximum;
    codebook = minimum-(delta/2):delta:maximum+(delta/2);
    [index,quants] = quantiz(x,partition,codebook);
    
    %Calculate Error, Error auto-correlation, Error cross-correlation
    E = transpose(quants) - x;
    [r,lags1]=xcorr(E,200,'unbiased');
    [c,lags2]=xcorr(E,quants,200,'unbiased');
    
    
    %Plot Errors
    figure();
    
    %Quantized Signal
    subplot(2,2,1), 
    hold on;
    plot(x);
    plot(quants);
    hold off;
    xlabel('Time (seconds)');
    ylabel('Amplitude (Volts)');
    title(bits + "-bit Quantization");
    
    %Error
    subplot(2,2,2), histogram(E,20);
    xlabel("Bins");
    ylabel("Frequency of Occurence");
    title(bits + "-bit Quantization Error");
    
    %Auto Correlation
    subplot(2,2,3), plot(lags1,r);
    xlabel("Lags");
    ylabel("Auto-Correlation");
    title(bits + "-bit Auto-Correlation");
    
    %Cross correlation
    subplot(2,2,4), plot(lags2,c);
    xlabel("Lags");
    ylabel("Cross-Correlation");
    title(bits + "-bit Cross-Correlation");
end

