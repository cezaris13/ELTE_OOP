using System;
using System.Collections.Generic;

namespace LowerTriangle
{
    public class Program
    {
        static void Main(string[] args)
        {
            var matrix = new LTM();
            var matrix1 = new LTM();
            Console.WriteLine(matrix.ToString());
            Console.WriteLine(LTM.mul(matrix,matrix1).ToString());
        }
    }
}
