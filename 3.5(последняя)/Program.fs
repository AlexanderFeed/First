// Learn more about F# at http://fsharp.org

open System

let rec readList n = 
    if n=0 then []
    else
        let Head = Console.ReadLine() 
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
    Console.WriteLine(readList n) 
    0 
