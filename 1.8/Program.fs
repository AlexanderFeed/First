// Learn more about F# at http://fsharp.org

open System
let mutable m = -1
let rec nod a b =
    if a = b then a
    else
        if (a > b) then 
            let new_a = b 
            let new_b = a-b
            nod new_a new_b
        else 
            let new_a = a 
            let new_b = b-a
            nod new_a new_b
let vse x func init =
    let rec vse1 x func init current_divider =
        if current_divider = 0 then init
        else
            let new_init = if x % current_divider = 0 then func init current_divider else init
            let new_divider = current_divider - 1
            vse1 x func new_init new_divider
    vse1 x func init x
let prost chislo func init =
    let rec schet chislo func init dannoe = 
        if(dannoe <=1) then init
        else
            let new_init = if nod chislo dannoe = 1 then init 
                           else 
                               if (dannoe > init) && ((nod chislo dannoe)%dannoe <> 0) then dannoe else init 
            let new_dannoe = dannoe-1
            schet chislo func new_init new_dannoe
    schet chislo func init chislo

let rec sum x =
    if x < 5 then x
    else 
        if x%10 < 5 then x%10 + sum(x/10)
        else sum(x/10)
//сложно
//let prost_proxod x predicate func init =
//    let func1 init divider = if predicate divider then func init divider else init
//    prost x func1 init
//
//let nod_proxod x predicate func init =
//    let func1 init divider = if predicate divider then func init divider else init
//    vse x func1 init

[<EntryPoint>]
let main argv =
    Console.WriteLine("НОД 21 7:")
    Console.WriteLine(nod 21 7)
    Console.WriteLine("Введите число:")
    let x = Console.ReadLine() |> Int32.Parse
    //Console.WriteLine(prost (x-1) (fun x -> x%2=0) 0)
    Console.WriteLine(sum x * prost x (fun x -> x%2 =0) 0)
    0 
