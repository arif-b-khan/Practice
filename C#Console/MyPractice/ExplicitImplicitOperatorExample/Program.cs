using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitImplicitOperatorExample
{
    class Ferheniet
    {
        public double Unit { get; set; }
        public Ferheniet(double unit)
        {
            this.Unit = unit;
        }
    }

    class Celsius
    {
        public double Unit { get; set; }

        public Celsius(double unit)
        {
            this.Unit = unit;
        }

        public static implicit operator double(Celsius dbl)
        {
            return dbl.Unit;
        }

        public static explicit operator int(Celsius cel)
        {
            return Convert.ToInt32(cel.Unit);
        }
        public static implicit operator Ferheniet(Celsius cel)
        {
            var far = new Ferheniet(cel.Unit);
            return far;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cel = new Celsius(70.100);
            double result = cel;
            Console.WriteLine(result);
            int resultIn = (int)cel;
            Console.WriteLine(resultIn);
            Ferheniet far = cel;
            Console.WriteLine(far.Unit);
        }
    }
}
