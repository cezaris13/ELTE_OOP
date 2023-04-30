public class Prey : Species
{
    protected readonly int _maxColony;
    protected readonly int _resetColony;
    protected readonly double _multiplyFactor;
    protected readonly int _predatorFactor;

    public Prey(int timePeriod, int maxColony, int resetColony, double multiplyFactor, int predatorFactor)
    {
        _timePeriod = timePeriod;
        _maxColony = maxColony;
        _resetColony = resetColony;
        _multiplyFactor = multiplyFactor;
        _predatorFactor = predatorFactor;
    }

    protected override double MultiplicationFactor
    {
        get
        {
            return _multiplyFactor;
        }
    }

    public override int Reproduce(int populationNumber, int year)
    {
        if (year % _timePeriod != 0)
            return populationNumber;
        int tempPopulationNumber = (int)(MultiplicationFactor * populationNumber);
        if (tempPopulationNumber > _maxColony)
            return _resetColony;
        return tempPopulationNumber;
    }

    public int Attacked(ref int preyCount, int predatorCount)
    {
        var unfedPredators = preyCount / _predatorFactor;
        preyCount -= _predatorFactor * predatorCount;
        // IsExtinct = preyCount <= 0;
        return preyCount <=0 ? unfedPredators : 0;
    }

    public override bool IsPrey()
    {
        return true;
    }
}
