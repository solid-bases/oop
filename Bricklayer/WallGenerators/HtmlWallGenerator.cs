using System.Text;

using Bricklayer.Bricks;
using Bricklayer.Builder;

namespace Bricklayer.WallGenerators;

internal class HtmlWallGenerator : IWallGenerator
{
    private readonly RowBricks[] wall;

    public HtmlWallGenerator(RowBricks[] wall)
    {
        this.wall = wall;
    }

    public void Generate()
    {
        var builder = new StringBuilder();
        builder.Append("<html><body style='font-family: monospace;'>");
        for (int rowN = wall.Length - 1; rowN >= 0; rowN--)
        {
            var row = wall[rowN];
            builder.Append($"Row {row.RowNumber} ");
            foreach (var brick in row.Bricks)
            {
                if (brick.Color == BrickColor.Grey)
                {
                    builder.Append("<span style='color: grey; background-color: grey;'>");
                }
                else
                {
                    builder.Append("<span style='color: darkred; background-color: darkred;'>");
                }

                if (brick.Width / 10 == 1)
                {
                    builder.Append("=</span>");
                }
                else
                {
                    builder.Append("==</span>");
                }
            }
            builder.Append("<br/>");
        }
        builder.Append("</body></html>");
        File.WriteAllText("wall.html", builder.ToString());

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Environment.NewLine}wall.html file has been generated.");
        Console.ResetColor();
    }
}