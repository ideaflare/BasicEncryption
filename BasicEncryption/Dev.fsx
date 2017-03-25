type File = System.IO.File
let filePath = """C:\MyTemp\findme.txt"""
let text = File.ReadAllText(filePath)

printfn "size: %i content: %A" text.Length text

//let rowTransposition (text:string) columns =

let transposeRow columns col (body:string) = 
    let bodyWithIndex = List.init body.Length (fun i -> (i, body.[i]))   
    bodyWithIndex 
    |> List.filter (fun (index, x) -> index % columns = col)
    |> List.map (fun (index, x) -> x)
    |> Array.ofList |> (fun arr -> System.String(arr))

let rowTransposition columns text =
    let getCol = transposeRow columns
    [0..(columns - 1)]
    |> List.map (fun c -> getCol c text)
    


rowTransposition 3 text