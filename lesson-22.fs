// 48.4.1
let rec fibo1 n n1 n2 = 
    match n with
    | 1 -> n1
    | _ -> fibo1 (n-1) (n1+n2) n1

// 48.4.2
let rec fibo2 n c = 
    match n with
    | 0 -> c 0
    | 1 -> c 1
    | _ -> (fibo2 (n-1) (fun x -> c x) + fibo2 (n-2) (fun y -> c y))

// 48.4.3
let rec bigList n k = 
    match n with
    | 0 -> k []
    | _ -> bigList (n-1) (fun accum -> k(1::accum))
