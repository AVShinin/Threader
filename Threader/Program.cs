using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threader
{
    class Program
    {
        static List<Task> taskPool = new List<Task>();
        static void Main(string[] args)
        {
            Console.WriteLine("Start threads");

            new Thread(new ThreadStart(()=>Task.WhenAll(taskPool))).Start();

            START_SWITCH:
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    {
                        taskPool.Add(BackgroundWork(4, 300));
                        goto START_SWITCH;
                    }
                case ConsoleKey.S:
                    {
                        taskPool.Add(BackgroundWork(5, 100));
                        goto START_SWITCH;
                    }
                case ConsoleKey.D:
                    {
                        taskPool.Add(BackgroundWork(6, 5000));
                        goto START_SWITCH;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        static Task BackgroundWork(int iThread,int msec = 100)
        {
            return Task.Run(()=> 
            {
                for (int i = 1; i <= 100; i++)
                {
                    Console.WriteLine($"Thread {iThread}. Complete={i}%");
                    Thread.Sleep(msec);
                }
            });
        }
    }
}
