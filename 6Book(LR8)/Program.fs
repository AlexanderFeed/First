// Learn more about F# at http://fsharp.org

//Разработайте программу, которая осуществляет разбор текста с использованием библиотеки FParsec. 
//Результатом разбора должны быть значения алгебраического типа.
open System
open FParsec
// Задаем типы 
type Expr =
    | Num of float
    | Plus of Expr * Expr
    | Minus of Expr * Expr

//разбирает и возвращает то, что с точкой
let pstring_trim s = spaces >>. pstring s .>> spaces
let float_ws = spaces >>. pfloat .>> spaces


let parser, parserRef = createParserForwardedToRef<Expr, unit>()
//Парсим по знаку +/-
let parsePlusExpr = tuple2 (parser .>> pstring_trim "+") parser |>> Plus
let parseSubExpr = tuple2 (parser .>> pstring_trim "-") parser |>> Minus
//Парсим сам знак и значения
let parseOp = between (pstring_trim "(") (pstring_trim ")") (attempt parsePlusExpr <|> parseSubExpr)
//отделелили распарсенные значения
let parseNum = float_ws |>> Num
//вызов let`а выше, для сохранения знака и значений
parserRef := parseNum <|> parseOp


// Ее вызываем, чтобы значение вернуть
let rec EvalExpr (e:Expr): float =
    match e with
    | Num(num) -> num
    | Plus(a,b) ->
        let left = EvalExpr(a)
        let right = EvalExpr(b)
        let result = left + right
        result
    | Minus(a,b) ->
        let left = EvalExpr(a)
        let right = EvalExpr(b)
        let result = left - right
        result



[<EntryPoint>]
let main argv =
    let input = Console.ReadLine() 
    let expr = run parser input

    match expr with
    | Success (result, _, _) -> Console.WriteLine(EvalExpr result)
    | Failure (errorMsg, _, _) -> Console.WriteLine(errorMsg)

    0