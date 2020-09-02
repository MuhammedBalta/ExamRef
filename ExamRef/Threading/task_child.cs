using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamRef.Threading
{
    /*
     * Code running inside a parent Task can create other tasks, but these “child” tasks will execute independently of the parent in which they were created
     * Such tasks are called detached child tasks or detached nested tasks
     */
    class Task_Child
    {
        public static void DoChild(object state)
        {
            Console.WriteLine("Child {0} starting", state); 
            Thread.Sleep(2000); 
            Console.WriteLine("Child {0} finished", state);
        }

        public static void Run()
        {

            var parent = Task.Factory.StartNew(() => {
                Console.WriteLine("Parent starts"); for (int i = 0; i < 10; i++)
                {
                    int taskNo = i; 
                    Task.Factory.StartNew((x) => DoChild(x), // lambda expression 
                        taskNo, // state object 
                        TaskCreationOptions.AttachedToParent);
                }
            });
            //You can create a task without any attached child tasks by specifying the TaskCreationOptions.DenyChildAttach option when you create the task
            //Note that tasks created using the Task.Run method have the TaskCreationOptions.DenyChildAttach option set,and therefore can’t have attached child tasks.
            parent.Wait(); // will wait for all the attached children to complete
            Console.WriteLine("Parent finished. Press a key to end."); 
            Console.ReadKey();
            
        }
    }
}
