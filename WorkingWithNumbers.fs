namespace WorkingWithNumbers
open System


module NumberFunctions =

    let sum_digits_down number = 
        let rec sum_digit number current_sum =
            if number = 0 then current_sum
            else 
                let last_digit = number % 10
                sum_digit (number / 10) (current_sum + last_digit)
        sum_digit number 0            

        
    let sum_digits_top number = 
        let rec sum_digit number =
            if number = 0 then 0
            else 
                let last_digit = number % 10
                last_digit + sum_digit (number / 10)
        sum_digit number


    let factorial number =
        let rec fact number = 
             if number = 0 then 1
             else 
                number * fact(number - 1)
        fact number

    let last_digit number = number % 10
    let remove_last_digit number = number / 10

    let sum_digits number =
        let rec sum acc n =
            match n with
            0 -> acc
            | _ -> sum (acc + last_digit n) (remove_last_digit n)
        sum 0 number

    let traverse number operation acum =
        let rec trav num acc =
            match num with 
            0 -> acc
            | _ ->
                let digit = last_digit num
                trav (remove_last_digit num) (operation acc digit)
        trav number acum

    let traverse_condition number operation acum predicate =
        let rec trav num acc =
            match num with
            0 -> acc
            | _ when predicate (last_digit num) -> 
                trav (remove_last_digit num) (operation acc (last_digit num))
            | _ -> trav (remove_last_digit num) acc
        trav number acum

    let rec GCD a b =
        match b with 
        0 -> a
        | _ -> GCD b (a % b)

    let traverse_coprime number operation acum =
        let rec trav num acc =
            match num with
            0 -> acc
            | _ ->
                let digit = last_digit num
                let newAcc = if GCD number digit = 1 then operation acc digit else acc
                trav (remove_last_digit num) newAcc
        trav number acum

    let euler_phi number =
        traverse_coprime number (fun acc _ -> acc + 1) 0

    let traverse_coprime_condition number operation acum condition = 
        let rec trav num acc = 
            match num with
            0 -> acc
            | _ when GCD number (last_digit num) = 1 && condition (last_digit num) ->
                trav (remove_last_digit num) (operation acc (last_digit num))
            | _ -> trav (remove_last_digit num) acc
        trav number acum

    let is_prime number =
        let rec check divisor =
            match divisor * divisor > number with
            true -> true
            | false -> 
                match number % divisor = 0 with
                true -> false
                | false -> check (divisor + 1)
        match number < 2 with
        true -> false
        | false -> check 2

    let sum_prime_divisors number = 
        let rec sum_divisors n acc divisor =
            match divisor > n / 2 with
            true -> acc
            | false -> 
                match n % divisor = 0, is_prime divisor with
                true, true -> sum_divisors n (acc + divisor) (divisor + 1)
                | _ -> sum_divisors n acc (divisor + 1)
        sum_divisors number 0 2

    let count_odd_digit_greater_three number =
        traverse_condition number (fun acc _ -> acc + 1) 0 (fun d -> d % 2 <> 0 && d > 3)

    let product_divisors_digit_sum_less_than_original number =
        let original_sum_digits = sum_digits number
        let rec product_valid_divisors n acc divisor =
            match divisor > n / 2 with
            true -> acc
            | false ->
                let newAcc = 
                    match n % divisor = 0 && sum_digits divisor < original_sum_digits with
                    true -> acc * divisor
                    | false -> acc
                product_valid_divisors n newAcc (divisor + 1)
        product_valid_divisors number 1 2



