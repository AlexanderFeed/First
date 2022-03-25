// Learn more about F# at http://fsharp.org

open System

type IPrint = interface
abstract member Print: unit -> unit
end


[<AbstractClass>] 
type Gfig() =  
    abstract member S: unit -> double
    abstract member Pi : float

type rect(w:double, h:double) =
    inherit Gfig()

    let mutable wProp = w
    let mutable hProp = h

    member this.w
        with get() = wProp
        and set(value) = wProp <- value

    member this.h
        with get() = hProp
        and set(value) = hProp <- value
    override this.Pi = 3.1415
    override this.S() = (this.w * this.h)
    override this.ToString() = sprintf "RecW = %f, RecH = %f, RecS = %f" this.w this.h (this.S())
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())


type sq(odna: double) =
    inherit rect(odna, odna)
    override this.Pi = 3.1415
    override this.ToString() = sprintf "SqSide = %f, SqS = %f" this.w (this.S())
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())

type serc(r:double) =
    inherit Gfig()
    let mutable rProp = r
    member this.r
        with get() = rProp
        and set(value) = rProp <- value
    override this.Pi = 3.1415
    override this.S() = (this.Pi * this.r * this.r)

    override this.ToString() = sprintf "CirR = %f, CirS =  %f" this.r (this.S())
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
