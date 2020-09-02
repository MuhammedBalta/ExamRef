using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef.Threading
{
    class Task_Waitall
    {
        public static void DoWork(int i)
        {
            Console.WriteLine("Task {0} starting", i); 
            Thread.Sleep(2000); 
            Console.WriteLine("Task {0} finished", i);
        }

        public static void Run()
        {
            Task[] Tasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                int taskNum = i; // make a local copy of the loop counter so that the // correct task number is passed into the lambda expression
                Tasks[i] = Task.Run(() => DoWork(taskNum));
            }
            //The Task.Waitall method can be used to pause a program until a number of tasks have completed
            //Task.WaitAll(Tasks);
            Task.WaitAny(Tasks);
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
