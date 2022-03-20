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
            if h< mi then 
                let new_mi = h 
                m t new_mi
            else  m t mi

let poisk list a b mal =
    let rec poisk1 list a b mal ind kolvo =
        match list with
        |[] -> kolvo
        |h::t ->
                if(a<ind && ind<b && mal =h) then 
                                                let new_kolvo= kolvo+1
                                                let new_ind = ind+1
                                                poisk1 t a b mal new_ind new_kolvo
                else 
                    let new_ind = ind+1 
                    poisk1 t a b mal new_ind kolvo
    poisk1 list a b mal 1 0                     

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Convert.ToInt32
    let list = readList n
    let first = List.head list
    let mal = m list first
    Console.WriteLine(poisk list 1 5 mal)
    0 // return an integer exit code
