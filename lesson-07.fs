// 17.1
let rec pow = function
  | (s, 0) -> ""
  | (s, n) when s = "" -> ""
  | (s, n) when n < 0 -> ""
  | (s, n) -> s + pow (s, n - 1)

// 17.2
let rec isIthChar = function
    | (s, n, c) when n > (String.length s) - 1 -> false
    | (s, n, c) when n < 0 -> false
    | (s, n, c) when s.[n] = c -> true
    | (s, n, c) -> false

// 17.3
let occFromIth (s, n, c) = 
    let rec check = function
        | (n, c, acc) when n > (String.length s) - 1 -> acc
        | (n, c, acc) when n < 0 -> 0
        | (n, c, acc) when c = s.[n] -> check (n + 1, c, acc + 1)
        | (n, c, acc) -> check (n + 1, c, acc)
    check (n, c, 0)
