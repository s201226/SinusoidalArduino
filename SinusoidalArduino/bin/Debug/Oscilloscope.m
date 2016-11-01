function [ ] = Oscilloscope( num_val, freq )
%UNTITLED Summary of this function goes here
%   Detailed explanation goes here
    file = fopen('Measure.dat','r');
    data=zeros(1,num_val);
    for i=1:num_val
        data(i)=fscanf(file,'%d');
    end
    x=1:num_val;
    
    w=2*3.14*600000;
    for i=1:num_val
        A=[sin(w*x(i) cos(w*x(i) 1];
        U=(A*A')^-1 *A';
        lambda=A\dati;
    end
    
    plot(x,data,'-r',x,data,'ok')
    print('Graph','-dpng');
    

end

