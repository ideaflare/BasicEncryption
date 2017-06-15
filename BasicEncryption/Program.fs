// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open FileIO

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
          