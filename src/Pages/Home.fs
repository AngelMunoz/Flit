module Pages.Home

open Elmish
open Elmish.Lit
open Lit

type private State = { counter: int }

type private Msg =
    | Increment
    | Decrement

let private init _ = { counter = 0 }

let private update msg state =
    match msg with
    | Increment ->
        { state with
              counter = state.counter + 1 }
    | Decrement ->
        { state with
              counter = state.counter - 1 }


let private view state dispatch =
    html
        $"""
        <p>Home: {state.counter}</p>
        <button @click={fun _ -> dispatch Increment}>Increment</button>
        <button @click={fun _ -> dispatch Decrement}>Decrement</button>
        """

let Page () =
    Program.mkSimple init update view
    |> Program.withLit "content"
    |> Program.run
