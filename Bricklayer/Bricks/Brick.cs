namespace Bricklayer.Bricks;

internal abstract class Brick
{
    internal virtual int Width { get; set; }
    internal virtual int Height { get; set; }
    internal virtual int Depth { get; set; }
    internal virtual BrickColor Color { get; set; }
}
