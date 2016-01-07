using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityContainerExample
{
    public class CalculatorService
    {
        ICalculator calculator;
        Logger logger;
        public CalculatorService(ICalculator cal, Logger log)
        {
            calculator = cal;
            logger = log;
        }
        public double AddOperation(double num1, double num2)
        {
            if (calculator != null)
            {
                double result = calculator.Add(num1, num2);
                logger.Print("Calculator Service: " + result);
                return result;
            }
            return 0;
        }

        public double SubOperation(double num1, double num2)
        {
            if (calculator != null)
            {
                return calculator.Sub(num1, num2);
            }
            return 0;
        }

    }
}
