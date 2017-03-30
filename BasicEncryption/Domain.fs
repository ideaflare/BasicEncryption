[<AutoOpen>]
module Domain

let charListToString charList : string =
    System.String(Array.ofList charList)

type Text = Text of char list

let charList = function
    | Text chars -> chars

let emptyText = Text []

let safeString (nullableString: string) =
    match nullableString with
    | null -> emptyText
    | str -> str.ToCharArray() 
             |> List.ofArray
             |> Text

let stringValue = function
    | Text chars -> charListToString chars