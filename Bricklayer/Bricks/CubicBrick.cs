namespace Bricklayer.Bricks;

internal class CubicBrick : Brick
{
    private int size;
    internal int Size { get => size; set => size = value; }
    internal override int Width { get => size; set => size = value; }
    internal override int Height { get => size; set => size = value; }
    internal override int Depth { get => size; set => size = value; }
}
