(*
Ряд длиной n. На нем размещаются красные блоки длинной m.
Любые два красных блока должны быть
разделены минимум одним черным блоком

Найти n, при котором F(50, n) > 1_000_000
*)


open System
 
let findMinN (m: int) (target: int) =
    let rec build (n: int) (arr: int[]) =
        let current =
            match n with
            _ when n < m -> 1
            | _ when n = m -> 2
            | _ ->
                arr.[n - 1] +
                ([m..n] |> List.sumBy (fun k ->
                    if k = n then 1
                    else arr.[n - k - 1]))
        
        if current > target then n
        else build (n + 1) (Array.append arr [|current|])

    build 0 [||]

let m = 50
let target = 1000000
let result = findMinN m target
Console.WriteLine("F({0}, n) > {1}: {2}", m, target, result)
