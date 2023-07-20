namespace Bricklayer;

internal class GreyPattern
{
    private RowPattern[] pattern;
    internal RowPattern[] GetPattern() {
        return pattern;
    }
    internal void SetPattern(RowPattern[] value) {
        pattern = value;
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