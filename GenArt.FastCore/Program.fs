module Program

open System
open Util
open Models

[<EntryPoint>]
let main args =
    // let bitmap = ReadBitmapFromFile @"C:\Users\t-yoush.REDMOND\Desktop\darwin.jpg"
    // let image = ConvertBitmapToDnaImage bitmap
    let c = new DnaColor(1uy, 1uy, 1uy, 1uy)
    let d = new DnaColor(1uy, 1uy, 1uy, 2uy)

    let e = d -- c

    for i = 0 to 255 do
        let c = DnaColor.CreateRandomColor
        printfn "%A, %A, %A, %A" c.A c.R c.G c.B

    0