module Main

open Browser.Types

open Lit

open Fable.Haunted

open Types
open Components
open Pages

Home.register ()
Notes.register ()

let App () =
    let page, setPage = Haunted.useState (Page.Home)

    let onBackRequested _ = printfn "Back requested"

    let goToPage page _ = setPage page

    let getPage page =
        match page with
        | Page.Home -> html $"""<flit-home></flit-home>"""
        | Page.Notes -> html $"""<flit-notes></flit-notes>"""

    html
        $"""
        <article>
            {Navbar.View onBackRequested goToPage}
            <main id="content">{getPage page}</main>
        </article>
        """

defineComponent "flit-app" (Haunted.Component App)
