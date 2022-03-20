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

let odin list =
    List.append list [1]

let New list n = 
    if n % 3 = 1 then odin list |> odin
    else if n % 3 = 2 then odin list 
    else list

let proc list func =
    let rec proc1 list func new_list =
        match list with
        | [] -> new_list
        | a::b::c::t ->
            let three = func a b c 
            let new_new_list = new_list @ [three]
            let listik = if t<>[] then t.Tail else []
            proc1 listik func new_new_list
    proc1 list func [] /////////?
            
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Convert.ToInt32
    let list = readList n
    let new_list = New list n 
    let new_new_list = proc new_list (fun x y z -> x+y+z)
    writeList new_new_list
    0 // return an integer exit code
