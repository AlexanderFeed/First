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

let comparer list2 h =
    let rec comparer1 list2 h bol kolvo =
        match list2 with
        |[] -> bol
        |a::t ->
                if(a=h && bol = false && kolvo = 0) then
                                            let new_bol = true
                                            let new_kolvo = kolvo+1
                                            comparer1 t h new_bol new_kolvo
                else comparer1 t h bol kolvo
    comparer1 list2 h false 0

let first list1 list2 =
    let rec first1 list1 list2 new_list =
        match list1 with
        |[] -> new_list
        |h::t ->
                if(comparer list2 h) then 
                                        first1 t list2 new_list
                else 
                    let new_new_list = new_list@[h]
                    first1 t list2 new_new_list
    first1 list1 list2 []
                    
let predicate (_,x) =
    if x=1 then true
    else false
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list1 = readList n
    Console.WriteLine("Вторая n: ")
    let n = Console.ReadLine() |> Int32.Parse
    let list2 = readList n
    let list1 = List.sort list1
    let list2 = List.sort list2
    let spisok = first list1 list2
    let spisok = spisok@(first list2 list1)
    let spisok = List.countBy id spisok
    let spisok = List.filter predicate spisok 
    let spisok, edichi = List.unzip spisok
    writeList spisok
    0 // return an integer exit code
