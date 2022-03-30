// Learn more about F# at http://fsharp.org

open System

//снизу вверх
let rec mul x =
    if x = 0 then 1
    else x%10 * mul(x/10)

    //сверху вниз
let mul2 x =
    let rec sup x cur =
        if x = 0 then cur
        else 
            let new_cur = x%10 * cur ////////////////?????????????
            let new_x = x/10
            sup new_x new_cur
    sup x 1

//снизу вверх min
let rec min_number x =
    if x < 10 then x
    else min (x % 10) (min_number (x / 10))
//сверху вниз
let min2 x =
    let rec mup x cur =
        if x=0 then cur
        else    
            let new_cur = if x%10 < cur then x%10 else cur
            let new_x = x/10
            mup new_x new_cur
    mup x 10 

//снизу вверх max
let rec max_number x =
    if x < 10 then x
    else max (x % 10) (max_number (x / 10))

//сверху вниз
let max2 x =
    let rec pup x cur =
        if x=0 then cur
        else    
            let new_cur = if x%10 > cur then x%10 else cur
            let new_x = x/10
            pup new_x new_cur
    pup x -1

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число")
    let x = Console.ReadLine() |> Int32.Parse
    Console.WriteLine("Произведение цифр (вверх): {0}", mul x)
    Console.WriteLine("Произведение цифр (вниз): {0}", mul2 x)
    Console.WriteLine("Минимальная цифра числа (вверх): {0}", min_number x)
    Console.WriteLine("Минимальная цифра числа (вниз): {0}", min2 x)
    Console.WriteLine("Максимальная цифра числа (вверх): {0}", max_number x)
    Console.WriteLine("Максимальная цифра числа (вниз): {0}", max2 x)
    0 
