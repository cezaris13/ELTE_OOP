using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    public class Menu
    {
        private Set set = new Set();

        public Menu() { }

        public void Run()
        {
            int n;
            do
            {
                PrintMenu();
                try
                {
                    n = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException) { n = -1; }
                switch (n)
                {
                    case 1:
                        InsertElement();
                        break;
                    case 2:
                        RemoveElement();
                        break;
                    case 3:
                        IsEmpty();
                        break;
                    case 4:
                        ContainsElement();
                        break;
                    case 5:
                        ReturnRandom();
                        break;
                    case 6:
                        EvenElementsCount();
                        break;
                    case 7:
                        PrintSet();
                        break;

                }

            } while (n != 0);

        }

#region Menu operations

        static private void PrintMenu()
        {
            Console.WriteLine("\n\n 0. - Quit");
            Console.WriteLine(" 1. - Insert an element");
            Console.WriteLine(" 2. - Remove an element");
            Console.WriteLine(" 3. - Is empty set");
            Console.WriteLine(" 4. - Contains element");
            Console.WriteLine(" 5. - Return random element");
            Console.WriteLine(" 6. - Even elements count");
            Console.WriteLine(" 7. - Print set");
            Console.Write(" Choose: ");
        }

        private void InsertElement()
        {
            Console.WriteLine("Give the value of the element to insert: ");
            int i = int.Parse(Console.ReadLine());
            set.InsertElement(i);
        }

        private void RemoveElement()
        {
            Console.WriteLine("Give the value of the element to remove: ");
            int i = int.Parse(Console.ReadLine());
            set.RemoveElement(i);
        }

        private void IsEmpty()
        {
            Console.WriteLine($"Is set empty: {set.IsEmpty()}");
        }

        private void ContainsElement()
        {

        }

        private void ReturnRandom()
        {
            Console.WriteLine($"Random element from the set: {set.ReturnRandomElement()}");
        }

        private void EvenElementsCount()
        {
            Console.WriteLine($"Even elements count: {set.GetEvenElementsCount()}");
        }

        private void PrintSet()
        {
            set.Print();
        }
#endregion
    }
}
 
