public abstract class Species {
    public int TimePeriod {get; protected set;}
    public bool IsExtinct {get; protected set;}

    public abstract double MultiplicationFactor();

    public abstract int Reproduce(int number, int year);

    public virtual bool IsPrey(){
        return false;
    }

    public virtual bool IsPredator(){
        return false;
    }
}
