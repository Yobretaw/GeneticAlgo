module Models

open System
open System.Threading
open Random
open GenArt.Classes

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

    member this.Mutate =
        let a = match Random.Next(Settings.ActiveAlphaMutationRate) with
                | 0 -> GetRandomByte
                | _ -> this.A

        let r = match Random.Next(Settings.ActiveRedMutationRate) with
                | 0 -> GetRandomByte
                | _ -> this.R

        let g = match Random.Next(Settings.ActiveGreenRangeMax) with
                | 0 -> GetRandomByte
                | _ -> this.G

        let b = match Random.Next(Settings.ActiveBlueMutationRate) with
                | 0 -> GetRandomByte
                | _ -> this.B

        new DnaColor(a, r, g, b)

[<Struct>]
type DnaPoint =
    val X: int
    val Y: int
    val Color: DnaColor

    new (x, y, color) =
        { X = x; Y = y; Color = color; }

    static member (--) (p1: DnaPoint, p2: DnaPoint) =
        p1.Color -- p2.Color

    static member CreateRandomPoint(x, y, color) = new DnaPoint(x, y, color)

type DnaPolygon(points, count, color) =
    member this.Points: DnaPoint list = points
    member this.PointCount: int = count
    member this.Color: DnaColor = color

    member this.AddPoint() = null
    member this.RemovePoint() = null
    member this.MovePoint() = null

type DnaImage(width, height, points) =
    member this.Width: int = width
    member this.Height: int = height
    member this.Points: DnaColor array = points

    static member (--) (a: DnaImage, b: DnaImage) =
        Array.mapi (fun i point -> point -- b.Points.[i]) a.Points
        |> Array.sum

    static member CalculateFitness (img1: DnaImage, polygon: DnaPolygon) =
        0