// Learn more about F# at http://fsharp.org

open System

let rec readlist n =
    match n with   
    |0 -> []
    |_ ->
        let Head = Console.ReadLine() |> Int32.Parse
        let Tail = readlist (n-1)
        Head::Tail
let rec writelist = function    
    [] -> []
    |(h:int)::t ->
        Console.WriteLine(h)
        writelist t

let rec minchet list mi func = 
    match list with
    |[] -> mi
    |h::t ->
            if func mi h then 
                                let new_mi = h
                                minchet t new_mi func
            else
                minchet t mi func

let f = function 
    |h::t -> h
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list = readlist n
    let first = f list
    let a = minchet list first (fun mi h -> h<mi && h%2=0)
    if(a%2=0) then Console.WriteLine(a)
    else Console.WriteLine("Нет четных")
    0 // return an integer exit code
