%Task1_1
max(X, Y, U, Z) :-
	max(X, Y, Temp),  
   	max(Temp, U, Z).  


max(A, B, A) :- A >= B.
max(A, B, B) :- A < B.


%Task1_2
fact_up(0, 1).
fact_up(N, X) :-
	N1 is N - 1,
    	fact_up(N1, X1),
    	X is N * X1.


fact_down(N, X) :-
    	fact_down(N, 1, X).
fact_down(0, Acc, Acc).
fact_down(N, Acc, X) :-
    	N1 is N - 1,
   	NewAcc is N * Acc,
	fact_down(N1, NewAcc, X).


%Task1_3
sum_digits_up(0, 0).  
sum_digits_up(N, Sum) :-
    	LastDigit is N mod 10,
    	Rest is N // 10,
    	sum_digits_up(Rest, SubSum),
	Sum is SubSum + LastDigit.

sum_digits_down(N, Sum) :- 
	sum_digits_down(N, 0, Sum).
sum_digits_down(0, Acc, Acc).
sum_digits_down(N, Acc, Sum) :-
	LastDigit is N mod 10,
	NewAcc is Acc + LastDigit,
	Rest is N // 10,
	sum_digits_down(Rest, NewAcc, Sum).


%Task1_4
read_list(List) :-
    	write('Введите список: '),
    	read(List).

print_list([]) :- nl.
print_list([H|T]) :-
    	write(H),
    	write(' '),
    	print_list(T).

%Task1_5
sum_list_down(List, Sum) :-
	sum_list_down(List, 0, Sum).
sum_list_down([], Acc, Acc).
sum_list_down([H|T], Acc, Sum) :-
	NewAcc is Acc + H,
	sum_list_down(T, NewAcc, Sum).

sum_list_up([], 0).
sum_list_up([H|T], Sum) :-
	sum_list_up(T, TmpSum),
	Sum is H + TmpSum.


run_program :-    
    	read_list(List),
    
    	write('Введенный список: '),
    	print_list(List),
    
    	sum_list_down(List, SumDown),
    	write('Сумма (рекурсия вниз): '), write(SumDown), nl,
    
    	sum_list_up(List, SumUp),
    	write('Сумма (рекурсия вверх): '), write(SumUp), nl.


%Task1_6
remove_with_digit_sum([], _, []).
remove_with_digit_sum([H|T], TargetSum, Result) :-
   	sum_digits_down(H, Sum),
    	(Sum =:= TargetSum ->
        	remove_with_digit_sum(T, TargetSum, Result)
	;                           
        	Result = [H|Rest],      	
        	remove_with_digit_sum(T, TargetSum, Rest)
    	).
