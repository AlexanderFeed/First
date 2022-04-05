open System

let num = "5"
let Gues= MailboxProcessor.Start(fun inbox->
    let rec messageLoop() = async {
        let! (msg:string) = inbox.Receive()

        let response = match msg.ToLower() with
        | "5" -> "Ты угадал загаданное число, ты настоящий уличный маг! Можешь ввести пустую строку и закрыть прогу"
        |_ -> "Неверно"
        printfn "<- %s" response

        return! messageLoop()
    }

    messageLoop()
)

let rec askUser() =
    Console.WriteLine("Значит ты уличный маг? Тогда угадай число, котороя я загадал!!!")
    let input = Console.ReadLine()
    if not (String.IsNullOrEmpty input) then
        Gues.Post(input)
        askUser()

[<EntryPoint>]
let main argv =
    askUser()
    0