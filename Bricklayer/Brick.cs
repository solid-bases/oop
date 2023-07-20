namespace Bricklayer;

internal abstract class Brick
{
    internal virtual int Width { get; set; }
    internal virtual int Height { get; set; }
    internal virtual int Depth { get; set; }
    internal virtual Color Color { get; set; }
}

internal class GreyBrick : Brick
{
    internal override Color Color { get => Color.Grey; }
}

internal class RedBrick : Brick
{
    internal override Color Color { get => Color.Red; }
}

internal class CubicBrick : Brick
{
    private int size;
    internal int Size { get => size; set => size = value; }
    internal override int Width { get => size; set => size = value; }
    internal override int Height { get => size; set => size = value; }
    internal override int Depth { get => size; set => size = value; }
}

internal class RedCubicBrick : CubicBrick
{
    internal override Color Color { get => Color.Red; }
}

internal class GreyCubicBrick : CubicBrick
{
    internal override Color Color { get => Color.Grey; }
}

internal class ParallelepipedBrick : Brick
{
    internal override int Width { get => base.Width; set => SetSizesFromLongEdge(value); }
    internal override int Height { get => base.Height; set => SetSizesFromShortEdge(value); }
    internal override int Depth { get => base.Depth; set => SetSizesFromShortEdge(value); }
    internal override Color Color { get => brickColor.Color; set => brickColor.Color = value; }

    private Brick brickColor;
    public ParallelepipedBrick(Brick brickColor)
    {
        this.brickColor = brickColor;
    }

    private void SetSizesFromLongEdge(int value)
    {
        base.Height = base.Depth = value / 2;
        base.Width = value;
    }

    private void SetSizesFromShortEdge(int value)
    {
        base.Width = value * 2;
        base.Height = base.Depth = value;
    }
}

//internal class RedParallelepipedBrick : ParallelepipedBrick, RedBrick {}
// Multiple inheritance not possible, bypassed with Inheritance + Delegation:
internal class RedParallelepipedBrick : ParallelepipedBrick
{
    public RedParallelepipedBrick() : base(new RedBrick())
    {
    }
}

// Composition + Delegation
internal class GreyParallelepipedBrick : Brick
{
    private ParallelepipedBrick parallelepipedBrick = new ParallelepipedBrick(new GreyBrick());
    public GreyParallelepipedBrick()
    {
    }

    // Forwarding
    internal override int Width { get => parallelepipedBrick.Width; set => parallelepipedBrick.Width = value; }
    internal override int Height { get => parallelepipedBrick.Height; set => parallelepipedBrick.Height = value; }
    internal override int Depth { get => parallelepipedBrick.Depth; set => parallelepipedBrick.Depth = value; }
    internal override Color Color { get => parallelepipedBrick.Color; set => parallelepipedBrick.Color = value; }
}
