using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef.Threading
{
    class Task_Create
    {
        public static void DoWork()
        {
            Console.WriteLine("Work starting"); 
            Thread.Sleep(2000);
            Console.WriteLine("Work finished");
        }

        public static int CalculateResult()
        {
            Console.WriteLine("Work starting"); 
            Thread.Sleep(2000); 
            Console.WriteLine("Work finished"); 
            return 99;
        }

        public static void Run()
        {
            Task newTask = new Task(() => DoWork()); 
            newTask.Start(); 
            newTask.Wait();
            //A task can also be created and started using a single method, called Run
            Task<int> runingTask = Task.Run(() =>
            {
                return CalculateResult();
            });
            Console.WriteLine(runingTask.Result);
            Console.WriteLine("Finished processing. Press a key to end."); 
            Console.ReadKey();

        }
    }
}
