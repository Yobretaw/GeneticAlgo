module Models

open System
open System.Threading
open Random

[<Struct>]
type DnaColor =
    val A: byte
    val R: byte
    val G: byte
    val B: byte

    new (a, r, g, b) =
        { A = a; R = r; G = g; B = b }

    static member (--) (c1: DnaColor, c2: DnaColor) =
        let a = int c1.A - int c2.A
        let r = int c1.R - int c2.R
        let g = int c1.G - int c2.G
        let b = int c1.B - int c2.B

        a * a + r * r + g * g + b * b

    static member CreateRandomColor =
        let bytes = GetRandomBytes 4
        new DnaColor(bytes.[0], bytes.[1], bytes.[2], bytes.[3])

[<Struct>]
type DnaPoint =
    val X: int
    val Y: int
    val Color: DnaColor

    new (x, y, color) =
        { X = x; Y = y; Color = color; }

    static member (--) (p1: DnaPoint, p2: DnaPoint) =
        p1.Color -- p2.Color

type DnaImage(width, height, points) =
    member this.Width: int = width
    member this.Height: int = height
    member this.Points: DnaColor array = points

    static member (--) (a: DnaImage, b: DnaImage) =
        Array.mapi (fun i point -> point -- b.Points.[i]) a.Points
        |> Array.sum

type DnaPolygon = {
    Points: DnaPoint list
    PointCount: int
    Color: DnaColor
}