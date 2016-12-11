module Program

open System
open Util
open Models

[<EntryPoint>]
let main args =
    let bitmap = ReadBitmapFromFile @"C:\Users\t-yoush.REDMOND\Desktop\darwin.jpg"
    let img = ConvertBitmapToDnaImage bitmap
    let mutable error = 0
    0