module ListFunctions =

    let read_list n =
        let rec read_items remaining acc =
            match remaining with
            0 -> List.rev acc
            | _ ->
                Console.Write("Введите элемент {0}: ", n - remaining + 1)
                let number = Console.ReadLine() |> int
                read_items (remaining - 1) (number :: acc)
        
        match n with
        x when x <= 0 -> []
        | _ -> read_items n []

    let print_list lst =
        let rec print_tail_rec isFirst remainingList =
            match remainingList with
            [] -> ()
            | head :: tail ->
                if not isFirst then Console.Write(" ")
                Console.Write(head.ToString())
                print_tail_rec false tail
        
        Console.Write("[")
        print_tail_rec true lst
        Console.WriteLine("]")

    let filtered_fold (list: int list) (f: int -> int -> int) (p: int -> bool) (acc: int) =
        let rec process_list lst currentAcc =
            match lst with
            [] -> currentAcc
            | head :: tail when p head -> process_list tail (f currentAcc head)
            | _ :: tail -> process_list tail currentAcc
        process_list list acc

    let most_frequent_element list =
        let rec count_occurrences elem lst count =
            match lst with
            | [] -> count
            | head :: tail when head = elem -> count_occurrences elem tail (count + 1)
            | _ :: tail -> count_occurrences elem tail count

        let rec find_most_frequent remaining currentMaxElem currentMaxCount =
            match remaining with
            | [] -> currentMaxElem
            | head :: tail ->
                let count = count_occurrences head list 0
                if count > currentMaxCount then
                    find_most_frequent tail head count
                else
                    find_most_frequent tail currentMaxElem currentMaxCount

        match list with
        | [] -> failwith "Список пустой"
        | head :: _ -> find_most_frequent list head 0


    type Tree =
        Empty 
        | Node of int * Tree * Tree

    let build_tree numbers =
        let rec insert value tree =
            match tree with
            Empty -> Node(value, Empty, Empty)
            | Node(v, left, right) ->
                if value <= v then Node(v, insert value left, right)
                else Node(v, left, insert value right)
        
        List.fold (fun acc num -> insert num acc) Empty numbers

    let print_tree tree =
        let rec print = function
            Empty -> ()
            | Node(v, left, right) ->
                Console.WriteLine(v.ToString())
                print left
                print right
        print tree

    
    let frequent_element list =
        list
        |> List.countBy id
        |> List.maxBy snd
        |> fst

    let count_quares list =
        list
        |> List.filter (fun x -> 
            list |> List.exists (fun y -> y * y = x))
        |> List.length

    let create_tuples (a: int list) (b: int list) (c: int list) =
            let sortedA = List.sortDescending a

            let sum_digits n = 
                let rec sum n acc =
                    match n with
                    0 -> acc
                    | _ -> sum (n/10) (acc + n%10)
                sum (abs n) 0

            let sortedB = 
                b |> List.sortBy (fun x -> (sum_digits x, -abs x))

            let count_divisors n =
                let n = abs n
                if n = 0 then 0 else
                [1..n] |> List.filter (fun x -> n % x = 0) |> List.length

            let sortedC =
                c |> List.sortBy (fun x -> (-count_divisors x, -abs x))

            List.zip3 sortedA sortedB sortedC

    let read_strings () =
        let count = System.Console.ReadLine() |> int
        List.init count (fun _ -> System.Console.ReadLine())
    
    let sort_string_length (strings : string list) : string list =
        strings |> List.sortBy (fun s -> s.Length)

// 11.1 
    let count_after_last_max list =
        let maxVal = List.max list
        list 
        |> List.rev
        |> List.takeWhile (fun x -> x <> maxVal)
        |> List.length

    let countAfterLastMax list =
        let rec find_last_max lst maxVal lastPos currentPos =
            match lst with
            [] -> (maxVal, lastPos)
            | x :: xs ->
                let newMax = max x maxVal
                let newPos = if x >= newMax then currentPos else lastPos
                find_last_max xs newMax newPos (currentPos + 1)
        
        let maxVal, pos = find_last_max list (List.head list) 0 0
        List.length list - pos - 1

// 11.11
    let find_unique list =
        list
        |> List.groupBy id
        |> List.find (fun (_, group) -> List.length group = 1)
        |> fst

    let findUnique (list: int list) =
        let rec is_unique x = function
            | [] -> true
            | y :: ys when x = y -> false
            | _ :: ys -> is_unique x ys

        let rec find_Unique = function
            | [] -> failwith "Уникальный элемент не найден"
            | x :: xs -> if is_unique x xs then x else find_Unique xs

        find_Unique list

// 11.21
    let after_first_max list =
        let maxVal = List.max list
        list
        |> List.skipWhile (fun x -> x <> maxVal)
        |> List.tail

    let afterFirstMax list =
        let rec skip_until_max found acc = function
            [] -> List.rev acc
            | x :: xs when found -> skip_until_max true (x :: acc) xs
            | x :: xs when x = List.max list -> skip_until_max true acc xs
            | _ :: xs -> skip_until_max false acc xs
        skip_until_max false [] list

// 11.31
    let count_even list =
        list
        |> List.filter (fun x -> x % 2 = 0)
        |> List.length

    let countEven list =
        let rec count acc = function
            [] -> acc
            | x :: xs -> count (if x % 2 = 0 then acc + 1 else acc) xs
        count 0 list

// 11.41
    let average_abs list =
        list
        |> List.map abs
        |> List.averageBy float

    let averageAbs list =
        let rec sum_count (sum, cnt) = function
            [] -> float sum / float cnt
            | x :: xs -> sum_count (sum + abs x, cnt + 1) xs
        sum_count (0, 0) list

// 11.51
    let split_unique_counts list =
        let unique = list |> List.distinct
        let counts = unique |> List.map (fun x -> List.sumBy (fun y -> if y = x then 1 else 0) list)
        (unique, counts)

    let splitUniqueCounts list =
        let rec process_list unique counts = function
            [] -> (List.rev unique, List.rev counts)
            | x :: xs ->
                let rec count c = function
                    [] -> c
                    | y :: ys -> count (if x = y then c + 1 else c) ys
                let rec exists = function
                    [] -> false
                    | v :: vs -> v = x || exists vs
                if exists unique then 
                    process_list unique counts xs
                else
                    process_list (x :: unique) (count 0 list :: counts) xs
        process_list [] [] list

    let longest_subsequence a b =
        let rec find = function
            [], _ | _, [] -> []
            | x::xs, y::ys when x = y -> x :: find (xs, ys)
            | x::xs, y::ys -> 
                let l1 = find (x::xs, ys)
                let l2 = find (xs, y::ys)
                if List.length l1 > List.length l2 then l1 else l2
        find (a, b)

    