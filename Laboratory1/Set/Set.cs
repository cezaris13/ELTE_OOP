using System;
using System.Collections.Generic;

namespace Set
{
    public class Set
    {
        // Implement the set type which contains integers. Represent the set as a sequence of its
        // elements. Implement as methods: inserting an element, removing an element, returning
        // whether the set is empty, returning whether the set contains an element, returning a
        // random element without removing it from the set, returning the number of even numbers
        // in the set (suggestion: store the number of even numbers and update it when the set
        // changes), printing the set. A set can store every element only once.
        private List<int> values;
        private int evenElementsCount;

        public Set()
        {
            values = new List<int>();
            evenElementsCount = 0;
        }

        public void InsertElement(int element)
        {
            if (!ContainsElement(element))
            {
                values.Add(element);

                if (element % 2 == 0)
                    evenElementsCount++;
            }
        }

        public void RemoveElement(int element)
        {
            if (ContainsElement(element))
            {
                if (values.Count > 1)
                {
                    for (int i = 0; i < values.Count - 1; i++)
                    {
                        if (values[i] == element)
                            values[i] = values[values.Count - 1];
                    }
                    values.RemoveAt(values.Count - 1);
                }
                else
                {
                    values.Clear();
                }
                if (element % 2 == 0)
                    evenElementsCount--;
            }
        }

        public bool IsEmpty()
        {
            return values.Count == 0;
        }

        public bool ContainsElement(int element)
        {
            bool foundElement = false;
            for (int i = 0; (i < values.Count && !foundElement); i++)
            {
                if (values[i] == element)
                    foundElement = true;
            }
            return foundElement;
        }

        public int ReturnRandomElement()
        {
            var rand = new Random();
            if (values.Count > 0)
            {
                return values[rand.Next(0, values.Count - 1)];
            }
            else
            {
                return -1;
            }
        }

        public int GetEvenElementsCount()
        {
            return evenElementsCount;
        }

        public void Print()
        { // think of specification for this!
            string combinedString = string.Join(", ", values);
            Console.WriteLine($"{{{combinedString}}}");
        }
    }
}
