namespace Bricklayer.Bricks;

//internal class RedParallelepipedBrick : ParallelepipedBrick, RedBrick {}
// Multiple inheritance not possible, bypassed with Inheritance + Delegation:
internal class RedParallelepipedBrick : ParallelepipedBrick
{
    public RedParallelepipedBrick() : base(new RedBrick())
    {
    }
}
