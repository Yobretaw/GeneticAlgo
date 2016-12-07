module Program

open Util
open Models

[<EntryPoint>]
let main args =
    // let bitmap = ReadBitmapFromFile @"C:\Users\t-yoush.REDMOND\Desktop\darwin.jpg"
    // let image = ConvertBitmapToDnaImage bitmap
    let c = new DnaColor(1uy, 1uy, 1uy, 1uy)
    let d = new DnaColor(1uy, 1uy, 1uy, 2uy)

    let e = d -- c

    let a = 255uy
    let b = 1uy
    let c = a + b
    0