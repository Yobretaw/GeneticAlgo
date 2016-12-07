module Program

open Util
open Models

[<EntryPoint>]
let main args =
    let bitmap = ReadBitmapFromFile @"C:\Users\t-yoush.REDMOND\Desktop\darwin.jpg"
    let image = ConvertBitmapToImage bitmap
    0