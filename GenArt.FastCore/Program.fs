module Program

open Util
open Models

[<EntryPoint>]
let main args =
    // let bitmap = ReadBitmapFromFile @"C:\Users\t-yoush.REDMOND\Desktop\darwin.jpg"
    // let image = ConvertBitmapToDnaImage bitmap
    let len = 12000
    let arr = Array2D.init len len (fun i j -> new DnaPoint(i, j, new DnaBrush()))

    let watch = System.Diagnostics.Stopwatch.StartNew()

    let mutable accu = 1
    for i in 0 .. (len - 1) do
        for j in 0 .. (len - 1) do
            let p = arr.[i, j]
            let x = p.X
            let y = p.Y
            accu <- accu + x + y
    watch.Stop()
    printfn "%A" watch.ElapsedMilliseconds


    let arr2 = Array.init (len * len) (fun i -> new DnaPoint(i / len, i % len, new DnaBrush()))
    let watch2 = System.Diagnostics.Stopwatch.StartNew()

    let mutable accu = 1
    for i in 0 .. (len - 1) do
        let offset = i * len
        for j in 0 .. (len - 1) do
            // let p = arr2.[offset + j]
            let x = arr2.[offset + j].X
            let y = arr2.[offset + j].Y
            accu <- accu + x - y

    watch2.Stop()
    printfn "%A" watch2.ElapsedMilliseconds
    0