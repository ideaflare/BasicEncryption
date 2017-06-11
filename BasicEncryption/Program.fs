// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

// F# 4.1 not yet on mono/fhsarp? so:
type ResultTemp<'a> =
    | Ok of 'a
    | Error of string

let usage () =
    printfn "No file specified."
    printfn "Usage: BasicEncryption.exe fileName"

let encrypt text =
    let rec jumble n text =
        let transposed = TextOperations.transpose 3 text
        match n with
        | 0 -> transposed
        | n -> jumble (n - 1) transposed
    let cypher = jumble 7 text
    printfn "\nencrypted text:\n\n%s" cypher

let tryReadAllText filePath =
    try
        let text = System.IO.File.ReadAllText(filePath)
        Ok text
    with
        | :? System.IO.FileNotFoundException ->
            Error (sprintf "Couldn't find file %s" filePath)
        | e -> 
            Error (sprintf "Error reading text: %A" e)

[<EntryPoint>]
let main argv = 

    let maybeFilePath = argv |> List.ofArray |> List.tryHead

    match maybeFilePath with
    | None -> usage ()
    | Some(filePath) ->
        match tryReadAllText filePath with
        | Ok(text) -> encrypt text
        | Error msg -> printfn "Error reading text: %s" msg        

    0 // return an integer exit code
          