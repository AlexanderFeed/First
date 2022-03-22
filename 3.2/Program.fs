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


let Nov list1 = 
    let rec Nov1 list1 copy itog =
        match list1 with
        |[] -> itog
        |h::t ->
                let new_itog = itog@List.map (fun x->x*h) (List.filter (fun x->x<>h) copy)
                Nov1 t copy new_itog
    Nov1 list1 list1 []     

let proiz list1 =
    let rec proiz1 list1 vopy itog =
        match list1 with 
        |[] -> itog
        |h::t ->
                if List.exists (fun x -> x=h) (Nov (List.filter (fun x->x<>h) vopy)) then 
                                                                 let new_itog = itog@[(List.findIndex (fun x->x=h) vopy )+1]
                                                                 proiz1 t vopy new_itog

                else proiz1 t vopy itog
    proiz1 list1 list1 []


let NovS list1 = 
    let rec NovS1 list1 copy itog =
        match list1 with
        |[] -> itog
        |h::t ->
                if t <> [] then
                                let next = (List.item ((List.findIndex (fun x-> x=h) copy)+1) copy)
                                let new_itog = itog@List.map (fun x->x+h + next) (List.filter (fun x->x<>h && x<>next) copy)
                                NovS1 t copy new_itog
                else 
                    NovS1 t copy itog
    NovS1 list1 list1 []  

let sum list1 =
    let rec sum1 list1 vopy itog =
        match list1 with 
        |[] -> itog
        |h::t ->
                if List.exists (fun x -> x=h) (NovS (List.filter (fun x->x<>h) vopy)) then 
                                                                 let new_itog = itog@[(List.findIndex (fun x->x=h) vopy )+1]
                                                                 sum1 t vopy new_itog

                else sum1 t vopy itog
    sum1 list1 list1 []


let del list1 = 
    let rec del1 list1 copy itog =
        match list1 with 
        |[] -> itog
        |h::t ->
                if (List.length (List.filter (fun x-> h%x =0) (List.filter (fun x-> x<>h) copy))) = 4 then  
                                                                            let new_itog = itog@[(List.findIndex (fun x->x=h) copy )+1]
                                                                            del1 t copy new_itog
                else del1 t copy itog
    del1 list1 list1 []

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list1 = readList n
    let list2 = proiz list1
    let list3 = sum list1
    let list4 = del list1
    let (a,b,c) = (list2,list3,list4)
    Console.WriteLine((a,b,c))
    0 // return an integer exit code
