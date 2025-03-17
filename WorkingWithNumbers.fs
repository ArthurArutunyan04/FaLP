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
