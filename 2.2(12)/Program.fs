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
    let rec posm1 list m min_num num =
        match list with
        |[] -> min_num
        |h::t->
            if (h<m) then 
                let new_num = num+1
                posm1 t m min_num new_num
            else 
                let new_num = num+1
                let new_min_num = num
                let new_m = h 
                posm1 t new_m new_min_num new_num
    posm1 list m m 1

let vivod list p =
    let rec vivod1 list p pop new_list = 
        match list with 
        | [] -> new_list
        | h::t ->
            if(pop<=p) then  
                let new_pop = pop+1
                vivod1 t p new_pop (new_list @ [h])
            else 
                let new_pop = pop+1
                vivod1 t p new_pop (new_list @ [])
    vivod1 list p 1 []

let vivod2 list p pm =
    let rec vivod21 list p pm now new_list = 
        match list with 
        | [] -> new_list
        | h::t ->
            if(now>p && now<pm || now<p && now>pm) then  
                let new_now = now+1
                vivod21 t p pm new_now ( [h] @ new_list)
            else 
                let new_now = now+1
                vivod21 t p pm new_now (new_list @ [])
    vivod21 list p pm 1 []

    
let vivod3 list p =
    let rec vivod31 list p pop new_list = 
        match list with 
        | [] -> new_list
        | h::t ->
            if(pop>=p) then  
                let new_pop = pop+1
                vivod31 t p new_pop (new_list @ [h])
            else 
                let new_pop = pop+1
                vivod31 t p new_pop (new_list @ [])
    vivod31 list p 1 []

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Convert.ToInt32
    let list = readList n
    let first = List.head list
    let pomi = pos list first
    let poma = posm list first
    let new_list = if(poma<pomi) then vivod list poma
                    else vivod list pomi
    let new_new_list = if(poma<pomi) then vivod2 list poma pomi 
                        else vivod2 list pomi poma
    let new_new_new_list = if(poma<pomi) then vivod3 list pomi
                            else vivod3 list poma
    let finish = new_list@ new_new_list@new_new_new_list
    writeList finish
    
    0 // 
