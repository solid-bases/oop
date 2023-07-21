namespace Bricklayer.Builder;

internal class GreyPattern
{
    private RowPattern[] pattern;

    internal RowPattern[] Pattern
    {
        get => pattern;
        set
        {
            if (value == null)
            {
                pattern = new RowPattern[0];
                return;
            }
            pattern = value;
        }
    }

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
