
open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
//Главная форма
let mwXaml = "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
Title='F# WPF' Height='280' Width='320'>
<Grid>
<Grid.ColumnDefinitions>
<ColumnDefinition Width='156*' />
<ColumnDefinition Width='163' />
</Grid.ColumnDefinitions>
<GroupBox Header='[Варианты окна:]' Height='89' HorizontalAlignment='
Left' Name='groupBox1' VerticalAlignment='Top' Width='313'
Grid.ColumnSpan='2'>
<Grid>
<Grid.ColumnDefinitions>
<ColumnDefinition Width='38*' />
<ColumnDefinition Width='453*' />
</Grid.ColumnDefinitions>
<Button Content='Tool Window' Grid.ColumnSpan='2' Height='23'
HorizontalAlignment='Left' Margin='6,6,0,0' Name='button1' VerticalAlignment='
Top' Width='138' />
<Button Content='Single Border Window' Height='23' HorizontalAlignment='
Left' Margin='6,35,0,0' Name='button2' VerticalAlignment='Top'
Width='138' Grid.ColumnSpan='2' />
<Button Content='3D Border Window' Height='23' HorizontalAlignment='
Left' Margin='131,6,0,0' Name='button3' VerticalAlignment='Top'
Width='138' Grid.Column='1' />
<Button Content='None Border Window' Height='23' HorizontalAlignment='
Left' Margin='132,35,0,0' Name='button4' VerticalAlignment='Top'
Width='138' Grid.Column='1' />
</Grid>
</GroupBox>
<GroupBox Header='[Положение окна:]' Height='92' HorizontalAlignment='
Left' Margin='0,95,0,0' Name='groupBox2' VerticalAlignment='Top'
Width='313' Grid.ColumnSpan='2'>
<Grid>
<Grid.ColumnDefinitions>
<ColumnDefinition Width='74*' />
<ColumnDefinition Width='227' />
</Grid.ColumnDefinitions>
<Button Content='Move Top' Height='23' HorizontalAlignment='Left'
Margin='6,6,0,0' Name='button5' VerticalAlignment='Top' Width='138'
Grid.ColumnSpan='2' />
<Button Content='Move Bottom' Height='23' HorizontalAlignment='
Left' Margin='6,35,0,0' Name='button6' VerticalAlignment='Top'
Width='138' Grid.ColumnSpan='2' />
<Button Content='Move Left' Height='23' HorizontalAlignment='Left'
Margin='81,6,0,0' Name='button7' VerticalAlignment='Top' Width='137'
Grid.Column='1' />
<Button Content='Move Right' Height='23' HorizontalAlignment='
Left' Margin='81,35,0,0' Name='button8' VerticalAlignment='Top'
Width='137' Grid.Column='1' />
</Grid>
</GroupBox>
<Button Content='Справка' Height='23' HorizontalAlignment='Left' Margin='
12,219,0,0' Name='button9' VerticalAlignment='Top' Width='90' />
<Button Content='Автор' Height='23' HorizontalAlignment='Left' Margin='
110,219,0,0' Name='button10' VerticalAlignment='Top' Width='90'
Grid.ColumnSpan='2' />
<Button Content='Выход' Height='23' HorizontalAlignment='Left' Margin='
60,219,0,0' Name='button11' VerticalAlignment='Top' Width='90'
Grid.Column='1' />
<Button Content='Create new Window' Height='23' HorizontalAlignment='
Left' Margin='12,193,0,0' Name='button12' VerticalAlignment='Top'
Width='286' Grid.ColumnSpan='2' />
</Grid>
</Window>
"
// загрузка разметки XAML
let getWindow(mwXaml) = let xamlObj=XamlReader.Parse(mwXaml)
                        xamlObj :?> Window
