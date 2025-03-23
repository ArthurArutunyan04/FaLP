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


    let traverse number operation acum = 
        let rec trav number acc =
            match number with 
            0 -> acc 
            | _ ->
                let digit = number % 10
                trav (number/10) (operation acc digit)
        trav number acum


    let traverse_condition number operation acum predicate =
        let rec trav number acc =
            match number, predicate (number % 10) with
            0, _ -> acc  
            | _ , true -> trav (number / 10) (operation acc (number % 10))
            | _, false -> trav (number / 10) acc 
        trav number acum


    let rec GCD a b = 
        match b with 
        0 -> a
        | _ -> GCD b (a % b)


    let traverse_coprime number operation acum =
        let rec trav num acc =
            match num with
            | 0 -> acc
            | _ ->
                let digit = num % 10
                let newAcc = if GCD number digit = 1 then operation acc digit else acc
                trav (num / 10) newAcc
        trav number acum


    let euler_phi number =
        traverse_coprime number (fun acc _ -> acc + 1) 0


    let traverse_coprime_condition number operation acum condition = 
        let rec trav num acc = 
            match num with
            | 0 -> acc
            | _ when GCD number (num % 10) = 1 && condition (num % 10) ->
                trav (num / 10) (operation acc (num % 10))
            | _ -> 
                trav (num / 10) acc
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
            true -> acc
            | false -> 
                match n % divisor = 0, is_prime divisor with
                true, true -> sum_divisors n (acc + divisor) (divisor + 1)
                | _ -> sum_divisors n acc (divisor + 1)
        sum_divisors number 0 2