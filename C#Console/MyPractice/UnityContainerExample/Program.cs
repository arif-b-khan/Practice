using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorService service = DependencyFactory.Resolve<CalculatorService>();
            Console.WriteLine(service.AddOperation(10, 10));
        }
    }
}
