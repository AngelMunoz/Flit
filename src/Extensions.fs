[<AutoOpen>]
module Extensions


open Fable.Core
open Fable.Core.JsInterop
open Lit

[<Emit("new Event($0, $1)")>]
let createEvent (name: string) (opts: obj) = jsNative

[<Emit("new CustomEvent($0, $1)")>]
let createCustomEvent (name: string) (opts: obj) = jsNative

let repeat<'T> (items: 'T seq) (renderer: 'T -> int -> TemplateResult) : TemplateResult =
    importMember "lit-html/directives/repeat.js"
