module Models

type DnaBrush =
    struct
        val R: byte
        val G: byte
        val B: byte
        val Alpha: byte

        new (r, g, b, alpha) =
            { R = r; G = g; B = b; Alpha = alpha; }
    end

type DnaColor =
    struct
        val R: byte
        val G: byte
        val B: byte

        new (r, g, b) =
            { R = r; G = g; B = b; }
    end

type DnaPoint =
    struct
        val X: int
        val Y: int
        val Color: DnaColor

        new (x, y, color) =
            { X = x; Y = y; Color = color; }
    end

type DnaImage = {
    Width: int
    Height: int
    Points: DnaPoint[,]
}

type DnaPolygon = {
    Points: DnaPoint array
    Brush: DnaBrush
}