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
let prost chislo func init =
    let rec schet chislo func init dannoe = 
        if(dannoe <=1) then init
        else
            let new_init = if nod chislo dannoe = 1 then func dannoe init else init
            let new_dannoe = dannoe-1
            schet chislo func new_init new_dannoe
    schet chislo func init chislo
let E x = 
    prost x (fun x y -> x+1) 0
[<EntryPoint>]
let main argv =
    Console.WriteLine("Число Эйлера для 8:")
    Console.WriteLine(E 8)
    Console.WriteLine("НОД 21 7:")
    Console.WriteLine(nod 21 7)
    Console.WriteLine("Введите число:")
    let x = Console.ReadLine() |> Int32.Parse
    Console.WriteLine("Произведение простых коспонент:")
    Console.WriteLine(prost x (fun x y -> x*y) 1)
    0 
