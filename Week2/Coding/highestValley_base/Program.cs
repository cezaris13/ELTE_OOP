using System.IO;
using System.Numerics;
using System.Collections.Generic;
using System;
using TextFile;

namespace highestValley
{
    internal class Program
    {

        private static bool fileRead(out List<int> vec, String fileName)
        {
            vec = new List<int>();
            try
            {
                TextFileReader f = new TextFileReader(fileName);
                while (f.ReadInt(out int e))
                {
                    vec.Add(e);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool condMaxSearch(List<int> x, out int max, out int ind)
        {
            //TODO: CONDITIONAL MAX SEARCH
        }

        static void Main(string[] args)
        {
            //TODO: Get file name
            //TODO: Read file if possible
            //TODO: Solve task
        }
    }
}