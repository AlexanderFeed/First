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

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
