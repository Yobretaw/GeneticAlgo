module Models

type DnaBrush =
    struct
        val A: byte
        val R: byte
        val G: byte
        val B: byte

        new (a, r, g, b) =
            { A = a; R = r; G = g; B = b; }
    end

type DnaPoint =
    struct
        val X: int
        val Y: int
        val Brush: DnaBrush

        new (x, y, brush) =
            { X = x; Y = y; Brush = brush; }
    end

type DnaImage = {
    Width: int
    Height: int
    Points: DnaBrush[,]
}

type DnaPolygon = {
    Points: DnaPoint array
    Brush: DnaBrush
}