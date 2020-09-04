clc
n=1:7;
% x=(4/3)*sinc(n/3).*exp(-1i*pi*n/3);
% x=sinc(n/2).*sinc(n/2);
x=(10)*sinc(2*n/5);
Cn=2*abs(x);
theta=(180*angle(x))/pi;
x0=3/5;
Cn=[x0 Cn];
theta=[0 theta];
CndbV=20*log10(Cn/sqrt(2));
CndbV_real = real(CndbV);
CndbV_imag = imag(CndbV);
n = [0 n];

figure, subplot (2,1,1)
stem(n,Cn) 
title('C_n (n)') 
xlabel ('n') 
ylabel('C_n)') 
subplot (2,1,2) 
stem(n,theta) 
title('\theta_n (n)') 
xlabel ('n') 
ylabel('\theta_n)') 
ylabel('\theta_n')

n2=-7:7;
% x2=(4/3)*sinc(n2/3).*exp(-1i*pi*n2/3);
x2=(10)*sinc(2*n2/5);
theta2=(180*angle(x2))/pi;
x2_real = real(x2);
x2_imag = imag(x2);
x2(8) = x0;

figure, subplot (2,1,1)
stem(n2,x2) 
title('X_n (n)') 
xlabel ('n') 
ylabel('X_n)') 
subplot (2,1,2) 
stem(n2,theta2) 
title('\theta_n (n)') 
xlabel ('n') 
ylabel('\theta_n)') 
ylabel('\theta_n')
