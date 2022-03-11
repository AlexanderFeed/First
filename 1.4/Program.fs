// Learn more about F# at http://fsharp.org

open System
let deli x func init =
    let rec dev x func init cur_dev =
       if(cur_dev = 0) then init
       else
          let new_init = if x%cur_dev = 0 then func init cur_dev else init
          let new_cur_dev = cur_dev - 1
          dev x func new_init new_cur_dev
    dev x func init x
[<EntryPoint>]
let main argv =
    let x = Console.ReadLine() |> Int32.Parse
    Console.WriteLine("Result:")
    Console.WriteLine(deli x (fun x y -> x + y) 0)
    0 // return an integer exit code
