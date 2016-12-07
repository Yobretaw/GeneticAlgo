module Util

open System
open System.Drawing
open Models

let ReadBitmapFromFile (path: string) = new Bitmap(path)

let ColorToDnaBrush (color: Color) =
    new DnaBrush(color.A, color.R, color.G, color.B)

let DnaBrushToColor (brush: DnaBrush) =
    let a = (int)brush.A
    let r = (int)brush.R
    let g = (int)brush.G
    let b = (int)brush.B
    Color.FromArgb(a, r, g, b)

let ConvertBitmapToDnaImage (bitmap: Bitmap) =
    let width = bitmap.Width
    let height = bitmap.Height

    let image = {
        Width = width;
        Height = height;
        Points = Array2D.init width height (fun i j -> new DnaBrush())
    }

    for i in 0 .. (width - 1) do
        for j in 0 .. (height - 1) do
            let color = bitmap.GetPixel(i, j)
            image.Points.[i, j] <- ColorToDnaBrush(color)
    image

let ConvertDnaImageToBitmap (img: DnaImage) =
    let width = img.Width
    let height = img.Height
    let bitmap = new Bitmap(width, height)

    for i in 0 .. (width - 1) do
        for j in 0 .. (height - 1) do
            let brush = img.Points.[i, j]
            bitmap.SetPixel(i, j, DnaBrushToColor(brush))
    bitmap