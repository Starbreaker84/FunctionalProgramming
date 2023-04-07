// 16.1
let notDivisible (n, m) = m % n = 0

printfn "%b" (notDivisible (4, 9))

// 16.2
let rec prime_rec = function 
  | (1, n) -> false 
  | (k, n) -> (n % k = 0) || prime_rec(k - 1, n) 

let rec prime = function 
  | 1 -> false 
  | 2 -> true 
  | n -> not (prime_rec(n / 2, n)) 
