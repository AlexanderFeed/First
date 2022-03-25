// Learn more about F# at http://fsharp.org

open System

type Pass(vidan:string, data:string, code:string, ser,number, NFS:string, gender:char, birth:string, pl_birth:string) =
    member this.a = vidan
    member this.b = data
    member this.c = code
    member this.d = ser
    member this.e = number
    member this.f = NFS
    member this.g = gender
    member this.h = birth
    member this.i = pl_birth


[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите кем выдан: ")
    let a = Console.ReadLine()
    Console.WriteLine("Дата выдачи: ")
    let b = Console.ReadLine()
    Console.WriteLine("Код подразделения: ")
    let c = Console.ReadLine()
    Console.WriteLine("Серия: ")
    let d = Console.ReadLine() |> Int32.Parse
    Console.WriteLine("Номер: ")
    let e = Console.ReadLine()|> Int32.Parse
    Console.WriteLine("ФИО: ")
    let f = Console.ReadLine()
    Console.WriteLine("Пол: ")
    let g = Console.ReadLine() |> Char.Parse
    Console.WriteLine("Дата рождения: ")
    let h = Console.ReadLine()
    Console.WriteLine("Место рождения: ")
    let i = Console.ReadLine()
    let pass1 = Pass(a,b,c,d,e,f,g,h,i)
    0 // return an integer exit code
