using System;
using TextFile;
using System.Collections.Generic;
using System.Linq;

namespace Creatures
{
    class Program
    {
        static void Main()
        {
            TextFileReader reader = new TextFileReader("input.txt");

            // Getting colony count;
            reader.ReadInt(out int preyColonies);
            reader.ReadInt(out int predatorColonies);

            var predators = new List<Colony>();
            var preys = new List<Colony>();
            for(int i =0;i<preyColonies+predatorColonies;i++){
            // discuss with the lecturer about inconsistencies in the input file given, and ask whether it shpuld be 2 separate fors or 1 big
                char[] separators = new char[] { ' ', '\t' };
                Colony colony = null;

                if (reader.ReadLine(out string line))
                {
                    Species species = null;

                    string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    string name = tokens[0];
                    char type = char.Parse(tokens[1]);
                    int number = int.Parse(tokens[2]);

                    switch (type)
                    {
                        case 'l': species = new Lemming(); break;
                        case 'h': species = new Hare(); break;
                        case 'g': species = new Gopher(); break;
                        case 'w': species = new Wolf(); break;
                        case 'o': species = new Owl(); break;
                        case 'f': species = new Fox(); break;
                    }
                    colony = new Colony(name, number, species);
                }
                if (colony != null) {
                    if(colony.Species.IsPrey()){
                        preys.Add(colony);
                    }
                    else{
                        predators.Add(colony);
                    }
                }
            }

            foreach(var prey in preys)
            {
                Console.WriteLine(prey);
            }

            foreach(var prey in predators)
            {
                Console.WriteLine(prey);
            }

            int originalCount = preys.Sum(p=>p.Number); // change later
            int year =0;
            var random = new Random();
            while(preys.Count() > 0 && preys.Sum(p=>p.Number) < 4*originalCount){
                foreach(var predator in predators){
                    predator.Reproduce(year);
                }
                foreach(var prey in preys){
                    prey.Reproduce(year);
                }

                foreach(var predator in predators){
                    if(preys.Count()<=0)
                        continue;
                    var nextPrey = random.Next() % preys.Count();
                    ((Predator)predator.Species).Attack(predator.Number,preys[nextPrey]);
                    if(preys[nextPrey].Species.IsExtinct)
                        preys.Remove(preys[nextPrey]);
                }
                foreach(var predator in predators){
                    Console.WriteLine(predator);
                }
                foreach(var prey in preys){
                    Console.WriteLine(prey);
                }
                year++;
            }
         }
    }
}