let win = getWindow(mwXaml)
//получение экземпляров элементов управления
//главная форма:
let button1 = win.FindName("button1") :?> Button
let button2 = win.FindName("button2") :?> Button
let button3 = win.FindName("button3") :?> Button
let button4 = win.FindName("button4") :?> Button
let button5 = win.FindName("button5") :?> Button
let button6 = win.FindName("button6") :?> Button
let button7 = win.FindName("button7") :?> Button
let button8 = win.FindName("button8") :?> Button
let button9 = win.FindName("button9") :?> Button
let button10 = win.FindName("button10") :?> Button
let button11 = win.FindName("button11") :?> Button
let button12 = win.FindName("button12") :?> Button
//обработка событий
button1.Click.AddHandler(fun _ _ -> win.WindowStyle <- WindowStyle.ToolWindow)
button2.Click.AddHandler(fun _ _ -> win.WindowStyle <- WindowStyle.SingleBorderWindow)
button3.Click.AddHandler(fun _ _ -> win.WindowStyle <- WindowStyle.ThreeDBorderWindow)
button4.Click.AddHandler(fun _ _ -> win.WindowStyle <- WindowStyle.None)
button5.Click.AddHandler(fun _ _ -> win.Top <- win.Top - 10.)
button6.Click.AddHandler(fun _ _ -> win.Top <- win.Top + 10.)
button7.Click.AddHandler(fun _ _ -> win.Left <- win.Left - 10.)
button8.Click.AddHandler(fun _ _ -> win.Left <- win.Left + 10.)
button9.Click.AddHandler(fun _ _ -> let msg = sprintf "Программа предназна-чена для иллюстрации возможностей управления формой\nНажмите на любую из кнопок в меню'Варианты окна' для изменения вида формы;\nДля программного изменения положенияокна воспользуйтесь клавишами из меню: 'Положение окна';\nС помощью кнопки: 'Create NewWindow' вы можете создать новое окно;\nКнопка 'Выход' позволяет завершитьвыполнение программы." 
                                    MessageBox.Show(msg)|> ignore)
button10.Click.AddHandler(fun _ _ -> let msg = sprintf "Автор: Щербаков А.Ю. \nГруппа:1881 \nE-Mail:PrincNochi@inbox.ru"
                                     MessageBox.Show(msg)|> ignore)
button11.Click.AddHandler(fun _ _ -> win.Close())


//дочерняя форма
let nw= "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
    xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
    Title='New Window' Height='221' Width='351'>
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width='156*' />
        <ColumnDefinition Width='163' />
    </Grid.ColumnDefinitions>
    <Button Content='Площадь' Grid.Column='1' Height='23' HorizontalAlignment='
Left' Margin='76,30,0,0' Name='button1' VerticalAlignment='Top'
Width='75' IsEnabled='True' />
    <TextBox Height='23' HorizontalAlignment='Left' Margin='10,30,0,0'
Name='text' VerticalAlignment='Top' Width='246' Grid.ColumnSpan='2'
IsEnabled='True' />
    <TextBox Height='23' HorizontalAlignment='Left' Margin='20,60,0,0'
Name='textBox1' VerticalAlignment='Top' Width='216' Grid.ColumnSpan='2'
IsEnabled='True' />
    <TextBox Height='23' HorizontalAlignment='Left' Margin='20,90,0,0'
Name='textBox2' VerticalAlignment='Top' Width='216' Grid.ColumnSpan='2'
IsEnabled='True' />
    <Button Content='Close' Height='23' HorizontalAlignment='Left' Margin='
12,153,0,0' Name='button2' VerticalAlignment='Top' Width='305'
Grid.ColumnSpan='2' />
    <Label Content=' ' Grid.Column='1' Height='28' HorizontalAlignment='
Left' Margin='65,50,0,0' Name='label1' VerticalAlignment='Top' />
    </Grid>
</Window>
"
let getWindow1(nw) = 
    let xamlObj=XamlReader.Parse(nw) 
    xamlObj :?> Window
let wind = getWindow1(nw)
let nb1 = wind.FindName("button1") :?> Button
let nb2 = wind.FindName("button2") :?> Button
let nl = wind.FindName("label1") :?> Label
let ntb0 = wind.FindName("text") :?> TextBox
ntb0.Text <- "Введите значения сторон в разные боксы"
let ntb1 = wind.FindName("textBox1") :?> TextBox
let ntb2 = wind.FindName("textBox2") :?> TextBox
button12.Click.AddHandler(fun _ _ -> wind.Show()|>ignore)
nb1.Click.AddHandler(fun _ _ -> nl.Content<- "Равно:", (ntb1.GetLineText(0) |> Int32.Parse) * (ntb2.GetLineText(0) |> Int32.Parse))
nb2.Click.AddHandler(fun _ _ -> wind.Hide())
[<EntryPoint>]
[<STAThread>] 
let main argv =
    ignore <| (new Application()).Run win
    0