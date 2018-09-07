namespace Samples

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Html
open WebSharper.UI.Client
open WebSharper.UI.Notation
open WebSharper.SweetAlert

[<JavaScript>]
module HelloWorld =

    [<SPAEntryPoint>]
    let Main () =
        let WelcomeBox = 
            Box (
                    TitleText = "Welcome!",
                    Text = "Welcome to my snippet! Here you will witness various features of SweetAlert",
                    Type = "success"
                )
        let WarningBox =
            Box (
                    TitleText = "Warning!",
                    Text = "This is a warning type box, with a cancel button",
                    Type = "warning",
                    AllowOutsideClick = false,
                    ShowCancelButton = true
                )
        let ErrorBox =
            Box(
                    TitleText = "Error!",
                    Text = "This is an error type box, with custom button color",
                    Type = "error",
                    ConfirmButtonColor = "#BB0000"
                )
        let InfoBox =
            Box(
                    TitleText = "Information",
                    Text = "This is an info type box, with a custon background color",
                    Type = "info",
                    Background = "#dff"
                )
        let QuestionBox =
            Box(
                    TitleText = "Question Box",
                    Text = "Type something into the input field, and let's see what happens!",
                    Type = "question",
                    Input = "text",
                    ConfirmButtonText = "Send"
                )
        SweetAlert.ShowBox WelcomeBox |> ignore
        let WarningButton =
            Doc.Button "Warning" [] (fun () ->
                    SweetAlert.ShowBox WarningBox |> ignore
                )
        let ErrorButton =
            Doc.Button "Error" [] (fun () ->
                    SweetAlert.ShowBox ErrorBox |> ignore
                )
        let InfoButton =
                Doc.Button "Info" [] (fun () ->
                    SweetAlert.ShowBox InfoBox |> ignore
                )
        let rResult = Var.Create ""
        let QuestionButton =
            Doc.Button "Click me!" [] (fun () ->
                    SweetAlert.ShowBox(QuestionBox).Then(fun (input: string) ->
                        SweetAlert.ShowBox(new Box(TitleText = "Result", Text = "You wrote: " + input,Type = "info")) |> ignore) |> ignore
                )
        Doc.Concat[
                h1 [] [text "WebSharper.SweetAlert"]
                p [] [text "You have already seen the success box, now let's have a look at the other basic box types:"]
                ul [] [
                    li [] [ WarningButton ]
                    li [] [ ErrorButton ]
                    li [] [ InfoButton ]
                ]
                p [] [text "Now, let's see the question type button, with a much more interesting example:"]
                br [] []
                QuestionButton
            ]|> Doc.RunById "main"