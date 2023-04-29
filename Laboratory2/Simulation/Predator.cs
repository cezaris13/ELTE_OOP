public class Predator : Species{
    public int Child{get; protected set;}
    public int PerAnimal{get; protected set;}

    public Predator() {
        TimePeriod = 8;
    }

    public override int Reproduce(int number, int year){
        if(year % TimePeriod == 0)
            number += (int)(MultiplicationFactor() * number);
        return number;
    }

    public override double MultiplicationFactor(){
        return Child/PerAnimal;
    }

    public void Attack(int predatorNumber, Colony preyColony){
        if(!preyColony.Species.IsPrey())
            return;
        var prey = (Prey)preyColony.Species;

        var number = preyColony.Number;
        var success = prey.Attacked(ref number,predatorNumber); // retrieve unfeeded predator count
        preyColony.Number = number;

        // preyColony.Species

    }

    public override bool IsPredator(){
        return true;
    }
}
