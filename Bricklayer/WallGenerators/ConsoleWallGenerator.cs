namespace Bricklayer.WallGenerators;

internal class ConsoleWallGenerator : IWallGenerator
{
    private readonly RowBricks[] wall;

    public ConsoleWallGenerator(RowBricks[] wall)
    {
        this.wall = wall;
    }

    public void Generate()
    {

        // print the wall
        for (int rowN = wall.Length - 1; rowN >= 0; rowN--)
        {
            var row = wall[rowN];
            Console.Write($"Row {row.RowNumber} ");
            foreach (var brick in row.Bricks)
            {
                if (brick.Color == Color.Grey)
                {
                    GreyConsole();
                }
                else
                {
                    DarkRedConsole();
                }
                if (brick.Width / 10 == 1)
                {
                    RedConsole();
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.ResetColor();
            }
            Console.Write(Environment.NewLine);
        }
    }

    private static void RedConsole()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.Red;
    }

    private static void DarkRedConsole()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.BackgroundColor = ConsoleColor.DarkRed;
    }

    private static void GreyConsole()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.BackgroundColor = ConsoleColor.Gray;
    }
}
