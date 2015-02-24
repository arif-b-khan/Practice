using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExample
{
    interface ICalculator
    {
        double Sum(int num1, int num2);
    }
    interface ICalcAdv
    {
        double Sum(int num1, int num2);
    }

    class Calculator : ICalculator, ICalcAdv
    {
        double ICalcAdv.Sum(int num1, int num2)
        {
            throw new NotImplementedException();
        }

        double ICalculator.Sum(int num1, int num2)
        {
            throw new NotImplementedException();
        }
    }

    class CalculatorAdv : ICalculator, ICalcAdv
    {
        public double Sum(int num1, int num2)
        {
            throw new NotImplementedException();
        }

        double ICalcAdv.Sum(int num1, int num2)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
