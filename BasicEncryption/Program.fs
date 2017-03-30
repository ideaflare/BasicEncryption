// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

let usage () =
    printfn "No file specified."
    printfn "Usage: BasicEncryption.exe fileName"

let encrypt text =
    let rec jumble n text =
        let transposed = TextTransposition.transpose 3 text
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
        try
            let stringText = System.IO.File.ReadAllText(filePath)
            encrypt stringText
        with
            | :? System.IO.FileNotFoundException -> printfn "Couldn't find file %s" filePath
            | e -> printfn "Error reading text: %A" e

    0 // return an integer exit code
          