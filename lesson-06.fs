// 16.1
let notDivisible (n, m) = m % n = 0

// 16.2
let rec prime_rec = function 
  | (1, n) -> false 
  | (k, n) -> (n % k = 0) || prime_rec(k - 1, n) 

let prime = function 
  | 1 -> false 
  | 2 -> true 
  | n -> not (prime_rec(n / 2, n)) 
