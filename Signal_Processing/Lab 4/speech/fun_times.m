[orig,Fs0] = audioread('hideaway.au');
[quants8, E8, Fs8] = AudioQuantization('hideaway.au', 1);
[quants16, E16, Fs16] = AudioQuantization('hideaway.au', 2);
[quants24, E24, Fs24] = AudioQuantization('hideaway.au', 5);
[quants32, E32, Fs32] = AudioQuantization('hideaway.au', 6);

original = audioplayer(orig,Fs0);
bit32 = audioplayer(quants32,Fs32);
bit24 = audioplayer(quants24,Fs24);
bit16 = audioplayer(quants16,Fs16);
bit8 = audioplayer(quants8,Fs8);