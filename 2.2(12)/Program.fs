// Learn more about F# at http://fsharp.org
// Задачи 9, 12, 22, 24, 31, 34, 40, 46, 58
//1.9
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

let pos list m =
    let rec pos1 list m min_num num =
        match list with
        |[] -> min_num
        |h::t->
            if (h>m) then 
                let new_num = num+1
                pos1 t m min_num new_num
            else 
                let new_num = num+1
                let new_min_num = num
                let new_m = h 
                pos1 t new_m new_min_num new_num
    pos1 list m m 1

let posm list m =
    let rec posm1 list m num =
        match list with
        |[] -> num
        |h::t->
            if (h<m) then num
            else 
                let new_num = num+1 
                let new_m = h 
                posm1 t new_m new_num
    posm1 list m 0

let vivod list p =
    let rec vivod1 list p pop new_list = 
        match list with 
        | [] -> new_list
        | h::t ->
            if(pop<=p) then  new_list @ [h] 
            else new_list @ [] 
            let new_pop = pop+1
            vivod1 t p new_pop new_list
    vivod1 list p 1 []
[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Convert.ToInt32
    let list = readList n
    let first = List.head list
    let pomi = pos list first
    let poma = posm list first
    Console.WriteLine(poma)
    Console.WriteLine(pomi)
    //let new_list = if(poma<pomi) then vivod list poma
    //                else vivod list pomi
    //Console.WriteLine(new_list)
    
    0 // 
