open System
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

let func bool_ = 
    match bool_ with 
        true -> sum_digits_down
        | false -> factorial


let respond_favorite_language language = 
    match language with 
    "F#" | "Prolog" -> "Ну конечно, подлиза!"
    | "Ruby" -> "Легенда"
    | "R" | "VB" -> "Зря."
    | "C#" |"C++" -> "Чел, ..."
    | "Java" | "JS" -> "Выбор нормального человека"
    | "Python" -> "Фрик"
    | "PHP" | "GO" | "Rust" -> "Норм"
    | _ -> "Это какой-то нн?"


[<EntryPoint>]
let main (args : string[]) =
(*
    // Задание 1
    printfn "Hello from F#"

    // Задание 2
    System.Console.WriteLine("Введите коэффициенты уравнения a, b, c:")
    let a = Double.Parse(System.Console.ReadLine())
    let b = Double.Parse(System.Console.ReadLine())
    let c = Double.Parse(System.Console.ReadLine())


    let result = Solve a b c
    match result with
        None -> System.Console.WriteLine("Нет решений")
        | Linear(x) -> System.Console.WriteLine("Линейное уравнение, корень :{0}", x)
        | Quadratic(x1, x2) -> System.Console.WriteLine("Корни уравнения: {0}, {1}", x1, x2) 


    // Задание 3
    System.Console.WriteLine("Введите радиус и высоту:")
    let radius = Double.Parse(System.Console.ReadLine())
    let height = Double.Parse(System.Console.ReadLine())

    let square_circle = circle_square radius
    System.Console.WriteLine("Площадь круга: {0}", square_circle)

    let vulume_superpos = cylinder_volume_superpos (radius, height)
    System.Console.WriteLine("Объем цилиндра с использованием суперпозиции: {0}", vulume_superpos)
    
    let vulume_carry = cylinder_volume_carry radius height
    System.Console.WriteLine("Объем цилиндра с использованием суперпозиции: {0}", vulume_carry)

    // Задание 4-5 
    System.Console.WriteLine("Введите число:")
    let number = Int32.Parse(System.Console.ReadLine())    

    let sum_rec_top = sum_digits_top number
    System.Console.WriteLine("Сумма цифр с использованием рекурсии вверх {0}", sum_rec_top)

    let sum_rec_down = sum_digits_down number
    System.Console.WriteLine("Сумма цифр с использованием рекурсии ввниз {0}", sum_rec_down)

    // Задание 6
    let test =  func true number
    System.Console.WriteLine("Ответ: {0}", test)

    let test =  func false number
    System.Console.WriteLine("Ответ: {0}", test)


    // Задание 7-8
    let sum_digits = traverse 132 (fun acc digit -> acc + digit) 0
    System.Console.WriteLine("Сумма цифр: {0}", sum_digits)

    let product_digits = traverse 132 (fun acc digit -> acc * digit) 1
    System.Console.WriteLine("Произведение цифр: {0}", product_digits)

    let min_digit = traverse 132 (fun acc digit -> min acc digit) 9
    System.Console.WriteLine("Минимальная цифра: {0}", min_digit)

    let max_digit = traverse 132 (fun acc digit -> max acc digit) 0
    System.Console.WriteLine("Максимальная цифра: {0}", max_digit)


    // Задание 9-10
    let sum_even = traverse_condition 7214 (fun acc digit -> acc + digit) 0 (fun digit -> digit % 2 = 0)
    System.Console.WriteLine("Сумма четных цифр: {0}", sum_even)

    let product_odd = traverse_condition 7214 (fun acc digit -> acc * digit) 1 (fun digit -> digit % 2 <> 0)
    System.Console.WriteLine("Произведение нечетных цифр: {0}", product_odd)

    let min_greater_2 = traverse_condition 7214 (fun acc digit -> min acc digit) 9 (fun digit -> digit > 2)
    System.Console.WriteLine("Минимальная цифра > 2: {0}", min_greater_2)

    let max_less_5 = traverse_condition 7214 (fun acc digit -> max acc digit) 0 (fun digit -> digit < 5)
    System.Console.WriteLine("Максимальная цифра < 5: {0}", max_less_5)
*)

    // Задание 11
    System.Console.WriteLine("Введите любимый язык программирования")
    let language = System.Console.ReadLine()
    let favorite_language = respond_favorite_language  language
    System.Console.WriteLine(favorite_language)


    0
