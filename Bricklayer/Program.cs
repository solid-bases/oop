using Bricklayer.Builder;
using Bricklayer.WallGenerators;

namespace Bricklayer;

internal partial class Program
{
    private static void Main(string[] args)
    {
        GreyPattern greyPattern = new GreyPattern(new[] {
            new RowPattern {
                RowNumber = 3,
                ColumnsNumber = new[] { 5 }
            },
            new RowPattern {
                RowNumber = 4,
                ColumnsNumber = new[] { 5,6 }
            },
            new RowPattern {
                RowNumber = 5,
                ColumnsNumber = new[] { 4,6 }
            },
            new RowPattern {
                RowNumber = 6,
                ColumnsNumber = new[] { 5,6 }
            },
            new RowPattern {
                RowNumber = 7,
                ColumnsNumber = new[] { 5 }
            },
        });

        WallBuilder builder = new(greyPattern);
        RowBricks[] wall = builder.BuildWall();

        IWallGenerator printer = WallGeneratorFactory.NewGenerator(wall);
        printer.Generate();

    }


}
