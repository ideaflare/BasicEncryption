[<AutoOpen>]
module Domain

let charListToString charList : string =
    System.String(Array.ofList charList)

let stringToCharList (string : string) =
    match string with
    | null -> []
    | text -> text.ToCharArray() |> List.ofArray
