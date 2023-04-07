# Часть вторая.

## Значения, операторы, выражения и функции

### 11. Типы

F# поддерживает всё множество элементарных типов .NET: целые, вещественные, фиксированной точности, символы, строки и логические (булевы) значения.

F# не поддерживает неявное преобразование типов:

```
let X = 2 + 2.2 // ошибка
```

Для явного преобразования типов в F# имеется набор функций, например int(), float():

```
let X = 2 + int(2.2) // X = 4
```

Значения логического типа - true и false.

### 12. Операторы

Оператор - это синоним функции, только в программе он записывается особым синтаксисом.

Аргументы оператора называются операнды.

Монадический оператор имеет один операнд и обычно записывается в префиксной нотации.

Диадический оператор имеет два операнда и записывается в инфиксной нотации: размещается между операндами.

Для сравнения значений базовых типов и строк применяются диадические операторы `> >= < <= = <>`

Сравнивать корректно лишь данные элементарных (базовых) типов, передающиеся по значению.

Символы сравниваются как коды Unicode, строки сравниваются в лексикографическом порядке.

Стандартная функция compare сравнивает два значения и возвращает значение, большее нуля, если первый аргумент больше второго; значение, меньшее нуля, если первый аргумент меньше второго; ноль, если аргументы равны.

F# содержит битовые операторы для побитовой работы с целыми числами: `&&& ||| ^^^ <<< >>>`

Символ "-" используется в F# в трёх целях: как знак константы

```
-5 
```

как монадический оператор

```
- (5 + 5) 
```

как диадический оператор

```
5 - 5
```

## Типы и операторы

### 13. Логические операторы и функция-предикат

Функция, возвращающая логическое значение, называется предикат:

```
let odd n = n % 2 = 1 
printfn "odd 3 = %b" (odd 3)
```

Логических операторов в F# три: унарное отрицание `not`, логическое И `&&` и логическое ИЛИ `||`

В выражениях `e1 && e2 и e1 || e2` правое выражение `e2` вычисляется только при необходимости.

### 14. Тип unit

Тип unit задаёт единственное "пустое" значение (), условно обозначающее отсутствие значения.

Тип unit добавлен в F# в прикладных целях, для упрощения вычислений, связанных например с вводом-выводом, и в общем случае использовать такой тип в функциональном программировании не рекомендуется.

### 15. Старшинство и ассоциация операторов

Выражения, включающие операторы, вычисляются, исходя из старшинства (приоритета) операторов.

Порядок вычисления можно менять с помощью круглых скобок ( )

Приоритеты операторов в порядке убывания:

```
**
* / %
+ -
= <> > >= < <=
&&
||
```

Монадический оператор, включая применение функции, имеет наивысший приоритет.

Ассоциация определяет, в каком порядке будут вычисляться диа
дические операторы одинакового приоритета.

Ассоциация всех операторов, кроме `**`, считается левой:

```
3 - 2 - 1 = (3 - 2) - 1
2 ** 3 ** 4 = 2 ** (3 ** 4) 
```

### 16. Задания

16.1. Напишите функцию-предикат notDivisible: int * int -> bool, где notDivisible(n,m) возвращает true, если число n - делитель числа m.

16.2. Напишите функцию-предикат prime: int -> bool, где prime(n) возвращает true, если n - простое число.

Шаблон для отправки на сервер:

```
// 16.1
let notDivisible  ...

// 16.2
let  prime  ...
```