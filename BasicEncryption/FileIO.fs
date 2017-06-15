module FileIO

// F# 4.1 not yet on mono/fhsarp? so:
type ResultTemp<'a> =
    | Ok of 'a
    | Error of string

let tryReadAllText filePath =
    try
        let text = System.IO.File.ReadAllText(filePath)
        Ok text
    with
        | :? System.IO.FileNotFoundException ->
            Error (sprintf "Couldn't find file %s" filePath)
        | e -> 
            Error (sprintf "Error reading text: %A" e)