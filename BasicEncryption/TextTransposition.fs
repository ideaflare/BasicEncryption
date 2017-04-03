module TextTransposition

let transpose size (body : string) =
    charList body
    |> Transposition.transpose size
    |> stringFromCharList

let undo size (cypher : string) =
    charList cypher
    |> Transposition.undo size
    |> stringFromCharList