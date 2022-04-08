open System.Drawing
open System
open System.Windows.Forms

let form = new Form(Width= 373, Height = 266,Visible = true,Text = "Кортежи в F#",Menu = new MainMenu())
let textBox0 = new TextBox(Text="log(a) b", Left=1, Top=55, Width=45,Height=20);
let textBox1 = new TextBox(Text="0", Left=50, Top=55, Width=55,Height=20);
let textBox2 = new TextBox(Text="0", Left=111, Top=55, Width=55,Height=20);
let label1 = new Label(Text="*", Left=172, Top=58, Width=13, Height=13);
let label2 = new Label(Text="a", Left=71, Top=39, Width=13, Height=13);
let label3 = new Label(Text="b", Left=128, Top=39, Width=13, Height=13);
let button5 = new Button(Text="=", Left=273, Top=53, Width=62, Height=23);
let textBox6 = new TextBox(Text="0", Left=181, Top=55, Width=100, Height=13);
form.Controls.Add(button5);
form.Controls.Add(label3);
form.Controls.Add(textBox0);
form.Controls.Add(textBox6);
form.Controls.Add(label2);
form.Controls.Add(label1);
form.Controls.Add(textBox2);
form.Controls.Add(textBox1);
//let krt _ = label1.Text <- "+"
//let _ = toolStrip1.Click.Add(krt)
////////////////////////////////////////////////////////////////
//let umn _ =label1.Text <- "*"
//let _ = toolStrip3.Click.Add(umn)
////////////////////////////////////////////////////////////////
//let raz _ =label1.Text <- "-"
//let _ = toolStrip2.Click.Add(raz)
////////////////////////////////////////////////////////////////
//let delenie _ =label1.Text <- "/"
//let _ = toolStrip4.Click.Add(delenie)
////////////////////////////////////////////////////////////////
let ravno _ = 
            let a = textBox2.Text |> Double.Parse
            let b = textBox1.Text |> Double.Parse
            textBox6.Text <- string (Math.Log(a,b))
let _ = button5.Click.Add(ravno)
do Application.Run(form)