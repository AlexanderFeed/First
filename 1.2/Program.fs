// Learn more about F# at http://fsharp.org

open System
let language (x:string) = 
    match x with
        | "F#" | "Prolog" -> "Ну ты подзила =D"
        | "C++" -> "Заработал только два плючика"
        | "C#" -> "Ты музыкант?"
        | "Java" -> "Ну ты жаба"
        | "Ruby" -> "Рубинов захотел?"
        | "JavaScript" -> "1+1 = 11"
        | "HTML" -> "Ну приехали"
        | "Python" -> "И где твой питон?"
        | "Swift" -> "Рустам, разлогинься"
        |_ -> "Такого нет"

[<EntryPoint>]
let main argv =
//1.2.1
    printfn "Какой твой любимый язык программирования?"
    (Console.ReadLine >> language >> Console.WriteLine)()
//1.2.2
    printfn "
Какой твой любимый язык программирования?"
    Console.WriteLine(language(Console.ReadLine()))
    0 // return an integer exit code