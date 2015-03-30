using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerExample
{
    public interface ICalculator
    {
        double Add(double num1, double num2);
        double Sub(double num1, double num2);
    }
}
