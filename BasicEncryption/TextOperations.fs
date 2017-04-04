module TextOperations

let transpose size (body : string) =
    charList body
    |> Transposition.apply size
    |> stringFromCharList

let undoTranspose size (cypher : string) =
    charList cypher
    |> Transposition.undo size
    |> stringFromCharList