namespace WorkingWithNumbers

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
            | 0 -> acc
            | _ -> sum (acc + last_digit n) (remove_last_digit n)
        sum 0 number

    let traverse number operation acum =
        let rec trav num acc =
            match num with 
            | 0 -> acc
            | _ ->
                let digit = last_digit num
                trav (remove_last_digit num) (operation acc digit)
        trav number acum

    let traverse_condition number operation acum predicate =
        let rec trav num acc =
            match num with
            | 0 -> acc
            | _ when predicate (last_digit num) -> 
                trav (remove_last_digit num) (operation acc (last_digit num))
            | _ -> trav (remove_last_digit num) acc
        trav number acum

    let rec GCD a b =
        match b with 
        | 0 -> a
        | _ -> GCD b (a % b)

    let traverse_coprime number operation acum =
        let rec trav num acc =
            match num with
            | 0 -> acc
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
            | 0 -> acc
            | _ when GCD number (last_digit num) = 1 && condition (last_digit num) ->
                trav (remove_last_digit num) (operation acc (last_digit num))
            | _ -> trav (remove_last_digit num) acc
        trav number acum

    let is_prime number =
        let rec check divisor =
            match divisor * divisor > number with
            | true -> true
            | false -> 
                match number % divisor = 0 with
                | true -> false
                | false -> check (divisor + 1)
        match number < 2 with
        | true -> false
        | false -> check 2

    let sum_prime_divisors number = 
        let rec sum_divisors n acc divisor =
            match divisor > n / 2 with
            | true -> acc
            | false -> 
                match n % divisor = 0, is_prime divisor with
                | true, true -> sum_divisors n (acc + divisor) (divisor + 1)
                | _ -> sum_divisors n acc (divisor + 1)
        sum_divisors number 0 2

    let count_odd_digit_greater_three number =
        traverse_condition number (fun acc _ -> acc + 1) 0 (fun d -> d % 2 <> 0 && d > 3)

    let product_divisors_digit_sum_less_than_original number =
        let original_sum_digits = sum_digits number
        let rec product_valid_divisors n acc divisor =
            match divisor > n / 2 with
            | true -> acc
            | false ->
                let newAcc = 
                    match n % divisor = 0 && sum_digits divisor < original_sum_digits with
                    | true -> acc * divisor
                    | false -> acc
                product_valid_divisors n newAcc (divisor + 1)
        product_valid_divisors number 1 2
