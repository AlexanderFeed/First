// Learn more about F# at http://fsharp.org

open System
let language (x:string) = 
    match x with
        | "F#" | "Prolog" -> "
Ну ты подзила =D"
        | "C++" -> "
Заработал только два плючика"
        | "C#" -> "
Ты музыкант?"
        | "Java" -> "
Ну ты жаба"
        | "Ruby" -> "
Рубинов захотел?"
        | "JavaScript" -> "
1+1 = 1"
        | "HTML" -> "
Ну приехали"
        | "Python" -> "
И где твой питон?"
        | "Swift" -> "
Рустам, разлогинься"
        |_ -> "
Такого нет"

[<EntryPoint>]
let main argv =
    printfn "Какой твой любимый язык программирования?"
    let x = Console.ReadLine();
    Console.Write(language x)
    0 // return an integer exit code
