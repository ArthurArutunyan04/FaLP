﻿open System
open WorkingWithNumbers.NumberFunctions

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


let circle_square radius =
    System.Math.PI * radius ** 2.0

let cylinder_volume_superpos (radius, height) = 
    let cylinder_base_square = 
        circle_square radius
    height * cylinder_base_square

let cylinder_volume_carry radius height =
    let cylinder_base_square = 
        circle_square radius
    height * cylinder_base_square

[<EntryPoint>]
let main (args : string[]) =
(*
    printfn "Hello from F#"


    System.Console.WriteLine("Введите коэффициенты уравнения a, b, c:")
    let a = Double.Parse(System.Console.ReadLine())
    let b = Double.Parse(System.Console.ReadLine())
    let c = Double.Parse(System.Console.ReadLine())


    let result = Solve a b c
    match result with
        None -> System.Console.WriteLine("Нет решений")
        | Linear(x) -> System.Console.WriteLine("Линейное уравнение, корень :{0}", x)
        | Quadratic(x1, x2) -> System.Console.WriteLine("Корни уравнения: {0}, {1}", x1, x2) 


    
    System.Console.WriteLine("Введите радиус и высоту:")
    let radius = Double.Parse(System.Console.ReadLine())
    let height = Double.Parse(System.Console.ReadLine())

    let square_circle = circle_square radius
    System.Console.WriteLine("Площадь круга: {0}", square_circle)

    let vulume_superpos = cylinder_volume_superpos (radius, height)
    System.Console.WriteLine("Объем цилиндра с использованием суперпозиции: {0}", vulume_superpos)
    
    let vulume_carry = cylinder_volume_carry radius height
    System.Console.WriteLine("Объем цилиндра с использованием суперпозиции: {0}", vulume_carry)
*)


    System.Console.WriteLine("Введите число:")
    let number = Int32.Parse(System.Console.ReadLine())

    let sum_rec_top = sum_digits_top number
    System.Console.WriteLine("Сумма цифр с использованием рекурсии вверх {0}", sum_rec_top)

    let sum_rec_down = sum_digits_down number
    System.Console.WriteLine("Сумма цифр с использованием рекурсии ввниз {0}", sum_rec_down)

    
    0