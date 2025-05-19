%В неориентированном графе построить наибольшее независимое множество 

edge(1, 2). 
edge(2, 3).  
edge(2, 4).  
edge(1, 5).  
edge(5, 2). 
edge(5, 6).  
edge(6, 2).  

vertices(V) :- 
    findall(X, (edge(X, _); edge(_, X)), VList), 
    sort(VList, V).

is_independent([]). 
is_independent([V|Vs]) :- 
    \+ (member(U, Vs), (edge(V, U); edge(U, V))), 
    is_independent(Vs).

subset([], []). 
subset([X|Xs], [X|Ys]) :- 
    subset(Xs, Ys).
subset([_|Xs], Ys) :- 
    subset(Xs, Ys).

max_size_set([], [], 0). 
max_size_set([Set|Sets], MaxSet, MaxSize) :- 
    max_size_set(Sets, TempMaxSet, TempMaxSize), 
    length(Set, Size), 
    (Size > TempMaxSize -> 
        MaxSet = Set, MaxSize = Size 
    ; 
        MaxSet = TempMaxSet, MaxSize = TempMaxSize
    ).

max_independent_set(MaxSet) :- 
    vertices(V), 
    findall(Set, (
        subset(V, Set), 
        is_independent(Set)
    ), Candidates), 
    max_size_set(Candidates, MaxSet, MaxSize), 
    write('Max independent set: '), write(MaxSet), 
    nl, 
    write('Size: '), write(MaxSize), 
    nl.