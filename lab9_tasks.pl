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
   	sum_list_down(H, Sum),
    	(Sum =:= TargetSum ->
        	remove_with_digit_sum(T, TargetSum, Result)
	;                           
        	Result = [H|Rest],      	
        	remove_with_digit_sum(T, TargetSum, Rest)
    	).


%Task2_1
%mult_digits(+Number, -Product)
mult_digits(0, 1).
mult_digits(N, Product) :-
    	abs(N, AbsN),  
    	mult_digits(AbsN, 1, Product).
mult_digits(0, Acc, Acc).
mult_digits(N, Acc, Product) :-
    	Digit is N mod 10,
    	NewAcc is Acc * Digit,
    	NewN is N // 10,
    	mult_digits(NewN, NewAcc, Product).


%Task2_2
%count_odd_gt3(+Number, -Count)
count_odd_gt3(N, Count) :-
    	abs(N, AbsN),
    	count_odd_gt3(AbsN, 0, Count).
count_odd_gt3(0, Acc, Acc).
count_odd_gt3(N, Acc, Count) :-
    	Digit is N mod 10,
    	(Digit > 3, 1 is Digit mod 2 -> 
        	NewAcc is Acc + 1
    	; 
        	NewAcc is Acc
    	),
    	NewN is N // 10,
    	count_odd_gt3(NewN, NewAcc, Count).


%Task2_3
%gcd(+A, +B, -Result)
gcd(A, 0, A) :- !.
gcd(0, B, B) :- !.
gcd(A, B, Result) :-
    	A > B,
    	Remainder is A mod B,
    	gcd(B, Remainder, Result).
gcd(A, B, Result) :-
    	B > A,
    	gcd(B, A, Result).


%Task3_1
%count_after_last_max(+List, -Count)
count_after_last_max(List, Count) :-
    max_list(List, Max),
    append(_, [Max|Tail], List),
    length(Tail, Count).   


%Task3_13
%move_before_min_to_end(+List, -Result)
move_before_min_to_end(List, Result) :-
    min_list(List, Min),
    split_before(List, Min, Before, After),
    append(After, Before, Result).
split_before([X|T], X, [], [X|T]) :- !.
split_before([H|T], X, [H|Before], After) :-
    split_before(T, X, Before, After).


%Task3_25
%max_in_interval(+List, +A, +B, -Max)
max_in_interval(List, A, B, Max) :-
    include(between(A,B), List, Filtered),
    max_list(Filtered, Max).
