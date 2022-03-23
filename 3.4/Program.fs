// Learn more about F# at http://fsharp.org
// 4 11 15
open System

let prov str1 str2 =
    let rec prov1 (str1:string) n (str2:string) bol =
        if n = 0 then bol 
        else if str1.[n] = str2.[(String.length str1 )-n-1] then 
                                                                let new_bol = true
                                                                prov1 str1 (n-1) str2 new_bol
             else false
    prov1 str1 ((String.length str1)-1) str2 false

[<EntryPoint>]
let main argv =
    let str = Console.ReadLine()
    let str1 = str.[0..(((String.length str)/2)-1)]
    if String.length str%2 =0 then 
                                    let str2 = str.[(((String.length str)/2))..(String.length str)-1]
                                    Console.WriteLine(prov str1 str2)
     else 
        let str2 = str.[(((String.length str)/2)+1)..(String.length str)-1]
        Console.WriteLine(prov str1 str2)   
    0 // return an integer exit code
