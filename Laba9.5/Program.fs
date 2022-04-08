open System
open System.Windows.Forms
open System.Drawing
Application.EnableVisualStyles()
let form = new Form(Width=302, Height=350,Text = "Работа со списками")
let button1 = new Button(Left=21, Top=38, Text="вывод списка", Width=96,Height=23)
let textBox1 = new TextBox(Left=156, Top=38, Width=114, Height=20)
let textBox2 = new TextBox(Left=106, Top=10, Width=114, Height=20)
// Form1
//
form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
form.ClientSize = new System.Drawing.Size(302, 314);
form.Controls.Add(textBox1);
form.Controls.Add(textBox2);
form.Controls.Add(button1);
textBox2.Text <- "Есть ли '5' в листе?"
form.Text = "Работа со списками";
form.ResumeLayout(false);
form.PerformLayout();

button1.Click.AddHandler(fun _ _ ->
        let list1 = [for i in 1 .. 10 -> i * i ]
        let bool = List.exists (fun x -> x=5) list1
        if bool = true then 
                            let run = textBox1.Text<- ("True")   
                            run
        else
            let run = textBox1.Text<- ("False")   
            run
        |> ignore)

Application.Run(form)