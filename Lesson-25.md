## Ленивые вычисления

### 51.1. Ленивые вычисления

Ленивые последовательности - частный случай ленивых вычислений.

Аппликация функций может выполняться сразу, энергично - начиная с расчёта аргументов, а может и отложенно - аргументы вычисляются только в момент непосредственного к ним обращения.

F# поддерживает энергичную стратегию вычислений, но допускает и ленивые вычисления.

Конструкция lazy(), применённая к выражению, вычисляющему значение типа T, возвращает значение Lazy.

Вычисление значения Lazy осуществляется функцией Lazy.Force().

F# - не чистый функциональный язык, в нём возможны побочные эффекты, но если некоторый код гарантированно чистый и подразумевает нагрузочные вычисления, его лучше оформлять в ленивом стиле.
```
let eagerDiv x =
    let dX = 1.0 / x
    dX * 2.0

let lazyDiv x =
    let dX = lazy(1.0 / x)
    if x = 0.0 then
       None
    else 
       Some(dX.Force() * 2.0)

eagerDiv 5.0 // 0.4
eagerDiv 0.0 // Infinity
lazyDiv 5.0 // Some(0.4)
lazyDiv 0.0 // None
```
F# поддерживает механизм мемоизации: если внутри чистых ленивых вычислений с помощью Force() возникают промежуточные результаты, то они сохраняются (кэшируются), и при последующих вызовах Force() готовые результаты быстро воспроизводятся из кэша.

### 51.2. Потоки

В функциональном программировании есть понятие потока (stream), под которым понимается бесконечный список.

При формировании бесконечных структур данных удобно использовать рекурсивное определение типа.

F# предлагает специальный синтаксис для работы со списками внутри сопоставления с образцом, подходящий для рекурсивных определений:
- Cons of тип1 * тип2 или Cons(h,t) - означает список из сцепки двух элементов, или h::t .
- Nil - аналог пустого списка [ ] .

Поток можно рекурсивно определить как элемент cell, который может быть либо пустым, либо представлять собой список из двух элементов: головы - конкретного значения некоторого полиморфического типа, и хвоста - следующего элемента cell, который вычисляется лениво.
```
type 'a cell = Nil | Cons of 'a * Lazy<'a cell>
```
Ленивое вычисление хвоста обязательно, в противном случае список будет вычислен сразу в момент создания, что приведёт к исчерпанию ресурсов, так как функция-генератор начнёт формировать бесконечную последовательность.

Генератор бесконечной последовательности целых чисел, начиная с заданного:
```
let rec nat (n:int) : 'a cell = Cons (n, lazy(nat(n+1)))

let n0 = nat 0
```
Получение головы потока (первого элемента, реального вычисленного значения):
```
let hd (s : 'a cell) : 'a =
  match s with
    Nil -> failwith "hd"
  | Cons (x, _) -> x
```
Получение хвоста потока (второго ленивого элемента, вычисление которого отложено):
```
let tl (s : 'a cell) : Lazy<'a cell> =
  match s with
    Nil -> failwith "tl"
  | Cons (_, g) -> g
```
### 51.3. Задание

Напишите с помощью hd и tl функцию nth, которая возвращает n-й (n >= 0) вычисленный элемент бесконечного списка.

Шаблон для отправки на сервер:
```
type 'a cell = Nil | Cons of 'a * Lazy<'a cell>

let hd (s : 'a cell) : 'a =
  match s with
    Nil -> failwith "hd"
  | Cons (x, _) -> x

let tl (s : 'a cell) : Lazy<'a cell> =
  match s with
    Nil -> failwith "tl"
  | Cons (_, g) -> g


// 51.3
let rec nth (s : 'a cell) (n : int) : 'a =
  ...

// например, получить 30000-й элемент:
// nth n0 30000
```