using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef.Threading
{
    class Parallel_Invoke
    {
        static void Task1()
        {
            Console.WriteLine("Task 1 starting"); 
            Thread.Sleep(2000); 
            Console.WriteLine("Task 1 ending");
        }
        static void Task2()
        {
            Console.WriteLine("Task 2 starting"); 
            Thread.Sleep(1000); 
            Console.WriteLine("Task 2 ending");
        }

        public static void Run()
        {
            /*
             * The Parallel.Invoke method accepts a number of Action delegates and creates a Task for each of them
             * An Action delegate is an encapsulation of a method that accepts no parameters and does not return a result. It can be replaced with a lamba expression
             * The Parallel.Invoke method can start a large number of tasks at once. You have no control over the order in which the tasks are started or which processor they are assigned to.
             * The Parallel.Invoke method returns when all of the tasks have completed.
             */
            Parallel.Invoke(() => Task1(), () => Task2());
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
