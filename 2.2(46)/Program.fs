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
    [] ->[]
    | (h:int)::t ->
            Console.WriteLine(h)
            writelist t

let poloz list func =
    let rec poloz1 list func new_list =
        match list with
        |[] -> new_list
        |h::t ->
                if func h then 
                                let new_new_list = new_list@[h]
                                poloz1 t func new_new_list
                else 
                    let new_new_list = new_list@[]
                    poloz1 t func new_new_list
    poloz1 list func []
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list = readlist n
    let list1 = poloz list (fun x -> x>0)
    let list2 = poloz list (fun x -> x<0)
    writelist (list1@list2)
    0 // return an integer exit code
