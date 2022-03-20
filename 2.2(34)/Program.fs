// Learn more about F# at http://fsharp.org

open System
let rec readlist n = 
    match n with
    |0 -> []
    |_ -> 
        let Head = Console.ReadLine() |> Convert.ToInt32
        let Tail = readlist (n-1)
        Head::Tail
let rec writelist = function
    [] -> []
    | (h:int)::t ->  
            Console.WriteLine(h)
            writelist t
    
let vivod list a b func =
    let rec vivod1 list a b func ind new_list =
        match list with 
        |[] -> new_list
        |h::t ->
            if func a ind b then  
                                let new_new_list = new_list@[h]
                                let new_ind = ind+1
                                vivod1 t a b func new_ind new_new_list
            else 
                let new_new_list = new_list@[]
                let new_ind = ind+1
                vivod1 t a b func new_ind new_new_list
    vivod1 list a b func 1 []
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list = readlist n
    let new_list = vivod list 2 4 (fun x y z -> x<=y && y<=z)
    writelist new_list
    0 // return an integer exit code
