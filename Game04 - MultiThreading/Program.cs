using System;
using System.Threading;

namespace Game04___MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Started");
            Console.CursorVisible = false;

            //Creating Threads
            Thread t1 = new Thread(Method1)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(Method2)
            {
                Name = "Thread2"
            };
            Thread t3 = new Thread(Method3)
            {
                Name = "Thread3"
            };

            //Executing the methods
            t1.Start();
            t2.Start();
            t3.Start();
            Console.WriteLine("Main Thread Ended");
            Console.Read();
        }

        static void Method1()
        {
            Console.WriteLine("Method1 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Method1 :" + i);
                Thread.Sleep(500);
                //Console.ReadKey();
                //Console.WriteLine("Pressed Enter");
            }
            Console.WriteLine("Method1 ended using " + Thread.CurrentThread.Name);
        }


        static void Method2()
        {
            Console.WriteLine("Method2 started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Method2 :" + i);
                Thread.Sleep(500);
            }
            Console.WriteLine("Method2 ended using " + Thread.CurrentThread.Name);
        }
        static void Method3()
        {
            Console.WriteLine("Method3 started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("Method3 :" + i);
                Thread.Sleep(500);
            }
            Console.WriteLine("Method3 ended using " + Thread.CurrentThread.Name);
        }
    }
}
