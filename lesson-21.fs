// 47.4.1
let f n =  
     let mutable p = 1 
     let mutable i = 1 
     while i <= n do 
         p <- p * i 
         i <- i + 1 
     p

// 47.4.2
let fibo n = 
     let mutable a = 0 
     let mutable b = 1 
     let mutable c = 0 
     let mutable i = 1 
     while i < n do 
         c <- b 
         b <- a + b 
         a <- c 
         i <- i + 1 
     if n = 0 then a else b
