module Rotation

let apply n items =
    let length = List.length items
    let split = if n = 0 || length = 0 then 0 else abs (n % length)
    let head = if n > 0 then split else length - split
    items.[head .. length - 1] @ items.[0 .. head - 1]

let undo n items =
    apply (-n) items