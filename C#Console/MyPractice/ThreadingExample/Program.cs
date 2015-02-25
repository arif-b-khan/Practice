using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            //TaskRunAndWaitForResult();
            //AsyncAwaitExample();
            //Thread.Sleep(10000);
            //Console.WriteLine("Comming out of main method");
            //EnumerableParallel();
            //ConcurrentBlockingCollectionExample();
            //ConcurrentBagCollectionExample();
            CancellationOfLongRunningTask();
        }

        private static void CancellationOfLongRunningTask()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            Task t = Task.Run(() =>
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    Console.Write(i);
                    Console.Write(",");
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Cannecllation was requested");
                        throw new OperationCanceledException("Operation Cancelled exception");
                    }
                }

            }, token).ContinueWith((result) => {
                result.Exception.Handle(ex =>
                {
                    Console.WriteLine(ex.Message);
                    return true;
                });
                Console.WriteLine("Task was cancelled");
            },TaskContinuationOptions.OnlyOnCanceled);
            Thread.Sleep(2000);
            cts.Cancel();
            //try
            //{
            //    t.Wait();
            //}
            //catch (AggregateException ag)
            //{
            //    foreach (Exception ex in ag.InnerExceptions)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
        }

        private static void ConcurrentBagCollectionExample()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            for(int i = 0; i < 10; i++)
            {
                bag.Add(i);
            }
            foreach (int result in bag)
            {
                if (result == 5)
                {
                    bag.Add(100);
                }
                Console.WriteLine(result);
            }
        }

        private static void ConcurrentBlockingCollectionExample()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task readerTask = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            Task writer = Task.Run(() =>
            {
                string content = string.Empty;
                do
                {
                    content = Console.ReadLine();
                    col.Add(content);
                } while (!String.IsNullOrWhiteSpace(content));
            });
            writer.Wait();
        }

        private static void EnumerableParallel()
        {
            var parallelQuery = Enumerable.Range(0, 100);
            int[] result = parallelQuery.AsParallel().Where(i => i % 2 == 0).Select(e => e).ToArray();
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
        }

        private static async void AsyncAwaitExample()
        {
            await DownloadContent();
            Console.WriteLine("Coming out of async await method");
        }

        private static async Task DownloadContent()
        {
            //using (HttpClient client = new HttpClient())
            //{
            //    string result = await client.GetStringAsync("http://msdn.microsoft.com");
            //    return result;
            //}
            Task<int> t = Task<int>.Run(() => { LongRunning(10000); return 1000; });
            Console.WriteLine("Waiting for Download content");
            int result = await t;
            Console.WriteLine(result);
        }

        private static void TaskRunAndWaitForResult()
        {
            Task<List<string>> result = Task<List<string>>.Run(() =>
            {
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
            Task t = Task.Run(() =>
            {
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
