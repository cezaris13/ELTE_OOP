using System.Globalization;
using System.Threading;

namespace Set
{
    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            Menu m = new Menu();
            m.Run();
        }
    }
}
