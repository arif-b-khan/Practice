using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeFlowExamples
{
    class Base
    {
        public string name = "Arif Khan";
        public string Name { get; set; }
        public Base()
        {

        }
        public Base(string name)
        {
            Name = name;
        }
        public virtual void Execute()
        {
            Console.WriteLine("Base.Execute");
        }
        public void RunExecute()
        {
            Execute();
        }
    }

    class Derived : Base
    {
        public const string FirstName = "Arif";
        public string LastName = "khan";
        public Derived(string name)
            : base(name)
        {

        }
        public virtual void Execute()
        {
            Console.WriteLine("Derived.Execute");
        }
    }
    class RunBaseDerivedVirtualExample
    {
        public static void Run()
        {
            //Base b = new Base();
            //b.Execute();
            Base b1 = new Derived("Hello");
            b1.RunExecute();
        }
    }

    class A
    {
        public A(string n)
        {

        }
    }

    class B : A
    {
        public B(string n)
            : base("")
        {

        }
    }

    class C : B , IFormattable
    {
        public C(string n)
            : base("")
        {

        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "";
        }
    }

    class Program
    {
        public static readonly Base MYBASE = new Base("Orignal");

        static void Main(string[] args)
        {
            //Base b1 =  Program.MYBASE;
            //Console.WriteLine(b1.Name);
            //b1.Name = "Fake";
            //Console.WriteLine(b1.Name);
            //RunBaseDerivedVirtualExample.Run();
            Task<int> task = Ret1();
            Console.WriteLine("Main Thread waiting");
            Console.WriteLine(task.Result);
        }
        static async Task Sample()
        {
            Task.Delay(1000);
            Console.WriteLine("Sample");
        }

        static int LoopTask()
        {
            int r = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                r += i;
            }
            return r;
        }
        
        static async Task<int> Ret1()
        {
            Console.WriteLine("Waiting for Ret2..");
            Task task0 = Sample();
            Task<int> task1 = Ret2();
            Task.WhenAll(task0, task1);
            Console.WriteLine("Result Received");
            return task1.Result;
        }

        static async Task<int> Ret2()
        {
            return LoopTask();
        }

    }
}
