using System.Globalization;
using System.Threading;

namespace Set
{
    public static class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var m = new Menu();
            m.Run();
        }
    }
}
