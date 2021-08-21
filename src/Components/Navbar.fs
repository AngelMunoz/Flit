module Components.Navbar

open Browser.Types
open Fable.Core
open Lit
open Types
open Extensions

let View () =
    let onBackRequested (event: PointerEvent) =
        let evt =
            createEvent "on-back-requested" {| bubbles = true; cancelable = true |}

        event.target.dispatchEvent evt |> ignore

    let goToPage (page: Page) (event: PointerEvent) =
        let evt =
            createCustomEvent
                "on-go-to"
                {| bubbles = true
                   cancelable = true
                   detail = page |}

        event.target.dispatchEvent evt |> ignore


    html
        $"""
        <nav>
            <button @click="{onBackRequested}">Go Back</button>
            <button @click="{goToPage Home}">Home</button>
            <button @click="{goToPage Notes}">notes</button>
        </nav>
        """
