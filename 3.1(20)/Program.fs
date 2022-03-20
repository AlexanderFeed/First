

// 10, 20, 30, 40, 50, 60

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
             
let rec listok new_list h t =
    if(h<t) then 
                let new_new_list = List.append new_list [h+1]
                let new_h = h+1
                listok new_new_list new_h t
    else 
        new_list


let rec perebor list new_list = 
    match list with
    |[] ->new_list
    |a::b::t ->
            
            if(b-a <>1) then 
                            let new_new_list = listok new_list a (b-1)
                            perebor t new_new_list
            else perebor t new_list

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list = readList n
    let list = Set.toList(Set.ofList(list))
    writeList (perebor list [])
    0 // return an integer exit code
