clear; close all; clc;
n = 1997065901;
e = 13;
factors = factor(n);
d = generatePrivateRSA(e,n);
fprintf("Prime factors of %s are %s\n", num2str(n),num2str(factors));
fprintf("Private Decryption key that is a counterpart to %s given modulo %s is %s\n", num2str(e), num2str(n), num2str(d));