module KeyMap

let initialKeyMap =
    charList """\n\t `-=~!@#$%^&*()_+[]{}|\;':",./<>?"""
    @ ['0' .. '9']
    @ ['a' .. 'z']
    @ ['A' .. 'Z']

let buildKeyMap (input : char list) =
    let rnd = System.Random()
    initialKeyMap @ input
    |> List.distinct
    |> List.sortBy ( fun _ -> rnd.Next())

let splitPrependedKeyMap items =
    let uniqueItems = items |> List.distinct |> List.length
    let keyMap = items |> List.take uniqueItems
    let tail   = items |> List.skip uniqueItems
    keyMap, tail

let secretNumbers password keymap =
    let keymapIndex letter = keymap |> List.findIndex ((=) letter)
    password
    |> List.map keymapIndex