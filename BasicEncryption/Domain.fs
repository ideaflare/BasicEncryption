[<AutoOpen>]
module Domain

type CharList =
    | SafeString of char list

let charList = function
    | SafeString chars -> chars

let emptyString = SafeString []

let safeString (unsafeString: string) =
    match unsafeString with
    | null -> emptyString
    | str -> str.ToCharArray() 
             |> List.ofArray
             |> SafeString