module TextTransposition

let transpose size (body : string) =
    charList body
    |> Transposition.transpose size
    |> stringFromCharList