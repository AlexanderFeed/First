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
             
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list = readList n
    let index = Console.ReadLine() |> Int32.Parse
    let item = List.item index list
    let max_index = (n-1)
    match index with
    |0 ->
        if item > List.item (index+1) list then Console.WriteLine("Макс")
        else Console.WriteLine("Не макс")
    |max_index -> if item > List.item (index-1) list then Console.WriteLine("Макс")
                    else Console.WriteLine("Не макс")
    |_ -> if item > List.item (index+1) list && item > List.item (index-1) list then Console.WriteLine("Макс")
            else Console.WriteLine("Не Макс")
    0 // return an integer exit code
