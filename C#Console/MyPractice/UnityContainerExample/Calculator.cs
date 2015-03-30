using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerExample
{
    public class Calculator : ICalculator
    {
        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Sub(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
