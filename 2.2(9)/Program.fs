// Learn more about F# at http://fsharp.org
// Задачи 9, 12, 22, 24, 31, 34, 40, 46, 58
//1.9
open System

let rec readList n = 
    if n=0 then []
    else
        let Head = Console.ReadLine() |> Convert.ToInt32
        let Tail = readList (n-1)
        Head::Tail

let rec writeList = function
    [] ->   []
    | (head : int)::tail -> 
                   System.Console.WriteLine(head)
                   writeList tail 

let pos list m =
    let rec pos1 list m num =
        match list with
        |[] -> num
        |h::t->
            if (h>m) then num
            else 
                let new_num = num+1 
                let new_m = h 
                pos1 t new_m new_num
    pos1 list m 0

let vivod list p = 
    let rec vivod1 list p pop =
        match list with
        [] -> []
        |(h:int)::t ->
            if pop< p then Console.WriteLine(h)
            else Console.WriteLine(' ')
            let new_pop = pop+1
            vivod1 t p new_pop
    vivod1 list p 1
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Convert.ToInt32
    let list = readList n
    let min = List.head list
    let po = pos list min
    vivod list po
    
    0 // 
