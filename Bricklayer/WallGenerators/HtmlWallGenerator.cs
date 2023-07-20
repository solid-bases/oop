using System.Text;

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
                if (brick.Color == Color.Grey)
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
    }
}