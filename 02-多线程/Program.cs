using System;
using System.Threading;

namespace _02_多线程
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(childThreadMethod));
            thread.Start();

            Console.WriteLine("main thread running!");
        }

        private static void childThreadMethod()
        {
            Console.WriteLine("child thread running!");
        }
    }
}
