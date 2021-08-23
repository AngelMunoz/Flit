[<RequireQualifiedAccess>]
module Pages.Engine

open Feliz.Lit
open Fable.Haunted

let engine () =
    Html.div [ Html.h1 "Feliz"
               Html.h2 "Engine!" ]
    |> toLit


let register () =
    defineComponent "flit-using-engine" (Haunted.Component engine)
