%Task1_1
placements_repetition(Alphabet, K, Placement) :-
    length(Placement, K),
    fill_placement(Alphabet, Placement).

fill_placement(_, []).
fill_placement(Alphabet, [X | Rest]) :-
    member(X, Alphabet),
    fill_placement(Alphabet, Rest).


%Task1_2
combinations_no_repetition(_, 0, []) :- !.
combinations_no_repetition([], _, _) :- fail.
combinations_no_repetition([X|Xs], K, [X|Rest]) :-
    K > 0,
    K1 is K - 1,
    combinations_no_repetition(Xs, K1, Rest).
combinations_no_repetition([_|Xs], K, Result) :-
    K > 0,
    combinations_no_repetition(Xs, K, Result).


%Task1_6
print_all_placements(Alphabet, K) :-
    placements_repetition(Alphabet, K, Placement),
    writeln(Placement),
    fail. 
print_all_placements(_, _) :- true.


%Task1_7
print_all_combinations(Alphabet, K) :-
    combinations_no_repetition(Alphabet, K, Combination),
    writeln(Combination),  
    fail. 
print_all_combinations(_, _) :- true.


