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
    let list = List.filter (fun x -> x%2 =0) list
    Console.WriteLine(List.min list)
    0 // return an integer exit code
