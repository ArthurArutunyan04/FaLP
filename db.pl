%Task1_1
man(anatoliy).
man(dimitriy).
man(vlad).
man(kirill).
man(mefodiy).
woman(vladina).
woman(galya).
woman(sveta).
woman(zoya).
woman(katrin).
dite(dimitriy, anatoliy).
dite(dimitriy, galya).
dite(vladina, anatoliy).
dite(vladina, galya).
dite(kirill, dimitriy).
dite(mefodiy, dimitriy).
dite(kirill, sveta).
dite(mefodiy, sveta).
dite(zoya, vlad).
dite(zoya, vladina).
dite(katrin, vlad).
dite(katrin, vladina).


%Task1_2 
man :-
    	man(X),
    	write(X), nl,
    	fail.
man.

woman :-
    	woman(X),
    	write(X), nl,
    	fail.
woman.


%Task1_3
parent(Parent, Child) :- dite(Child, Parent).

children(X) :-
	parent(X, Child),
    	write(Child), nl,
    	fail.
children(_).


%Task1_4
mother(X, Y) :-
    	woman(X),
    	parent(X, Y).

mother(X):-
    	parent(M, X),
    	woman(M),
    	write(M), nl.


%Task1_5
brother(X, Y) :-
	man(X),
    	X \= Y,
    	parent(P, X),
   	parent(P, Y).

brothers(X) :-
	brother(Y, X),
   	write(Y), nl,
    	fail.
brothers(_).


%Task1_6
b_s(X, Y):-
	X \= Y,
	parent(P,X),
	parent(P,Y).
       	
b_s(X):-
	b_s(X,Y),
	write(Y), nl,
	fail.
b_s(_).


%Task2
father(X, Y) :-
    	man(X),
    	parent(X, Y).

father(X) :-
    	parent(F, X),
    	man(F),
    	write(F), nl.

sister(X, Y) :-
    	woman(X),
    	X \= Y,
    	parent(P, X),
    	parent(P, Y).

sisters(X) :-
    	sister(Y, X),
    	write(Y), nl,
    	fail.
sisters(_).


%Task3
grand_pa(X, Y) :-
    	man(X),
    	parent(X, P),
    	parent(P, Y).

grand_pas(X) :-
    	grand_pa(Y, X),
   	write(Y), nl,
    	fail.
grand_pas(_).


grand_pa_and_son(X, Y) :-
    	grand_pa(X, Y).


uncle(X, Y) :-
    	man(X),
    	parent(P, Y),
    	brother(X, P).

uncles(X) :-
    	uncle(Y, X),
    	write(Y), nl,
    	fail.
uncles(_).




