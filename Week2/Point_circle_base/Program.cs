using System;
using TextFile;
using System.Collections.Generic;

namespace Circle
{
    class Program
    {
        static void Main()
        {
            try
            {
                TextFileReader reader = new TextFileReader("input.txt");

                reader.ReadDouble(out double a);
                reader.ReadDouble(out double b);
                reader.ReadDouble(out double c);
                
                Point p = new Point(a, b);
                Circle k = new Circle(p, c);

                
                reader.ReadInt(out int n);
                Point[] x = new Point[n];
                
                for (int i = 0; i < n; ++i)
                {
                    reader.ReadDouble(out a);
                    reader.ReadDouble(out b);
                    x[i] = new Point(a, b);
                }

                int count = 0;
                foreach(Point e in x)
                {
                    if(k.Contains(e)) count++;
                }

                System.Console.WriteLine($"There are {count} points on the circle");
            }
            catch(Circle.WrongRadiusException)
            {
                System.Console.WriteLine("The radius shouldn't be negative.");
            }
            catch(System.IO.FileNotFoundException)
            {
                Console.WriteLine("Wrong file name");
            }
        }
    }
}
