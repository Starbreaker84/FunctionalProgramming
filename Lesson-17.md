## 40. Практика

40.1. Напишите функцию `sum(p, xs)`, где `p` -- предикат `int -> bool`, и `xs` -- список целых. Функция возвращает сумму тех элементов `xs`, для которых предикат истинен.

40.2. Список `[x1; x2; ...; xn]` называется слабо восходящим, если его элементы удовлетворяют требованию

```
x1 <= x2 <= ... <= xn
```

Следующие функции работают со слабо восходящими списками. При их реализации обязательно учитывайте эту специфику, оптимизируя вычисления.

40.2.1. Напишите функцию `count: int list * int -> int`, которая подсчитывает количество вхождений числа в список.

40.2.2. Напишите функцию `insert: int list * int -> int list`, которая добавляет новый элемент в список.

40.2.3. Напишите функцию `intersect: int list * int list -> int list`, которая находит общие элементы в обоих списках, включая повторяющиеся.

40.2.4. Напишите функцию `plus: int list * int list -> int list`, которая формирует список, объединяющий все элементы входных списков, включая повторяющиеся.

40.2.5. Напишите функцию `minus: int list * int list -> int list`, которая возвращает список, содержащий элементы первого списка за исключением элементов второго списка (элементы, одинаковые по значению, считаются разными).

40.3. Делаем сортировку.

40.3.1. Напишите функцию `smallest: int list -> int option`, которая возвращает наименьший элемент непустого списка.

40.3.2. Напишите функцию `delete: int * int list -> int list`, которая удаляет из списка первое вхождение заданного элемента (если он имеется).

40.3.3. Напишите функцию сортировки с использованием предыдущих функций, которая сортирует входной список так, что на выходе получается слабо восходящий список.

40.4. Напишите функцию `revrev`, которая получает на вход список списков, и перевёртывает как порядок вложенных списков, так и порядок элементов внутри каждого вложенного списка.
```
revrev [[1;2];[3;4;5]] = [[5;4;3];[2;1]]
```

Шаблон для отправки на сервер:

```
// 40.1
let rec sum (p, xs) = ...

// 40.2.1
let rec count (xs, n) = ...

// 40.2.2
let rec insert (xs, n) = ...

// 40.2.3
let rec intersect (xs1, xs2) = ...

// 40.2.4
let rec plus (xs1, xs2) = ...

// 40.2.5
let rec minus (xs1, xs2) = ...

// 40.3.1
let rec smallest = ...

// 40.3.2
let rec delete (n, xs) = ...

// 40.3.3
let rec sort = ...

// 40.4
let rec revrev = ...
```