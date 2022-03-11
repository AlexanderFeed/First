// Learn more about F# at http://fsharp.org

open System
//1.6
let rec nod a b =
    if a = b then a
    else
        if (a > b) then 
            let new_a = b 
            let new_b = a-b
            nod new_a new_b
        else 
            let new_a = a 
            let new_b = b-a
            nod new_a new_b
//1.5
let prost chislo func init =
    let rec schet chislo func init dannoe = 
        if(dannoe <=1) then init
        else
            let new_init = if nod chislo dannoe = 1 then func dannoe init else init
            let new_dannoe = dannoe-1
            schet chislo func new_init new_dannoe
    schet chislo func init chislo
[<EntryPoint>]
let main argv =
    Console.WriteLine(prost 4 (fun x y -> x*y) 1)
    0 
