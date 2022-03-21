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

let novoe list =
    let rec novoe1 list new_list schet =
        match list with
        |[] -> new_list
        |h::t ->
                if h % schet = 0 then
                                    let new_schet = schet+1
                                    let new_new_list = new_list@[h]
                                    novoe1 t new_new_list new_schet
                else
                    let new_schet = schet+1
                    novoe1 t new_list new_schet
    novoe1 list [] 1
                

let predicate (_,x) =
    if x<>1 then true
    else false

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list1 = readList n
    let spisok1 = novoe list1
    let spisok2 = List.countBy id list1
    let spisok2 = List.filter predicate spisok2 
    let spisok2, edichi = List.unzip spisok2
    let finish = List.except spisok2 spisok1 
    writeList finish
    0 // return an integer exit code
