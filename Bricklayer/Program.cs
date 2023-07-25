namespace Bricklayer;

internal static class Program
{
    enum Color
    {
        Red,
        Grey
    }

    struct Brick
    {
        public int Width;
        public int Height;
        public int Depth;
        public Color Color;
    }

    struct RowPattern
    {
        public int RowNumber;
        public int[] ColumnsNumber;
    }

    struct RowBricks
    {
        public int RowNumber;
        public Brick[] Bricks;
    }

    private static void Main(string[] args)
    {
        int totalWidth = 180;
        int totalHeight = 90;

        Brick cubicRedBrick = new Brick
        {
            Width = 10,
            Height = 10,
            Depth = 10,
            Color = Color.Red
        };

        Brick parallelepipedRedBrick = new Brick
        {
            Width = 20,
            Height = 10,
            Depth = 10,
            Color = Color.Red
        };

        Brick parallelepipedGreyBrick = new Brick
        {
            Width = 20,
            Height = 10,
            Depth = 10,
            Color = Color.Grey
        };

        RowPattern[] greyRhombusBricksPosition = new[] {
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
        };

        int builtHeight = 0;
        int currentRowNumber = 1;

        RowBricks[] wall = new RowBricks[1];

        // built the wall
        while (builtHeight < totalHeight)
        {
            Brick[] currentRow = new Brick[1];

            int builtWidth = 0;
            int currentColNumber = 1;

            Brick currentBrick = parallelepipedRedBrick;
            while (builtWidth < totalWidth)
            {
                currentBrick = parallelepipedRedBrick;
                if (greyPatternContainsCurrentBrick(greyRhombusBricksPosition, currentColNumber, currentRowNumber))
                {
                    currentBrick = parallelepipedGreyBrick;
                }

                bool evenRow = currentRowNumber % 2 == 0;
                bool firstCol = currentColNumber == 1;
                bool lastCol = builtWidth + parallelepipedRedBrick.Width >= totalWidth;

                if (evenRow)
                {
                    if (firstCol || lastCol)
                    {
                        currentBrick = cubicRedBrick;
                    }
                }

                currentRow[currentColNumber - 1] = currentBrick;

                builtWidth += currentBrick.Width;
                currentColNumber++;
                if (!lastCol)
                {
                    Array.Resize(ref currentRow, currentColNumber);
                }
            }

            wall[currentRowNumber - 1] = new RowBricks
            {
                RowNumber = currentRowNumber,
                Bricks = currentRow
            };

            currentRowNumber++;
            builtHeight += currentBrick.Height;
            if (builtHeight < totalHeight)
            {
                Array.Resize(ref wall, currentRowNumber);
            }
        }

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

    private static bool greyPatternContainsCurrentBrick(RowPattern[] greyRhombusBricksNumber, int currentColNumber, int currentRowNumber)
    {
        foreach (var greyRow in greyRhombusBricksNumber)
        {
            if (greyRow.RowNumber != currentRowNumber) { continue; }
            foreach (var greyCol in greyRow.ColumnsNumber)
            {
                if (greyCol != currentColNumber) { continue; }
                return true;
            }
        }
        return false;
    }
}
