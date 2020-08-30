using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef.Threading
{
    class Parallel_For
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        public static void Run()
        {
            var items = Enumerable.Range(0, 500).ToArray();
            /*
             * ParallelLoopState that allows the code being iterated to control the iteration process
             * ParallelLoopResult that can be used to determine whether or not a parallel loop has successfully completed.
             */
            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) => {
                /*
                 * Stop is used to stop the loop during the 200th iteration it might be that iterations with an index lower than 200 will not be performed.
                 *  If Break is used to end the loop iteration, all the iterations with an index lower than 200 are guaranteed to be completed before the loop is ended
                 */
                if (i == 200) loopState.Stop();
                WorkOnItem(items[i]);
            });
            Console.WriteLine("Completed: " + result.IsCompleted); 
            Console.WriteLine("Items: " + result.LowestBreakIteration);
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
