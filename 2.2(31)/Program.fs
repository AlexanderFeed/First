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

let poisk list func =
    let rec poisk1 list func kolvo =
        match list with
        |[] -> kolvo
        |h::t -> 
                if func h then 
                                let new_kolvo = kolvo+1
                                poisk1 t func new_kolvo
                else
                    poisk1 t func kolvo
    poisk1 list func 0
            
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list = readList n
    let k = poisk list (fun x -> x%2=0)
    Console.WriteLine(k)
    0 // return an integer exit code
