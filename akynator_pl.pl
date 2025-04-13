lang(ruby).
lang(c_sharp).
lang(python).
lang(c_plus_plus).
lang(f_sharp).
lang(prolog).
lang(c).
lang(asm).
lang(java).
lang(js).
lang(go).
lang(rust).


decl(ruby, 1).
decl(c_sharp, 1).
decl(python, 1).
decl(c_plus_plus, 1).
decl(f_sharp, 1).
decl(prolog, 1).
decl(c, 0).
decl(asm, 0).
decl(java, 1).
decl(js, 1).
decl(go, 1).
decl(rust, 1).


interpret(ruby, 1).
interpret(python, 1).
interpret(f_sharp, 1).
interpret(prolog, 1).
interpret(c_sharp, 0).
interpret(c_plus_plus, 0).
interpret(c, 0).
interpret(asm, 0).
interpret(java, 0).
interpret(js, 1).
interpret(go, 0).
interpret(rust, 0).


oop(ruby, 3).
oop(c_sharp, 3).
oop(python, 2).
oop(c_plus_plus, 2).
oop(f_sharp, 1).
oop(prolog, 1).
oop(c, 0).
oop(asm, 0).
oop(java, 3).
oop(js, 2).
oop(go, 1).
oop(rust, 2).


cross(ruby, 1).
cross(python, 1).
cross(c_plus_plus, 1).
cross(prolog, 1).
cross(c, 1).
cross(asm, 1).
cross(c_sharp, 0).
cross(f_sharp, 0).
cross(java, 1).
cross(js, 1).
cross(go, 1).
cross(rust, 1).


visual(c_sharp, 3).
visual(ruby, 2).
visual(python, 2).
visual(c_plus_plus, 2).
visual(f_sharp, 2).
visual(prolog, 1).
visual(c, 0).
visual(asm, 0).
visual(java, 2).
visual(js, 2).
visual(go, 2).
visual(rust, 2).


mobile(c_sharp, 0).
mobile(ruby, 0).
mobile(python, 0).
mobile(c_plus_plus, 0).
mobile(f_sharp, 0).
mobile(prolog, 0).
mobile(c, 0).
mobile(asm, 0).
mobile(java, 1).
mobile(js, 1).
mobile(go, 0).
mobile(rust, 0).


strict_typing(ruby, 0).
strict_typing(c_sharp, 1).
strict_typing(python, 0).
strict_typing(c_plus_plus, 1).
strict_typing(f_sharp, 1).
strict_typing(prolog, 0).
strict_typing(c, 1).
strict_typing(asm, 0).
strict_typing(java, 1).
strict_typing(js, 0).
strict_typing(go, 1).
strict_typing(rust, 1).


speed(ruby, 0).
speed(c_sharp, 2).
speed(python, 0).
speed(c_plus_plus, 3).
speed(f_sharp, 2).
speed(prolog, 1).
speed(c, 3).
speed(asm, 3).
speed(java, 2).
speed(js, 1).
speed(go, 2).
speed(rust, 3).


question1(X1):-	
	write("Is your language declarative?"), nl,
	write("1. Yes"), nl,
	write("0. No"), nl,
	read(X1).

question2(X2):-	
	write("Is your language interpreted?"), nl,
	write("1. Yes"), nl,
	write("0. No"), nl,
	read(X2).

question3(X3):-	
	write("Does your language support object-oriented programming?"), nl,
	write("3. Full object-oriented"), nl,
	write("2. Yes"), nl,
	write("1. Yes, but hard to use"), nl,
	write("0. No"), nl,
	read(X3).

question4(X4):-	
	write("Is your language cross-platform?"), nl,
	write("1. Yes"), nl,
	write("0. No"), nl,
	read(X4).

question5(X5):-	
	write("Does your language support visual user interfaces?"), nl,
	write("3. It is visual by design"), nl,
	write("2. Yes"), nl,
	write("1. Yes, but hard to use"), nl,
	write("0. No"), nl,
	read(X5).

question6(X6):-	
	write("Is your language used in mobile development?"), nl,
	write("1. Yes"), nl,
	write("0. No"), nl,
	read(X6).

question7(X7):-	
	write("Does your language support strict typing?"), nl,
	write("1. Yes"), nl,
	write("0. No"), nl,
	read(X7).

question8(X8):-	
	write("How fast does your language execute code?"), nl,
	write("3. Very fast"), nl,
	write("2. Fast"), nl,
	write("1. Medium"), nl,
	write("0. Slow"), nl,
	read(X8).

pr:- 
    	question1(X1),
    	question2(X2),
    	question3(X3),
    	question4(X4),
	question5(X5),
	question6(X6),
	question7(X7),
	question8(X8),
	decl(Lang, X1),
	interpret(Lang, X2),
	oop(Lang, X3),
	cross(Lang, X4),
	visual(Lang, X5),
	mobile(Lang, X6),
	strict_typing(Lang, X7),
	speed(Lang, X8),
	write("Your language is: "), write(Lang), nl.

