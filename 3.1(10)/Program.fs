

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

let rec perebor list1 list2 kolvo = 
    match list1 with
    | [] -> kolvo
    | h::t ->
               let new_kolvo = kolvo + List.length (List.filter (fun x -> x=h) list2)
               perebor t list2 new_kolvo                
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list1 = readList n
    Console.WriteLine("Вторая n: ")
    let n = Console.ReadLine() |> Int32.Parse
    let list2 = readList n
    let list1 = List.distinct list1
    let list2 = List.distinct list2
    Console.WriteLine("Ответ: ")
    Console.WriteLine(perebor list1 list2 0)
    0 // return an integer exit code
