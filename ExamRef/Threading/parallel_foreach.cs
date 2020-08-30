using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef.Threading
{
    class Parallel_Foreach
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        public static void Run()
        {
            var items = Enumerable.Range(0, 500);
            /*
             * The Parallel.ForEach method accepts two parameters. The first parameter is an IEnumerable collection (in this case the list items).
             * The second parameter provides the action to be performed on each item in the list
             */
            Parallel.ForEach(items, item => {
                WorkOnItem(item);
            });
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
