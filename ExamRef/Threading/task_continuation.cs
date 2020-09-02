using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef.Threading
{
    /*
     * A continuation task can be nominated to start when an existing task (the antecedent task) finishes. 
     * If the antecedent task produces a result, it can be supplied as an input to the continuation task. 
     * Continuation tasks can be used to create a “pipeline” of operations, with each successive stage starting when the preceding one ends.
     */
    class Task_Continuation
    {
        public static int HelloTask()
        {
            Thread.Sleep(1000); Console.WriteLine("Hello");
            return 99;
        }

        public static void WorldTask(int a)
        {
            Thread.Sleep(1000); 
            Console.WriteLine("World");
            Console.WriteLine(a);
        }

        public static void Run()
        {
            Task<int> task = Task.Run(() => HelloTask()); 
            task.ContinueWith((prevTask) => WorldTask(prevTask.Result));
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
