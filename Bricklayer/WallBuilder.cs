namespace Bricklayer;

internal class WallBuilder
{
    private readonly GreyPattern greyPattern;
    private int totalWidth = 180;
    private int totalHeight = 90;

    private Brick NewRedCubicBrick() => new RedCubicBrick
    {
        Size = 10,
        Color = Color.Red
    };

    private Brick NewRedParallelepipedBrick() => new RedParallelepipedBrick
    {
        Width = 20
    };

    private Brick NewGreyParallelepipedBrick() => new GreyParallelepipedBrick
    {
        Width = 20
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

        Brick currentBrick = NewRedParallelepipedBrick();
        while (builtWidth < totalWidth)
        {
            bool lastCol = builtWidth + currentBrick.Width >= totalWidth;

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
        Brick currentBrick = NewRedParallelepipedBrick();
        if (greyPattern.IsContainingBrick(currentColNumber, currentRowNumber))
        {
            currentBrick = NewGreyParallelepipedBrick();
        }

        bool evenRow = currentRowNumber % 2 == 0;
        bool firstCol = currentColNumber == 1;

        if (evenRow)
        {
            if (firstCol || lastCol)
            {
                currentBrick = NewRedCubicBrick();
            }
        }

        return currentBrick;
    }
}
