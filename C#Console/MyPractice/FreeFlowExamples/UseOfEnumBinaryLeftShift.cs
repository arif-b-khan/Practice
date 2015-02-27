using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeFlowExamples
{

    public enum Numbers
    {
        One = 1 << 0,
        Two = 1 << 1,
        Three = 1 << 2
    }
    class UseOfEnumBinaryLeftShift
    {
        static void AddEntry(Numbers num1, Numbers num2, List<string> addToList, string name)
        {
            if ((num2 & num1) != 0)
            {
                addToList.Add(name);
            }
        }

        public static void Run(Numbers numbers)
        {
            List<string> list = new List<string>();
            AddEntry(numbers, Numbers.One, list, "One");
            AddEntry(numbers, Numbers.Two, list, "Two");
            AddEntry(numbers, Numbers.Three, list, "Three");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
