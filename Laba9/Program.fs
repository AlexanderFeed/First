// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
// See the 'F# Tutorial' project for more help.
open System
open System.Drawing
open System.IO
open System.Windows.Forms
let form = new Form(Width= 400, Height = 300, Text = "F# Главная форма",
Menu = new MainMenu())
let mForms = form.Menu.MenuItems.Add("&Формы")
let miForm1 = new MenuItem("&Форма_1")
mForms.MenuItems.Add(miForm1)
//Форма_1
let Form1 = new Form(Text = "Дочерняя форма №1" ,Width = 400, Height = 300)
let Edit1 = new TextBox(Text="10")
let Edit2 = new TextBox(Top=20, Text="5")
let button1 = new Button(Text="Площадь", Top=50, Width=125, Height=25)
Form1.Controls.Add(Edit1)
Form1.Controls.Add(Edit2)
Form1.Controls.Add(button1)
let Umnoj _ = MessageBox.Show(string(int(Edit1.Text) * (int(Edit2.Text))),"Площадь прямоугольника с введенными сторонами") |>ignore
let _ = button1.Click.Add(Umnoj)
let opForm1 _ = do Form1.ShowDialog()
let _ = miForm1.Click.Add(opForm1)
[<EntryPoint>]
let main argv =
    do Application.Run(form)
    0 // return an integer exit code
