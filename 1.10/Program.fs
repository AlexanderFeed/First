// Learn more about F# at http://fsharp.org

open System
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
            let new_init = if nod chislo dannoe = 1 then init else func init dannoe
            let new_dannoe = dannoe-1
            schet chislo func new_init new_dannoe
    schet chislo func init chislo
//сложно
let prost_proxod x predicate func init =
    let func1 init divider = if predicate divider then func init divider else init
    prost x func1 init

let nod_proxod x predicate func init =
    let func1 init divider = if predicate divider then func init divider else init
    vse x func1 init

let Metod1 x =
    (prost_proxod x (fun a -> a%2 =0) (fun x y-> x+1) 0)

let rec Metod2 x init =
    if(x=0) then init
    else
            if(x%10> init && (x%10)%3 <>0) then 
                                            let new_init = x%10 
                                            Metod2 (x/10) new_init
            else Metod2 (x/10) init


let prost3 chislo init =
    let rec schet3 chislo init dannoe = 
        if(dannoe <=1) then init
        else
            let new_init = if nod chislo dannoe = 1 then init 
                           else 
                               if (dannoe > init) && ((dannoe % nod chislo dannoe) <>0) then dannoe else init 
            let new_dannoe = dannoe-1
            schet3 chislo new_init new_dannoe
    schet3 chislo init chislo

let pervoe x =
    prost3 x 0 

let rec vtoroe x =
    if x < 5 then x
    else 
        if x%10 < 5 then x%10 + vtoroe(x/10)
        else vtoroe(x/10)

let Metod3 x =
    pervoe x * vtoroe x

[<EntryPoint>]
let main argv =
    //Console.WriteLine("НОД 21 7:")
    //Console.WriteLine(nod 21 7)
    Console.WriteLine("Введите номер метода:")
    let met = Console.ReadLine() |> Int32.Parse
    Console.WriteLine("Введите число:")
    match met with
    | 1 -> Console.WriteLine(Metod1 (Console.ReadLine() |> Int32.Parse))
    | 2 -> Console.WriteLine(Metod2 (Console.ReadLine() |> Int32.Parse))
    | 3 -> Console.WriteLine(Metod3 (Console.ReadLine() |> Int32.Parse))
    | _ -> Console.WriteLine("Нет такого метода")
    0 
