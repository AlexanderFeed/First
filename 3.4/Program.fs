// Learn more about F# at http://fsharp.org
// 4 11 15
open System
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите строку.")
    let str = Console.ReadLine()
    Console.WriteLine("Какой метод юзаем?")
    let a = Console.ReadLine() |> Int32.Parse
    match a with
    |1 ->
         let str1 = str.[0..(((String.length str)/2)-1)]
         if String.length str%2 =0 then 
                                         let str2 = str.[(((String.length str)/2))..(String.length str)-1]
                                         let list1 = List.rev(Seq.toList str2)
                                         let list2 = Seq.toList str1
                                         let bol = (list1 = list2)
                                         Console.WriteLine(bol)
          else 
             let str2 = str.[(((String.length str)/2)+1)..(String.length str)-1]
             let list1 = List.rev(Seq.toList str2)
             let list2 = Seq.toList str1
             let bol = (list1 = list2)
             Console.WriteLine(bol) 
    |2 ->
        let str = Seq.toList str
        Console.WriteLine(List.length(List.filter (fun x -> x=' ') str)+1)
    |3 ->
            let list = List.distinct(List.splitInto (String.length str) (Seq.toList str))
            Console.WriteLine(List.length list)
    |_ -> Console.WriteLine("Нет такого метода")
            
            
    0 // return an integer exit code
