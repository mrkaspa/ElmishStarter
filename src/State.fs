module App.State

open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import.Browser
open App.Global
open App.Types

let pageParser : Parser<Page -> Page, Page> =
    oneOf [ map About (s "about")
            map Counter (s "counter")
            map Home (s "home") ]

let urlUpdate result model =
    match result with
    | Some page -> ({ model with currentPage = page }, [])
    | None ->
        console.error ("Error parsing url")
        (model, Navigation.modifyUrl (toHash model.currentPage))

let init result =
    let (model, cmd) = urlUpdate result { currentPage = Home }
    (model, cmd)

let update msg model = (model, [])
