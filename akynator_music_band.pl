group_data([
	[metallica, 1, 1, 3, 1, 0, 2, 0],
	[linkin_park, 2, 1, 3, 3, 0, 2, 1],
	[system_of_a_down, 1, 1, 3, 3, 0, 2, 0],
	[three_days_grace, 3, 2, 3, 3, 0, 2, 0],
	[breaking_benjamin, 3, 1, 3, 3, 0, 2, 1],
	[bad_omens, 1, 1, 3, 3, 0, 2, 0],
	[bring_me_the_horizon, 1, 1, 3, 4, 0, 2, 1],
	[green_day, 2, 1, 1, 2, 0, 2, 0],
	[korn, 1, 1, 3, 3, 0, 2, 0],
	[limp_bizkit, 1, 1, 2, 3, 0, 2, 0],
	[papa_roach, 3, 1, 2, 3, 0, 2, 0],
	[asking_alexandria, 1, 1, 2, 3, 0, 2, 0],
	[rise_against, 3, 1, 1, 3, 0, 2, 0],
	[yellowcard, 2, 1, 1, 2, 0, 2, 0],
	[my_chemical_romance, 2, 1, 1, 3, 0, 2, 0],
	[pantera, 1, 1, 2, 2, 0, 2, 0],
	[evanescence, 2, 1, 1, 3, 1, 2, 1],
	[nirvana, 3, 1, 1, 2, 0, 2, 0],
	[black_sabbath, 1, 3, 2, 1, 0, 2, 0],
	[itchy, 2, 1, 1, 3, 0, 2, 0],
	[radiohead, 2, 1, 1, 3, 0, 2, 0],
	[thirty_second_to_mars, 2, 1, 1, 3, 0, 2, 0],
	[disturbed, 1, 1, 2, 3, 0, 2, 0],
	[megadeth, 1, 1, 2, 3, 0, 2, 0],
	[sum41, 2, 1, 1, 2, 0, 2, 0]
]).


question1(X1):-	
	write("Жанр группы:"), nl,
	write("1. Металл"), nl,
	write("2. Альтернатива"), nl,
	write("3. Пост-гранж"), nl,
	read(X1).

question2(X2):-	
	write("Страна происхождения группы:"), nl,
	write("1. США"), nl,
	write("2. Канада"), nl,
	write("3. Великобритания"), nl,
	read(X2).

question3(X3):-	
	write("Тип вокала группы:"), nl,
	write("1. Чистый вокал"), nl,
	write("2. Грубый вокал"), nl,
	write("3. Смешанный вокал"), nl,
	read(X3).

question4(X4):-	
	write("Эра популярности группы:"), nl,
	write("1. 70-е"), nl,
	write("2. 80-е"), nl,
	write("3. 90-е"), nl,
	write("4. 2000-е"), nl,
	write("5. 2010-е"), nl,
	read(X4).

question5(X5):-	
	write("В группе присутствует женский вокал?"), nl,
	write("1. Да"), nl,
	write("0. Нет"), nl,
	read(X5).

question6(X6):-	
	write("Сколько участников в группе?"), nl,
	write("1. 3-4 человека"), nl,
	write("2. 5-6 человек"), nl,
	write("3. Более 6"), nl,
	read(X6).

question7(X7):-	
	write("Используются ли клавишные инструменты?"), nl,
	write("1. Да"), nl,
	write("0. Нет"), nl,
	read(X7).

find_groups :-
	group_data(Groups),
	question1(Genre),
	question2(Country),
	question3(Vocal),
	question4(Era),
	question5(Female),
	question6(Members),
	question7(Keys),
	member([Name, Genre, Country, Vocal, Era, Female, Members, Keys], Groups),
	write("Группа: "), write(Name), nl.

