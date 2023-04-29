

public class Colony {
    public string Name { get; private set; }
    public int Number { get; set; }
    public Species Species { get; private set; }

    public Colony(string name, int number, Species species){
        Name = name;
        Number = number;
        Species = species;
    }

    public int Reproduce(int year){
        Number = Species.Reproduce(Number,year);
        return Number;
    }

    public override string ToString(){
        return $"name: {Name}, population: {Number}, species:{Species.GetType()}";
    }
}
