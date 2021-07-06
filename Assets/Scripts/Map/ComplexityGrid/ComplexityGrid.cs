public struct ComplexityGrid
{
    public readonly int countRow;
    public readonly int countColum;

    public ComplexityGrid(int countRow, int countColum)
    {
        this.countRow = countRow;
        this.countColum = countColum;
    }

    public int GetCountCells()
    {
        return countRow * countColum;
    }
}