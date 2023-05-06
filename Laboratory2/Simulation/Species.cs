public abstract class Species
{
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
}
