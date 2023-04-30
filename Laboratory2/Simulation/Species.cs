public abstract class Species
{
    public bool IsExtinct { get; set; }
    protected int _timePeriod;

    protected abstract double MultiplicationFactor
    {
        get;
    }

    public abstract int Reproduce(int populationNumber, int year);

    public virtual bool IsPrey()
    {
        return false;
    }

    public virtual bool IsPredator()
    {
        return false;
    }
}
