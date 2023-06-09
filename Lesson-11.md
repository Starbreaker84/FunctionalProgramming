# Часть 3. Составные значения (типы)

Кортежи, записи и размеченные объединения - это типы, соединяющие в себе значения разных типов.

Кортежи используются, например, как аргументы в "функциях нескольких переменных", и как результат в функциях, возвращающих наборы различных значений.

Запись позволяет идентифицировать различные значения, входящие в неё, по именам (тегам).

Размеченные объединения позволяют объединять значения различный видов в единое множество.

Значения этих трёх типов трактуются в F# как объекты первого класса (first-class citizens): они могут использоваться в выражениях, и быть результатом вычисления выражений.

Функции над этими типами определяются с помощью шаблонов. 

## 23. Кортежи

### 23.1. Кортежи детальнее

Введение про кортежи

В качестве элементов кортежа можно использовать ранее связанные имена.

```
let x = (5, "5")
let k = (x, 25) // (int * string) * int
```

В случае изменения значения идентификатора значение кортежа не изменяется.

Кортеж вычисляется слева направо:

```
(3+2+1, 5.0-4.0, 3) = (6, 5-4, 3) = (6, 1.0, 3)
```

Кортежи могут сравниваться, но только если их типы совпадают.

```
(1 > 2, '3', 5-3) = (false, '3', 2) // true
(1 > 2, '3', 5-3) = (false, ('3', 2)) // error: type mismatch
```

Сравнение происходит лексикографически (до первого неравного элемента).

```
(1, 3, 5) < (1, 2, 10) // false
```

### 23.2. Кортеж-шаблон

Кортеж, состоящий из идентификаторов, называется шаблон, и используется, например, для сопоставления идентификаторов и значений.

```
let (a, b) = (3, 5) // a=3, b=5
```

Вместо идентификаторов могут использоваться значения, но они должны точно соответствовать значениям из сопоставляемого значения.

```
let (a, 5) = (3, 5) // a=3
let (a, 5) = (3, 3) // исключение времени выполнения
```

Компилятор не выполняет само сопоставление, а только выдаёт предупреждение, потому что типы согласованы корректно.

Символ `"_"` может использоваться для сопоставления любому значению.

```
let (a, _) = (3, 3) // a=3
```

### 23.3. Полиморфный тип

Функция swap обменивает местами значения внутри кортежа из двух элементов:

```
let swap (a, b) = (b, a)
let x,y = swap(1,2) // x=2, y=1
```

Типы параметров swap называются полиморфными - они параметризуются другими типами.

Полиморфный тип - это тип, операции над которым могут быть корректно применены к другим типам (например, являющимися наследниками полиморфного типа).

В реализации F# в качестве полиморфного типа выступает базовый тип .NET System.Object.

```
let swap (a, b) = (b, a) 
// System.Object  * System.Object -> System.Object * System.Object
```

Функции с аргументами полиморфных типов называются полиморфные функции.

Компилятор создаёт один экземпляр каждой полиморфной функции - в отличие от перегрузки операторов, когда для каждого перегруженного оператора с конкретными типами создаётся своя реализация.

### 23.4. Задания

23.4.1. В фэнтези-РПГ принята следующая денежная система: в одном золотом 20 серебряных, а в одном серебряном 12 медяков. Суммы в такой системе задаются тройками целых чисел (золотые, серебряные, медяки), например (1, 0, 128) или (32, 23, 5).

Реализуйте инфиксный оператор `.+.` , который складывает деньги, представленные в виде троек, и инфиксный оператор `.-.` , который вычитает деньги. Результат приводите к формату, когда количество медяков не превышает 11, а количество серебряных не превышает 19.

23.4.2. Реализуйте логику работы с комплексными числами. Комплексное число задаётся парой вещественных чисел (x,y).

Правила сложения и умножения:

```
(a, b) + (c, d) = (a + c, b + d)
(a, b) * (c, d) = (ac - bd, bc + ad)
```

Вычитание реализуется сложением через инверсию:

```
-(a, b) = (-a,-b),
```

Деление реализуется умножением через инверсию:

```
1/(a, b) = (a/(a^2+b^2),-b/(a^2+b^2))
```

Реализуйте соответствующие инфиксные операторы `.+ , .- , .* и ./ `.

Шаблон для отправки на сервер:

```
// 23.4.1
let (.+.) x y = ...
let (.-.) x y = ...

// 23.4.2
let (.+) x y = ...
let (.-) x y = ...
let (.*) x y = ...
let (./) x y = ...
```
