// Learn more about F# at http://fsharp.org

open System
open System.Text.RegularExpressions
open System.Diagnostics

type Pass(vidan:string, data:string, code:int, ser:int,number:int, NFS:string, gender:string, birth:int, pl_birth:int) =
    member this.a = vidan
    member this.b = data
    member this.c = code
    member this.d = ser
    member this.e = number
    member this.f = NFS
    member this.g = gender
    member this.h = birth
    member this.i = pl_birth
    member this.Print() = printfn "%s %s %i %i %i %s %s %i %i"  this.a this.b this.c this.d this.e this.f this.g this.h this.i 

    interface IComparable with
        member this.CompareTo(obj: obj): int = 
            match obj with
            | :? Pass as pass2 -> if this.d = pass2.d then this.e.CompareTo pass2.e else this.d.CompareTo pass2.d
            | _ -> invalidArg "obj" "Несравнимы" 
    override this.Equals(obj) =
           match obj with
           | :? Pass as pass2 -> (this.d = pass2.d) && (this.e = pass2.e)
           | _ -> false


let assertRegex str regex =
    let r = Regex(regex)
    if not (r.IsMatch str) then
        invalidArg str $"Не поформату: {regex}"

let rec inputField prompt regex =
    printf $"{prompt}: "
    let input = Console.ReadLine()
    try
        assertRegex input regex
        input
    with
    | :? System.ArgumentException as T ->
        printfn "Ошибка: %s" T.Message
        inputField prompt regex
    | T ->
        printfn "Непредвиденное исключение: %s" T.Message
        reraise()

[<AbstractClass>]
type DocColl() =
    abstract member searchDoc: Pass -> Boolean

type ArrayDocCollection(list: Pass list)=
    inherit DocColl()
    member this.DocArray = Array.ofList list

    override this.searchDoc(lic) = 
        Array.exists (fun x-> x.Equals lic) this.DocArray

type ListDocCollection(list: Pass list)=
    inherit DocColl()
    member this.DocList = list

    override this.searchDoc(lic) = 
        List.exists (fun x-> x.Equals(lic)) this.DocList

type BinListDocCollection(list: Pass list)=
    inherit DocColl()

    let rec binSearch (l:Pass list) (license:Pass) =
        match List.length l with
        | 0 -> false
        | i ->
            let middle = i/2
            match sign <| compare license l.[middle] with
            | 0 -> true
            | 1->binSearch l.[..middle - 1] license
            | _->binSearch l.[middle + 1..] license  

    member this.BinList = List.sortBy (fun (x:Pass) -> (x.d, x.e)) list 

    override this.searchDoc(lic) =
        binSearch this.BinList lic

type SetDocCollection(list: Pass list)=
    inherit DocColl()
    member this.DocSet = Set.ofList list

    override this.searchDoc(lic) = 
        Set.contains lic this.DocSet

let charsForRandom = "ауоки"


let randomStr len (random:Random) = 
    let randomChars = [|for i in 0..len -> charsForRandom.[random.Next(charsForRandom.Length)]|]
    
    new System.String(randomChars)

let genRan (random: Random)=
    let a = randomStr 7 random
    let b = randomStr 11 random
    let c = random.Next (100, 999)
    let d = random.Next (100000, 999999)
    let e = random.Next (100000, 999999)
    let f = randomStr 25 random
    let g = randomStr 1 random
    let h = random.Next (1000, 9999)
    let i = random.Next (1000, 9999)
    
    Pass(a, b, c, d, e, f,g ,h ,i)

let genRanList len random = 
    [for i in 0..len -> genRan random]

let Time (watch:Stopwatch) searchMethod lic =
    watch.Reset()
    watch.Start()
    let isFound = searchMethod lic
    watch.Stop()

    watch.ElapsedMilliseconds


let vvod = function 
    |_->
            Console.WriteLine("Введите кем выдан: ")
            let a = Console.ReadLine()
            Console.WriteLine("Дата выдачи: ")
            let b = Console.ReadLine()
            Console.WriteLine("Код подразделения: ")
            let c = Console.ReadLine() |> Int32.Parse
            Console.WriteLine("Серия: ")
            let d = Console.ReadLine() |> Int32.Parse
            Console.WriteLine("Номер: ")
            let e = Console.ReadLine()|> Int32.Parse
            Console.WriteLine("ФИО: ")
            let f = Console.ReadLine()
            Console.WriteLine("Пол: ")
            let g = Console.ReadLine() 
            Console.WriteLine("Дата рождения: ")
            let h = Console.ReadLine() |> Int32.Parse
            Console.WriteLine("Место рождения: ")
            let i = Console.ReadLine() |> Int32.Parse
            Pass(a,b,c,d,e,f,g,h,i)

[<EntryPoint>]
let main argv =
    let pass1 = vvod 1 
    let ran = Random()
    let mnogo = genRanList 100 ran @ [pass1] @ genRanList 250 ran
    //запускаем все функции
    let Mass = ArrayDocCollection(mnogo)
    let List = ListDocCollection(mnogo)
    let Binya = BinListDocCollection(mnogo)
    let Set = SetDocCollection(mnogo)
    let watch = new Stopwatch()
    Mass.searchDoc pass1
    watch.Reset()
    List.searchDoc pass1
    watch.Reset()
    Binya.searchDoc pass1
    watch.Reset()
    Set.searchDoc pass1
    watch.Reset()
    0 // return an integer exit code
