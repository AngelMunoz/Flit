module Main

open Browser.Types
open Elmish
open Elmish.Lit
open Lit

open Types
open Components
open Pages

type State = { NavStack: Page list }

type Msg =
    | GoTo of Page
    | GoBack

let private init _ = { NavStack = [ Home ] }

let private update msg state =
    match msg with
    | GoTo page ->
        { state with
              NavStack = page :: state.NavStack }
    | GoBack ->
        if state.NavStack.Length > 1 then
            { state with
                  NavStack = state.NavStack.Tail }
        else
            state


let private getPage state =
    Fable.Core.JS.setTimeout
        (fun _ ->
            match state.NavStack |> List.tryHead with
            | Some Home -> Home.Page()
            | Some Notes -> Notes.Page()
            | None -> Home.Page())
        0

let private onGoTo dispatch (evt: CustomEvent<Page>) =
    match evt.detail with
    | Some page -> GoTo page |> dispatch
    | None -> ()

let view state dispatch =

    html
        $"""
        <article
            @on-back-requested="{fun _ -> dispatch GoBack}"
            @on-go-to="{onGoTo dispatch}">
            {Navbar.View()}
            <main id="content">{getPage state}</main>
        </article>
        """


Program.mkSimple init update view
|> Program.withLit "fable-lit"
|> Program.run
