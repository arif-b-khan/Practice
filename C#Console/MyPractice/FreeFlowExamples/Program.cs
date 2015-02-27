using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeFlowExamples
{
    class Base
    {
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
        
        public Derived(string name)
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
            Base b = new Base();
            b.Execute();
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
        public B(string n) : base("")
        {

        }
    }

    class C : B
    {
        public C(string n) : base("")
        {

        }
    }

    class Program
    {
        public static readonly Base MYBASE = new Base("Orignal");
        
        static void Main(string[] args)
        {
           Base b1 =  Program.MYBASE;
           Console.WriteLine(b1.Name);
           b1.Name = "Fake";
           Console.WriteLine(b1.Name);
        }

    }
}
