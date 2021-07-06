public class ComplexityGridController
{
    const byte MAX_COMPLEXITY = 3;
    byte currentComplexity = 1;
    ComplexityGrid easy = new ComplexityGrid(countRow: 1, countColum: 3);
    ComplexityGrid normal = new ComplexityGrid(countRow: 2, countColum: 3);
    ComplexityGrid hard = new ComplexityGrid(countRow: 3, countColum: 3);


    public ComplexityGrid GetCurrentComplexity()
    {
        switch (currentComplexity)
        {
            case 1:
                return easy;
            case 2:
                return normal;
            case 3:
                return hard;
            default:
                return easy;
        }
    }

    public void IncreaseComplexity()
    {
        if (currentComplexity != MAX_COMPLEXITY)
            ++currentComplexity;
        else
            currentComplexity = 1;
    }

    public bool IsMaxLevelComplexityGrid()
    {
        if (currentComplexity == MAX_COMPLEXITY)
            return true;
        else
            return false;
    }
}