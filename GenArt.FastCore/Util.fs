module Util

open System
open System.Drawing
open Models

let ReadBitmapFromFile (path: string) = new Bitmap(path)

let ColorFromBitmap (bitmap: Bitmap) x y =
    let c = bitmap.GetPixel(x, y)
    new DnaColor(c.A, c.R, c.G, c.B)

let ConvertBitmapToDnaImage (bitmap: Bitmap) =
    let width = bitmap.Width
    let height = bitmap.Height
    let points = Array.init (width * height) (fun i -> ColorFromBitmap bitmap (i / width) (i % width))
    let image = new DnaImage(width, height, points)
    image

let ConvertDnaImageToBitmap (img: DnaImage) =
    let width = img.Width
    let height = img.Height
    let bitmap = new Bitmap(width, height)

    for i in 0 .. (width - 1) do
        for j in 0 .. (height - 1) do
            let c = img.Points.[i * width + j]
            bitmap.SetPixel(i, j, Color.FromArgb((int)c.A, (int)c.R, (int)c.G, (int)c.B))
    bitmap