using System;
using TextFile;
using System.Collections.Generic;

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
            for (int i = 0; i < preyColonies + predatorColonies; i++)
            {
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
                        case 'l': species = Lemming.Instance; break;
                        case 'h': species = Hare.Instance; break;
                        case 'g': species = Gopher.Instance; break;
                        case 'w': species = Wolf.Instance; break;
                        case 'o': species = Owl.Instance; break;
                        case 'f': species = Fox.Instance; break;
                    }
                    colony = new Colony(name, number, species);
                }
                if (colony != null)
                {
                    if (colony.Species.IsPrey())
                    {
                        preys.Add(colony);
                    }
                    else
                    {
                        predators.Add(colony);
                    }
                }
            }

            PrintData(predators, preys);

            int year = 0;
            var random = new Random();
            int originalCount = PreyColonyCount(preys);
            while (preys.Count > 0 && PreyColonyCount(preys) < 4 * originalCount)
            {
                Console.WriteLine($"\nyear:({year})");
                foreach (var predator in predators)
                {
                    predator.Reproduce(year);
                }
                foreach (var prey in preys)
                {
                    prey.Reproduce(year);
                }

                foreach (var predator in predators)
                {
                    if (preys.Count <= 0)
                        continue;
                    var nextPrey = random.Next() % preys.Count;
                    var number = predator.Number;
                    ((Predator)predator.Species).Attack(ref number, preys[nextPrey]);
                    if (preys[nextPrey].IsExtinct)
                        preys.Remove(preys[nextPrey]);
                    if (predator.IsExtinct)
                        predators.Remove(predator);
                }
                PrintData(predators, preys);
                year++;
            }
        }

        private static int PreyColonyCount(List<Colony> preys)
        {
            var preysCount = 0;
            foreach (var prey in preys)
            {
                preysCount += prey.Number;
            }
            return preysCount;
        }

        private static void PrintData(List<Colony> predators, List<Colony> preys)
        {
            Console.WriteLine("__________\npredators: \n");
            foreach (var predator in predators)
            {
                Console.WriteLine(predator);
            }

            Console.WriteLine("\npreys: \n");
            foreach (var prey in preys)
            {
                Console.WriteLine(prey);
            }
        }
    }
}
