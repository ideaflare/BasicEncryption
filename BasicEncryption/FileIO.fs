module FileIO

// F# 4.1 not yet on mono/fhsarp? so:
type ResultTemp<'a> =
    | Ok of 'a
    | FileNotFound of string
    | UnexpectedError of exn

let tryReadAllText filePath =
    try
        let text = System.IO.File.ReadAllText(filePath)
        Ok text
    with
        | :? System.IO.FileNotFoundException ->
            FileNotFound filePath
        | e -> UnexpectedError e