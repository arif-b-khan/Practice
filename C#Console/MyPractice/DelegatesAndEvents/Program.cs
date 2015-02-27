using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class Program
    {
        public static Func<double, double, double> Calculation;
        static void Main(string[] args)
        {
            MulticastDelegateExample();
        }

        private static void MulticastDelegateExample()
        {
            Calculation += (n1, n2) => n1 + n2;
            Calculation += (n1, n2) =>
            {
                throw new InvalidOperationException("Invalid operation");
                return 10;
            };
            Calculation += (n1, n2) => n1 - n2;
            Calculation += (n1, n2) => n1 * n2;
            Calculation += (n1, n2) => n1 / n2;
            List<Exception> listException = new List<Exception>();

            Parallel.ForEach(Calculation.GetInvocationList(), d =>
            {
                try
                {
                    double result = (double)d.DynamicInvoke(10, 10);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    listException.Add(ex);
                }

            });
        }
    }
}
