// 20.3.1
let vat n x = x * (1.0 + (float n) / 100.0)

// 20.3.2
let unvat n x = x / (1.0 + (float n) / 100.0)

// 20.3.3
let min f = 
     let rec check = function 
         | x when f x = 0 -> x 
         | x -> check (x + 1) 
     check 1
