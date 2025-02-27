open System

// Добавление элемента в начало списка
let dobavlenievlist element list = element :: list

// Удаление элемента из списка
let udalenieizlist element list = List.filter (fun x -> x <> element) list

// Поиск элемента в списке
let poiskvlist element list = List.contains element list

// Сцепка двух списков
let sovmeshenielist list1 list2 = list1 @ list2

// Получение элемента по индексу
let polucheniepoindexu index list = List.tryItem index list

// Функция для безопасного чтения целого числа
let readInt prompt =
    let rec read () =
        printf "%s" prompt
        let input = Console.ReadLine()
        match Int32.TryParse(input) with
        | (true, value) -> value
        | (false, _) -> 
            printfn "Некорректный ввод, попробуйте снова."
            read ()
    read()

// Функция для чтения списка чисел
let readList prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    input.Split(' ') |> Array.map int |> Array.toList

// Главная программа
[<EntryPoint>]
let main argv =
    printfn "Меню операций:"
    printfn "1. Добавить элемент в список"
    printfn "2. Удалить элемент из списка"
    printfn "3. Поиск элемента в списке"
    printfn "4. Сцепить два списка"
    printfn "5. Получить элемент по индексу"
    
    let operation = readInt "Выберите операцию (1-5): "

    match operation with
    | 1 ->
        // Добавление элемента
        let list = readList "Введите список чисел (через пробел): "
        let element = readInt "Введите элемент для добавления: "
        let newList = dobavlenievlist element list
        printfn "Новый список: %A" newList

    | 2 ->
        // Удаление элемента
        let list = readList "Введите список чисел (через пробел): "
        let element = readInt "Введите элемент для удаления: "
        let newList = udalenieizlist element list
        printfn "Новый список: %A" newList

    | 3 ->
        // Поиск элемента
        let list = readList "Введите список чисел (через пробел): "
        let element = readInt "Введите элемент для поиска: "
        let found = poiskvlist element list
        if found then
            printfn "Элемент найден в списке."
        else
            printfn "Элемент не найден в списке."

    | 4 ->
        // Сцепка двух списков
        let list1 = readList "Введите первый список чисел (через пробел): "
        let list2 = readList "Введите второй список чисел (через пробел): "
        let concatenatedList = sovmeshenielist list1 list2
        printfn "Сцепленный список: %A" concatenatedList

    | 5 ->
        // Получение элемента по индексу
        let list = readList "Введите список чисел (через пробел): "
        let index = readInt "Введите индекс элемента: "
        match polucheniepoindexu index list with
        | Some value -> printfn "Элемент на индексе %d: %d" index value
        | None -> printfn "Индекс выходит за пределы списка."

    | _ -> printfn "Некорректный выбор операции."

    0 // Возвращаем 0 как код завершения