﻿// Learn more about F# at http://fsharp.org

open System

let rec readList n = 
    if n=0 then []
    else
        let Head = Console.ReadLine() 
        let Tail = readList (n-1)
        Head::Tail

let rec writeList = function
    [] ->   []
    | (head : int)::tail -> 
                   System.Console.WriteLine(head)
                   writeList tail 

let sr_kolvo_sogl stroka =
    let rec sr1 (stroka:string) n (itog:double) = 
        match n with
        |(-1) -> 
                itog/Convert.ToDouble(String.length stroka)
        |_ ->
                let new_itog = if (stroka.[n] = 'a' || stroka.[n] = 'e' || stroka.[n] = 'i' || stroka.[n] = 'o' || stroka.[n] = 'u' || stroka.[n] = 'y') then itog else (itog+1.0) 
                sr1 stroka (n-1) new_itog
    sr1 stroka ((String.length stroka)-1) 0.0
                                                                            
let sr_kolvo_glas stroka =
    let rec sr1 (stroka:string) n (itog:double) = 
        match n with
        |(-1) -> 
                itog/Convert.ToDouble(String.length stroka)
        |_ ->
                let new_itog = if (stroka.[n] = 'a' || stroka.[n] = 'e' || stroka.[n] = 'i' || stroka.[n] = 'o' || stroka.[n] = 'u' || stroka.[n] = 'y') then itog+1.0 else itog 
                sr1 stroka (n-1) new_itog
    sr1 stroka ((String.length stroka)-1) 0.0                

let razn_sr list =
    let rec razn_sr1 list itog =
        match list with
        |[] -> itog
        |h::t ->
                let new_itog = itog@[abs(sr_kolvo_glas h - sr_kolvo_sogl h)]
                razn_sr1 t new_itog
    razn_sr1 list []



[<EntryPoint>]
let main argv =
    let n = Console.ReadLine() |> Int32.Parse
    let list = readList n
    let number, finish = List.unzip (List.sort (List.zip (razn_sr list) list))
    Console.WriteLine(finish)
    0 
