module Pages.Notes

open Elmish
open Elmish.Lit
open Browser.Types
open Lit

type private Note =
    { Id: int
      Title: string
      Body: string }

type private State =
    { CurrentNote: Note option
      Notes: Note list }

type private Msg =
    | Add of Note
    | Remove of Note
    | SetTitle of string
    | SetBody of string
    | Save

let private init _ =
    { CurrentNote = None; Notes = [] }, Cmd.none

let private update msg state =
    match msg with
    | Add note ->
        { state with
              Notes =
                  { note with
                        Id = state.Notes.Length + 1 }
                  :: state.Notes },
        Cmd.none
    | Remove note ->
        { state with
              Notes = state.Notes |> List.filter (fun n -> n <> note) },
        Cmd.none
    | SetTitle title ->
        let current =
            state.CurrentNote
            |> Option.map (fun current -> { current with Title = title })
            |> Option.orElse (Some { Id = 0; Title = ""; Body = "" })

        { state with CurrentNote = current }, Cmd.none
    | SetBody title ->
        let current =
            state.CurrentNote
            |> Option.map (fun current -> { current with Title = title })
            |> Option.orElse (Some { Id = 0; Title = ""; Body = "" })

        { state with CurrentNote = current }, Cmd.none
    | Save ->
        match state.CurrentNote
              |> Option.map
                  (fun note ->
                      { note with
                            Id = (state.Notes |> Seq.length) + 1 }) with
        | Some note -> state, Cmd.ofMsg (Add note)
        | None -> state, Cmd.none




let private noteTemplate note index =
    html
        $"""
        <li>{note.Id} - {note.Title}</li>
    """

let private view state dispatch =
    html
        $"""
        <form @submit="{fun (ev: Event) ->
                            ev.preventDefault ()
                            dispatch Save}">
            <input
                type="text"
                name="title"
                placeholder="Title"
                @keyup="{fun (evt: KeyboardEvent) ->
                             SetTitle (evt.target :?> HTMLInputElement).value
                             |> dispatch}" />
            <input
                type="text"
                name="body"
                placeholder="Body"
                @keyup="{fun (evt: KeyboardEvent) ->
                             SetBody (evt.target :?> HTMLInputElement).value
                             |> dispatch}" />
            <button type="submit">Add</button>
        </form>
        <ul>{repeat state.Notes noteTemplate}</ul>
        """


let Page () =

    Program.mkProgram init update view
    |> Program.withLit "content"
    |> Program.run
