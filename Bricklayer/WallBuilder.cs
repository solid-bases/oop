namespace Bricklayer;

internal class WallBuilder
{
    private readonly GreyPattern greyPattern;
    private int totalWidth = 180;
    private int totalHeight = 90;

    private Brick cubicRedBrick = new Brick
    {
        Width = 10,
        Height = 10,
        Depth = 10,
        Color = Color.Red
    };

    private Brick parallelepipedRedBrick = new Brick
    {
        Width = 20,
        Height = 10,
        Depth = 10,
        Color = Color.Red
    };

    private Brick parallelepipedGreyBrick = new Brick
    {
        Width = 20,
        Height = 10,
        Depth = 10,
        Color = Color.Grey
    };

    public WallBuilder(GreyPattern greyPattern)
    {
        this.greyPattern = greyPattern;
    }

    public RowBricks[] BuildWall()
    {
        RowBricks[] wall = new RowBricks[1];

        int builtHeight = 0;
        int currentRowNumber = 1;

        // built the wall
        while (builtHeight < totalHeight)
        {
            var currentRow = NewBricksRow(currentRowNumber);

            wall[currentRowNumber - 1] = new RowBricks
            {
                RowNumber = currentRowNumber,
                Bricks = currentRow
            };

            currentRowNumber++;
            builtHeight += currentRow[0].Height;
            if (builtHeight < totalHeight)
            {
                Array.Resize<RowBricks>(ref wall, currentRowNumber);
            }
        }

        return wall;
    }

    private Brick[] NewBricksRow(int currentRowNumber)
    {
        Brick[] currentRow = new Brick[1];

        int builtWidth = 0;
        int currentColNumber = 1;

        Brick currentBrick = parallelepipedRedBrick;
        while (builtWidth < totalWidth)
        {
            bool lastCol = builtWidth + parallelepipedRedBrick.Width >= totalWidth;

            currentBrick = PlaceBrickInRow(currentColNumber, currentRowNumber, lastCol);
            currentRow[currentColNumber - 1] = currentBrick;

            builtWidth += currentBrick.Width;
            currentColNumber++;
            if (!lastCol)
            {
                Array.Resize<Brick>(ref currentRow, currentColNumber);
            }
        }
        return currentRow;
    }

    private Brick PlaceBrickInRow(int currentColNumber, int currentRowNumber, bool lastCol)
    {
        Brick currentBrick = parallelepipedRedBrick;
        if (greyPattern.IsContainingBrick(currentColNumber, currentRowNumber))
        {
            currentBrick = parallelepipedGreyBrick;
        }

        bool evenRow = currentRowNumber % 2 == 0;
        bool firstCol = currentColNumber == 1;

        if (evenRow)
        {
            if (firstCol || lastCol)
            {
                currentBrick = cubicRedBrick;
            }
        }

        return currentBrick;
    }
}
