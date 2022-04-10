// Learn more about F# at http://fsharp.org
// 4 11 15
open System

let probel str = 
    let rec probel1 (str:string) n kolvo =
        match n with
        |(-1) -> kolvo
        |_ ->
                if str.[n] = ' ' then 
                                        let new_kolvo = kolvo+1
                                        probel1 str (n-1) new_kolvo
                else probel1 str (n-1) kolvo
    probel1 str ((String.length str)-1) 1


let proxod str elem = 
    let rec proxod1 (str:string) n elem bol =
        match n with
        |(-1) -> bol
        |_ ->
                if elem = str.[n] && bol = true then
                                                    false
                else if elem = str.[n] && bol = false then 
                                                            let new_bol = true
                                                            proxod1 str (n-1) elem new_bol
                        else proxod1 str (n-1) elem bol
    proxod1 str ((String.length str)-1) elem false
let metod3 str = 
    let rec inmetod3 (str:string) n kolvo =
        match n with
        |(-1) -> kolvo
        |_ -> 
                if proxod str str.[n] then 
                                            let new_kolvo = kolvo+1
                                            inmetod3 str (n-1) new_kolvo
                else 
                        let new_kolvo = kolvo+1
                        let new_str = String.filter (fun x -> x<>str.[n]) str
                        let otnimaemoe_str = String.filter (fun x -> x=str.[n]) str
                        inmetod3 new_str (n-(String.length otnimaemoe_str)) new_kolvo
    inmetod3 str ((String.length str)-1) 0
        
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
        Console.WriteLine(List.filter (fun x -> x=' ') str)
    |3 ->
            Console.WriteLine(metod3 str)
    |_ -> Console.WriteLine("Нет такого метода")
            
            
    0 // return an integer exit code
