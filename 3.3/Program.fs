// Learn more about F# at http://fsharp.org

open System

let readarr n =
    let rec readarr1 n arr =
        match n with
        |0 -> arr
        |_ ->
            let Head = Console.ReadLine() |> Double.Parse
            let new_arr = Array.append arr [|Head|]
            readarr1 (n-1) new_arr
    readarr1 n Array.empty

let writearr arr =  
    printfn "%A" arr

let qp a =
    let rec qp1 a mod_a (itog:float []) =
        match mod_a with
        |0.0 -> itog
        |_ ->
            if a%mod_a =0.0 then 
                               let new_itog = Array.append itog [|mod_a|]
                               qp1 a (mod_a-1.0) new_itog
            else qp1 a (mod_a-1.0) itog
    qp1 a a [||]


let otdel arr1 a =
    let rec otdel1 arr1 a n new_arr =
        if n <> Array.length arr1 then 
                                        let new_new_arr = Array.append new_arr [|arr1.[n]/a|]
                                        otdel1 arr1 a (n+1) new_new_arr
        else new_arr
    otdel1 arr1 a 0 [||]

let del arr1 arr2 =
    let rec del1 (arr1:float []) (arr2:float []) n (itog:float []) =
        if n <> Array.length arr2 then 
                                    let new_itog = Array.append itog (otdel arr1 arr2.[n])
                                    del1 arr1 arr2 (n+1) new_itog
        else itog
    del1 arr1 arr2 0 [||]

//Если многочлен с целыми коэффициентами f (x) = anxn + an-1xn-1 + … + a1x+a0  имеет рациональный корень x=p/q (q ≠ 0, дробь p/q  несократимая), 
//то р является делителем свободного члена (a0), а q — делителем коэффициента при стар­шем члене аn.
[<EntryPoint>]
let main argv =
    let n =Console.ReadLine() |> Int32.Parse
    let arra = readarr n
    let p = qp (arra.[n-1])
    let q = qp (arra.[0])
    //Console.WriteLine(p)
    //Console.WriteLine(q)
    let finish = del p q
    writearr finish
    0 // return an integer exit code
