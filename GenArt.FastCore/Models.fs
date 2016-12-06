namespace GenArt.FastCore.Models

type Brush =
    struct
        val R: int
        val G: int
        val B: int
        val Alpha: int

        new (r, g, b, alpha) =
            { R = r; G = g; B = b; Alpha = alpha; }
    end

type Color =
    struct
        val R: int
        val G: int
        val B: int

        new (r, g, b) =
            { R = r; G = g; B = b; }
    end

type Point =
    struct
        val X: int
        val Y: int
        val Color: Color

        new (x, y, color) =
            { X = x; Y = y; Color = color; }
    end

type Image = {
    Width: int
    Height: int
    Points: Point array
}

type Polygon = {
    Points: Point array
    Brush: Brush
}