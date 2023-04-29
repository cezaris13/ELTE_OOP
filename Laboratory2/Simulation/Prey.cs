public class Prey : Species{
    public int MaxColony {get;protected set;}
    public int ResetColony {get;protected set;}
    public double MultiplyFactor {get;protected set;}
    public int PredatorFactor {get;protected set;}

    public override double MultiplicationFactor(){
        return MultiplyFactor;
    }

    public override int Reproduce(int number, int year){
        if(year % TimePeriod != 0)
            return number;
        int tempNumber = (int)(MultiplicationFactor() * number);
        if(tempNumber > MaxColony)
            return ResetColony;
        return tempNumber;
    }

    public bool Attacked(ref int preyCount,int predatorCount){
        preyCount -= PredatorFactor*predatorCount;
        IsExtinct = preyCount <= 0;
        return IsExtinct;
    }

    public override bool IsPrey(){
        return true;
    }
}
