open System
open WorkingWithNumbers.NumberFunctions
open WorkingWithNumbers.ListFunctions


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

let choosee_method (func_num, num) : unit =
    match func_num with
    | 1 -> sum_prime_divisors num |> Console.WriteLine
    | 2 -> count_odd_digit_greater_three num |> Console.WriteLine
    | 3 -> product_divisors_digit_sum_less_than_original num |> Console.WriteLine
    | _ -> Console.WriteLine("Неверный номер")


type Widget = { ID: int; Rev: int }


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

    // Задание 11
    System.Console.WriteLine("Введите любимый язык программирования")
    let language = System.Console.ReadLine()
    let favorite_language = respond_favorite_language  language
    System.Console.WriteLine(favorite_language)

    //Задание 13 
    let sum_coprime  = traverse_coprime 5003 (fun acc digit -> acc + digit) 0 
    System.Console.WriteLine("Сумма взаимно простых цифр: {0}", sum_coprime)

    let min_coprime = traverse_coprime 5003 (fun acc digit -> min acc digit) 9
    System.Console.WriteLine("Минимальная взаимно простая цифра: {0}", min_coprime)


    // Задание 14
    let count_coprime = euler_phi 1234
    System.Console.WriteLine("Функция Эйлера φ({0}) = {1}", 12, count_coprime)

    // Задание 15
    let sum_coprime_with_condition = traverse_coprime_condition 5003 (fun acc digit -> acc + digit) 0 (fun d -> d % 2 <> 0)
    System.Console.WriteLine("Сумма нечетных взаимно простых цифр: {0}", sum_coprime_with_condition)

    let count_coprime_with_condition = traverse_coprime_condition 5003 (fun acc _ -> acc + 1) 0 (fun d -> d > 3)
    System.Console.WriteLine("Количество взаимно простых цифр > 3: {0}", count_coprime_with_condition)

    // Задание 16.1
    let prime_divisors_sum = sum_prime_divisors 28
    System.Console.WriteLine("Сумма простых делителей {0}", prime_divisors_sum)

    // Задание 16.2
    let odd_digits_count = count_odd_digit_greater_three 75124
    System.Console.WriteLine("Количество нечетных цифр числа, больших 3: {0}", odd_digits_count)

    // Задание 16.3
    let product_divisors = product_divisors_digit_sum_less_than_original 28
    System.Console.WriteLine("Произведение делителей числа, сумма цифр которых меньше суммы цифр числа: {0}", product_divisors)

    // Задание 20
    Console.Write("Введите номер функции и число через запятую: ")
    Console.ReadLine()
    |> fun input -> 
        input.Split(',') 
        |> Array.map int
        |> fun values -> (values.[0], values.[1])
    |> choosee_method
*)

    // Задание 1
(*    Console.Write("Введите количество элементов: ")
    let n = Console.ReadLine() |> int
    let lst = readList n
    Console.WriteLine("Полученный список: {0}", lst)
*)
    // Задание 2
    // let list  = read_list 5
(* 
    print_list list 

    // Задание 3
    let filtred_list = filtered_fold list (+) (fun x -> x % 2 = 0) 0
    Console.WriteLine("Полученное значение: {0}", filtred_list) 

    // Задание 4

    let min_element = filtered_fold list (min) (fun _ -> true) Int32.MaxValue
    Console.WriteLine("Минимальный элемент: {0}", min_element) 
    
    let sum_even_elements = filtered_fold list (+) (fun x -> x % 2 = 0) 0
    Console.WriteLine("Сумма четных элементов: {0}", sum_even_elements) 

    let count_odd_elements = filtered_fold list (fun acc _ -> acc + 1) (fun x -> x % 2 <> 0) 0
    Console.WriteLine("Количество нечетных элементов: {0}", count_odd_elements) 

    // Задание 5
    let freq_element = most_frequent_element list
    Console.WriteLine("Самый частный элемен: {0}", freq_element) 

    // Задание 6
    Console.Write("Количестве элементов дерева: ")
    let count = Console.ReadLine() |> int
    let numbers = read_list count
    let tree = build_tree numbers
    Console.WriteLine("Построенное дерево:")
    print_tree tree

    // Задание 7
    let frequent_element = frequent_element list
    Console.WriteLine("Самый частный элемен: {0}", frequent_element) 

    // Задание 8
    let count_squares = count_quares list
    Console.WriteLine("Количество квадратов: {0}", count_squares) 

    // Задание 9 
    // Console.WriteLine("Список А: ") 
    // let listA  = read_list 3
    // Console.WriteLine("Список B: ") Дан целочисленный массив, в котором лишь один элемент
отличается от остальных. Необходимо найти значение этого элемента.
    // let listB  = read_list 3
    // Console.WriteLine("Список С: ") 
    // let listC  = read_list 3
    let list_tuples = create_tuples [10;20;30] [123;111;432] [12;24;36]
    Console.WriteLine("Полученные картежи: {0}", list_tuples) 

    // Задание 10
    let strings = read_strings ()
    let sortedStrings = sort_string_length strings
    Console.WriteLine("Отсортированный список: {0}", String.Join("", sortedStrings))

    // Задание 11
    // 11.1
    let lst1 = [1; 5; 3; 5; 2]
    Console.WriteLine("Количество элементов после последнего максимального: {0}", count_after_last_max lst1)    
    Console.WriteLine("Количество элементов после последнего максимального: {0}", countAfterLastMax lst1)     

    // 11.11
    let lst2 = [1; 3; 5; 3; 2; 5; 1]
    Console.WriteLine("Уникальный элемент: {0}", find_unique lst2)
    Console.WriteLine("Уникальный элемент: {0}", findUnique lst2)

    // 11.21
    let lst3 = [1; 5; 3; 5; 2]
    Console.WriteLine("Элементы после первого максимального: {0}", after_first_max lst3)
    Console.WriteLine("Элементы после первого максимального: {0}", afterFirstMax lst3)
    
    // 11.31
    let lst4 = [1; 2; 3; 4; 5; 6]
    Console.WriteLine("Кол-во четных элементов: {0}", count_even lst4)
    Console.WriteLine("Кол-во четных элементов: {0}", countEven lst4)
   
    // 11.41
    let lst5 = [-2; 1; -3; 4]
    Console.WriteLine("Среднее арифметическое модулей: {0}", average_abs lst5)
    Console.WriteLine("Среднее арифметическое модулей: {0}", averageAbs lst5)

    // 11.51
    let lst6 = [1; 3; 1; 2; 3; 3]
    Console.WriteLine(split_unique_counts lst6)
    Console.WriteLine(splitUniqueCounts lst6)
*)

    // Задание 17
    let list1 = [1; 2; 3; 4; 5]
    let list2 = [2; 4; 1; 5]
    Console.WriteLine("Наибольшая общая подпоследовательность: {0}", longest_subsequence list1 list2)  

    0