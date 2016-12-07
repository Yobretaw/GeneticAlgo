module Util

open System
open System.Drawing
open Models

let ReadBitmapFromFile (path: string) = new Bitmap(path)

let ConvertBitmapToImage (bitmap: Bitmap) =
    let width = bitmap.Width
    let height = bitmap.Height

    let image = {
        Width = width;
        Height = height;
        Points = Array2D.init width height (fun i j -> new DnaPoint())
    }

    for i in 0 .. (width - 1) do
        for j in 0 .. (height - 1) do
            let c = bitmap.GetPixel(i, j)
            let color = new DnaColor(c.R, c.G, c.B)
            let point = new DnaPoint(i, j, color)
            image.Points.[i, j] <- point

    image