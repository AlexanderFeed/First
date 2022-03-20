// Learn more about F# at http://fsharp.org

open System
let rec readlist n = 
    match n with
    |0 -> []
    |_ ->
        let Head = Console.ReadLine() |> Int32.Parse
        let Tail = readlist (n-1)
        Head::Tail

let rec writelist = function
    [] ->[]
    | (h:int)::t ->
            Console.WriteLine(h)
            writelist t


let sravn nachalnii a =
    let rec sravn1 nachalnii a bol =
        match nachalnii with
        |[] -> bol
        |h::t ->
                if(h=a) then 
                            let new_bol = true
                            sravn1 t a new_bol
                else sravn1 t a bol
    sravn1 nachalnii a false


let delfirst = function
    |h::t -> (t)

let proverka list_sum pr = 
    let rec proverka1 list_sum pr bol = 
        match list_sum with 
        |[] -> bol
        |h::t ->
                if(h = pr) then 
                                let new_bol = true
                                proverka1 t pr new_bol
                else proverka1 t pr bol
    proverka1 list_sum pr false

let sum list pacient func nachalnii list_sum =
    let rec sum1 list pacient func nachalnii list_sum kolvo =
        match list with
        |[] -> kolvo
        |h::t ->
                if sravn nachalnii (func pacient h) then
                                                        if proverka list_sum (func pacient h) then let new_kolvo = kolvo
                                                                                                   sum1 t pacient func nachalnii list_sum new_kolvo
                                                        else 
                                                            let new_kolvo = kolvo+1
                                                            let new_list_sum = list_sum @ [(func pacient h)]
                                                            sum1 t pacient func nachalnii new_list_sum new_kolvo
                else sum1 t pacient func nachalnii list_sum kolvo 
    sum1 list pacient func nachalnii list_sum 0

let proverennie list pacient func nachalnii =
    let rec prov1 list pacient func nachalnii kolvo list_sum =
        match list with
        |[] -> list_sum
        |h::t ->
                if sravn nachalnii (func pacient h) then
                                                        if proverka list_sum (func pacient h) then let new_kolvo = kolvo
                                                                                                   prov1 t pacient func nachalnii new_kolvo list_sum
                                                        else 
                                                            let new_kolvo = kolvo+1
                                                            let new_list_sum = list_sum @ [(func pacient h)]
                                                            prov1 t pacient func nachalnii new_kolvo new_list_sum
                else prov1 t pacient func nachalnii kolvo list_sum
    prov1 list pacient func nachalnii 0 []

let vse list nachalnii =
    let rec vse1 list nachalnii k list_sum =
        match list with
        |[] -> k
        |h::t ->
                let pacient = h
                let new_list = delfirst list
                let new_k = k + sum new_list pacient (fun x y -> x+y) nachalnii list_sum
                let list_sum = proverennie new_list pacient (fun x y -> x+y) nachalnii
                vse1 new_list nachalnii new_k list_sum
    vse1 list list 0 []

[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list = readlist n
    let finish = vse list list
    Console.WriteLine(finish)
    0 // return an integer exit code
