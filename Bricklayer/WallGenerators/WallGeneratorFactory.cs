namespace Bricklayer.WallGenerators;

internal class WallGeneratorFactory
{

    public static IWallGenerator NewGenerator(RowBricks[] wall)
    {
        if (DateTime.Now.Minute % 2 == 1)
        {
            return new ConsoleWallGenerator(wall);
        }
        return new HtmlWallGenerator(wall);
    }
}