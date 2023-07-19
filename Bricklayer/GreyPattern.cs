namespace Bricklayer;

internal class GreyPattern
{
    public RowPattern[] pattern;

    public GreyPattern(RowPattern[] pattern)
    {
        this.pattern = pattern;
    }

    public bool IsContainingBrick(int currentColNumber, int currentRowNumber)
    {
        foreach (var greyRow in pattern)
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