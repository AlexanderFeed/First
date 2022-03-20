// Learn more about F# at http://fsharp.org

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
let rec m list mi =
    match list with
    |[] -> mi
    |h::t ->
            if h> mi then 
                let new_mi = h 
                m t new_mi
            else  m t mi

let rec del list mi new_list =
    match list with
    |[] -> new_list
    |h::t ->
            if h= mi then 
                let new_new_list = new_list @ [] 
                del t mi new_new_list
            else
                let new_new_list = new_list@[h]
                del t mi new_new_list
                
let f = function 
|h::t -> h

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list = readList n 
    let first = f list
    let ma1 = m list first
    let new_list = del list ma1 []
    let new_first = f new_list
    let ma2 = m new_list new_first
    Console.WriteLine(ma1)
    Console.WriteLine(ma2)
    0 // return an integer exit code
