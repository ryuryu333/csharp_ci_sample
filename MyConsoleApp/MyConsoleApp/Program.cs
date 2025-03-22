using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main()
        {
            Calculator myCalculator = new Calculator();
            int result = myCalculator.Add(1, 2);
            Console.WriteLine(result);

            //UseLocaldll useLocaldll = new UseLocaldll();
            //useLocaldll.SomeMethod();
        }
    }
}
