## 8. Кортежи (tuples)

Кортеж - это упорядоченный набор двух или более значений произвольных типов.

Кортеж представляет собой единую сущность.

Значения в кортеже заключаются в круглые скобки и перечисляются через запятую, хотя в общем случае скобки не обязательны.

```
(1, '2', 3.14, "555")
( (1, '2'), (3.14, "555") )
```

Концепция кортежа в F# такова: если v1 и v2 - значения типов t1 и t2, то (v1, v2) - значение типа t1 * t2.

В некотором смысле символ * в подобном объединении типов представляет собой картезианское произведение множеств.

```
let a = (3.14, 128) // тип a = float * int
let a1 = ( (1, '2'), (3.14, "555") ) // тип a1 = (int * char) * (float * string)
```

На основе кортежа можно создавать составной паттерн:

```
let (x, y) = a // x = 3.14, y = 128
```

Кортежи удобно использовать как набор из "нескольких" аргументов функции.

Функции в F# имеют один аргумент, но кортеж позволяет и синтаксически, и семантически эмулировать вызов функции со множеством аргументов.

Например, функцию возведения x в степень n можно с помощью кортежа записать так:

```
let rec power = function 
 | (x,0)  -> 1.0
 | (x,n)  -> x * power(x,n - 1)

printfn "= %f" (power (2.0, 8)) // 256.0
```

Тип функции power - float * int -> float. 

## 9. Function application, связывание и окружение

### Правило применения функции к аргументу (function application)

Если функция f имеет тип t1 -> t2, и значение e имеет тип t1, то f(e) имеет тип t2.

### Связывание (binding) и окружение (environment)

Множество связываний значений с именами в программе представляет собой окружение.

Окружение и связывание - это не части программы, а математические объекты, требующиеся для прояснения смысла и работы программы.

В ходе работы программы те операции связывания, которые могут реально выполниться, формируют фактическое окружение.

В системе F# существует базовое фактическое окружение, включающее связывания стандартных идентификаторов (функции, константы), которое основано на платформе .NET.

При вычислении выражений и функций система F# может формировать временные связывания идентификаторов - например, в процессе рекурсивного вызова, которые исчезают по окончании вычисления.

## 10. Автономные программы

Выполнение программы удобно начинать с определённой функции, которая в F# называется main() и имеет тип string[] -> int (параметр - массив строк, результат работы - целое).

Функция main() должна сопровождаться дополнительным атрибутом точки входа: 

```
[<EntryPoint>]
let main(param: string[]) = 
    printfn "Hello, World!%s" "!!"
    0
```

В последней строке указывается значение, возвращаемое функцией (0 - системный код успешного завершения).

Параметр param автоматически получает значения параметров, указываемые при вызове скомпилированной программы из консоли. 