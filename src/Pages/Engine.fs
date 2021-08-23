[<RequireQualifiedAccess>]
module Pages.Engine

open Feliz.Lit
open Fable.Haunted

let engine () =
  let state, setState = Haunted.useState (0)

  Html.div [
    Html.h3 "Feliz Engine Counter!"
    Html.p $"Engine Counter: {state}"
    Html.button [
      Ev.onClick (fun _ -> setState (state + 1))
      Html.text "Increment"
    ]
    Html.button [
      Ev.onClick (fun _ -> setState (state - 1))
      Html.text "Decrement"
    ]
    Html.button [
      Ev.onClick (fun _ -> setState (0))
      Html.text "Reset"
    ]
  ]
  |> toLit


let register () =
  defineComponent "flit-using-engine" (Haunted.Component engine)
