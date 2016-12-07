module Models

[<Struct>]
type DnaColor =
    val A: byte
    val R: byte
    val G: byte
    val B: byte

    new (a, r, g, b) =
        { A = a; R = r; G = g; B = b }

    // squared error
    static member (--) (c1: DnaColor, c2: DnaColor) =
        let a = int c1.A - int c2.A
        let r = int c1.R - int c2.R
        let g = int c1.G - int c2.G
        let b = int c1.B - int c2.B

        a * a + r * r + g * g + b * b

[<Struct>]
type DnaPoint =
    val X: int
    val Y: int
    val Color: DnaColor

    new (x, y, color) =
        { X = x; Y = y; Color = color; }

type DnaImage = {
    Width: int
    Height: int
    Points: DnaColor[,]
}

type DnaPolygon = {
    Points: DnaPoint list
    PointCount: int
    Color: DnaColor
}