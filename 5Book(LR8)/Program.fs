open System

type Maybe<'a> =
    | Just of 'a
    | Nothing

let fmapMaybe f p =
    match p with
    | Just a -> Just (f a)
    | Nothing -> Nothing

let applyMaybe lf p =
    match lf, p with
    | Just f, Just a -> Just (f a)
    | _-> Nothing   

let monadMaybe p f =
    match p with
    | Just a -> f a
    | _-> Nothing 

let id a = a
let f1 a = a + 3
let f2 a = a * 5

[<EntryPoint>]
let main argv =
    //id не влияет на вычисления
    let x1 = fmapMaybe f1 (Just 5)
    Console.WriteLine(id x1)
    Console.WriteLine(fmapMaybe id x1)
    // Подьемы композиции = композиция подъемов 
    let x2 = fmapMaybe f1 x1 
    let x3 = fmapMaybe f2 x2
    let x4 = fmapMaybe(f1 >> f2) x1
    let x5 = applyMaybe (Just f1) (Just 2)
    Console.WriteLine(x3)
    Console.WriteLine(x4)
    //
    Console.WriteLine(id x5)
    Console.WriteLine(applyMaybe (Just id) x5)
    //
    let a = 2
    let b = id a
    let t1 = applyMaybe (Just id) (Just a)
    let t2 = Just b
    Console.WriteLine(t1)
    Console.WriteLine(t2)
    //ассоциативна
    //let t1 = applyMaybe (Just f1) (Just 2)
    //let t2 = applyMaybe (Just 3) (Just f2)//?????????????
    //Композиция функций apply ассоциативна. не проверить
    0
