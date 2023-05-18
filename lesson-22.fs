// 48.4.1
let rec fib1 n n1 n2 = 
    match n with
    | 0 -> n2
    | 1 -> n1
    | n -> fib1 (n - 1) (n1 + n2) n1

// 48.4.2
let rec fib2 n c = 
    match n with
    | 0 -> c 0
    | 1 -> c 1
    | n -> fib2 (n - 2) (fun a -> fib2 (n - 1) (fun b -> c (a + b)))

// 48.4.3
let rec bigList n k =
  if n = 0 then k []
  else bigList (n - 1) (fun res -> k(1::res))
