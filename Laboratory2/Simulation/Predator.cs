public class Predator : Species
{
    protected readonly int _child;
    protected readonly int _perAnimal;

    public Predator(int child, int perAnimal)
    {
        _timePeriod = 8;
        _child = child;
        _perAnimal = perAnimal;
    }

    protected override double MultiplicationFactor
    {
        get
        {
            return _child / _perAnimal;
        }
    }

    public override int Reproduce(int populationNumber, int year)
    {
        if (year % _timePeriod == 0)
            populationNumber += (int)(MultiplicationFactor * populationNumber);
        return populationNumber;
    }

    public void Attack(ref int predatorNumber, Colony preyColony)
    {
        if (!preyColony.Species.IsPrey())
            return;

        var preySpecies = (Prey)preyColony.Species;
        var preyColonyNumber = preyColony.Number;
        var unfedPredators = preySpecies.Attacked(ref preyColonyNumber, predatorNumber);
        preyColony.Number = preyColonyNumber;

        if (preyColony.IsExtinct)
            predatorNumber -= unfedPredators / 4;
    }

    public override bool IsPredator()
    {
        return true;
    }
}
