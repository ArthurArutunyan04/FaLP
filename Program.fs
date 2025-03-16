open System


type SolveQuadratic = 
    None
    | Linear of float
    | Quadratic of float * float

let Solve a b c =
    let D = b * b - 4. * a * c
    if a = 0. then
        if b = 0. then None
        else Linear(-c/b)
    else 
        if D < 0. then None
        else Quadratic(((-b + sqrt(D))/(2. * a), (-b - sqrt(D))/(2. * a)))


[<EntryPoint>]
let main (args : string[]) =

    printfn "Hello from F#"

    let a = Double.Parse(System.Console.ReadLine())
    let b = Double.Parse(System.Console.ReadLine())
    let c = Double.Parse(System.Console.ReadLine())


    let result = Solve a b c
    match result with
        None -> System.Console.WriteLine("Нет решений")
        | Linear(x) -> System.Console.WriteLine("Линейное уравнение, корень :{0}", x)
        | Quadratic(x1, x2) -> System.Console.WriteLine("Корни уравнения: {0}, {1}", x1, x2) 
    0