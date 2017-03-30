[<AutoOpen>]
module Domain

let stringFromCharList charList : string =
    System.String(Array.ofList charList)

let charList (string : string) =
    match string with
    | null -> []
    | text -> text.ToCharArray() |> List.ofArray