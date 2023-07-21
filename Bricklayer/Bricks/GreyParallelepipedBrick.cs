namespace Bricklayer.Bricks;

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
    internal override BrickColor Color { get => parallelepipedBrick.Color; set => parallelepipedBrick.Color = value; }
}
