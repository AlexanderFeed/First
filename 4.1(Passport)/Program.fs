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
    member this.Print() = printfn "%s %s %s %i %i %s %c %s %s"  this.a this.b this.c this.d this.e this.f this.g this.h this.i 



let vvod = function 
    |_->
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
            Pass(a,b,c,d,e,f,g,h,i)

[<EntryPoint>]
let main argv =
    let pass1 = vvod 1 
    let pass2 = vvod 1
    Console.Write("Серии: ")
    Console.Write(pass1.d)
    Console.Write("  ")
    Console.WriteLine(pass2.d)
    Console.Write("Номера: ")
    Console.Write(pass1.e)
    Console.Write("  ")
    Console.WriteLine(pass2.e)
    Console.WriteLine("Посмотрели и сравнили") 
    0 // return an integer exit code
