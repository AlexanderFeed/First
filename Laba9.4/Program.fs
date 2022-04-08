open System
open System.Windows.Forms
open System.Drawing
Application.EnableVisualStyles()
let form = new Form(Text="Работа с массивами")

let label2 = new Label()
label2.Location<-new Point(15,15)
label2.Text<-"Коэфф"
label2.Width<-60
label2.Height<-12

let TextBox = new TextBox()
TextBox.Location<-new Point(170,50)
TextBox.Width<-60
TextBox.Height<-25
TextBox.Text<-""

let TextBox1 = new TextBox()// Создание текстового поля для ввода инфор-мации
TextBox1.Location<-new Point(80,10)
TextBox1.Width<-150
TextBox1.Height<-25
TextBox1.Text<-""


// Создание кнопки с текстом "Вывести"
let button = new Button(Text="Вывести_1")
button.Location<-new Point(15,50) // позиция кнопки

let getArrayFromTextBox (txt: TextBox) =
    let str = txt.Text.Trim()
    if String.IsNullOrEmpty str then 
        [||]
    else
        let parts = str.Split(' ')
        Array.map (fun str -> Double.Parse str) parts

let del (num:float) =
    let rec del1 (num:float) (kond:float) (itog:array<float>) =
        match kond with
        |0.0 -> itog
        |_ ->
                if num%kond =0.0 then 
                                    del1 num (kond-1.0) (Array.append itog [|kond|])
                else
                    del1 num (kond-1.0) itog
    del1 num num [||]
            

let otvet massP massQ = 
    let rec otvet1 massP massQ itog schet =
        if(schet = Array.length massQ) then itog
        else otvet1 massP massQ (Array.append (itog) (Array.map (fun x -> x/(massQ.[schet])) massP)) (schet+1) 
    otvet1 massP massQ [||] 0


//Добавление обработчика события - Нажатие на кнопку
button.Click.AddHandler(fun _ _ ->
                                   let array = getArrayFromTextBox TextBox1
                                   let first = Array.head array
                                   let last = Array.last array
                                   let del_star = del first //q
                                   let del_mlad = del last//p   x=p/q
                                   let opa = otvet del_mlad del_star
                                   let opa1 = Array.map (fun x -> -x) opa
                                   let opa = Array.append opa opa1
                                   let v = TextBox.Text <- (opa |> Seq.map string |> String.concat ",")
                                   v
                                   //let run = TextBox.Text<- Convert.ToString(array)
                                   //run
                                   |> ignore)
//Добавление элементов на форму
form.Controls.Add(button)

form.Controls.Add(label2)
form.Controls.Add(TextBox)
form.Controls.Add(TextBox1)
// запуск формы
Application.Run(form)