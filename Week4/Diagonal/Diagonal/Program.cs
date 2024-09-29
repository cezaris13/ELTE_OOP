using System.Globalization;
using System.Threading;

namespace Diagonal
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            Menu m = new();
            m.Run();
        }
    }

    //class of menu for diagonal matrix
}