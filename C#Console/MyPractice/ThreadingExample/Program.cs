using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingExample
{
    class Program
    {
        static EventWaitHandle autoReset = new ManualResetEvent(false);
 
        static void LongRunning(object state)
        {
            string threadName = Thread.CurrentThread.ManagedThreadId.ToString();
            int num1 = (int)state;
            for (int i = 0; i < num1; i++)
            {
                Console.WriteLine("{0} : {1}", threadName, i);
                if (i > 500)
                {
                    //throw new OperationCanceledException(
                }
            }

        }

        static void Main(string[] args)
        {
            //ParameterizedThreadStartExample();
            //ThreadAbortExample();
            //ThreadStaticExample();
            //ThreadLocalExample();
            //ThreadPoolExample();
            //TaskRunExample();
            TaskRunAndWaitForResult();
        }

        private static void TaskRunAndWaitForResult()
        {
          Task<List<string>> result =   Task<List<string>>.Run(() => {
                List<string> retList = new List<string>();
                for (int i = 0; i < 100; i++)
                {
                    retList.Add(i.ToString());
                }
                return retList;
            });
          List<string> resList = result.Result;
          Console.WriteLine(String.Join<string>(",", resList));
        }

        private static void TaskRunExample()
        {
            Task t = Task.Run(() => {
                LongRunning(1000);
            });
            t.Wait();
        }

        private static void ThreadPoolExample()
        {
            ThreadPool.QueueUserWorkItem(LongRunning, 100);
            ThreadPool.QueueUserWorkItem(LongRunning, 100);
        }

        private static void ThreadLocalExample()
        {
            ThreadLocal<int> localCopy = new ThreadLocal<int>(() => { return 100; });
            new Thread(() =>
            {
                for (int i = 0; i < localCopy.Value; i++)
                {
                    Console.WriteLine("Thread A : " + i);
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < localCopy.Value; i++)
                {
                    Console.WriteLine("Thread B : " + i);
                }
            }).Start();
        }

        static void ParameterizedThreadStartExample()
        {
            ParameterizedThreadStart pStart = LongRunning;
            Thread t = new Thread(pStart);
            t.Start(10000);
            t.Join();
        }
        static void ThreadAbortExample()
        {
            bool stop = false;
            Thread t = new Thread(() =>
             {
                 int len = 1000;
                 for (int i = 0; i < len; i++)
                 {
                     //if (stop)
                     //{
                     //    break;
                     //}
                     Console.WriteLine("Length: " + i);
                 }
             });
            t.Start();
            for (int i = 0; i < 500; i++)
            {
                Console.WriteLine("Main Length: " + i);
            }
            try
            {
                t.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine("thread aborted successfully");
            }

        }
        [ThreadStatic]
        public static int _field;
        static void ThreadStaticExample()
        {
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread A : " + _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread B : " + _field);
                }
            }).Start();
        }
    }
}
