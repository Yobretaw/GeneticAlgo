module Program

open System
open Util
open Models

[<EntryPoint>]
let main args =
    let bitmap = ReadBitmapFromFile @"C:\Users\t-yoush.REDMOND\Desktop\darwin.jpg"
    let img = ConvertBitmapToDnaImage bitmap
    let mutable error = 0
    let watch = System.Diagnostics.Stopwatch.StartNew()
    watch.Start
    for i = 0 to 1000 do
        let img2 = img.Mutate
        error <- error + DnaImage.CalculateFitness(img, img2)
    watch.Stop
    printfn "%A" watch.ElapsedMilliseconds
    0