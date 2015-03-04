using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegexExample
{
    class Program
    {
        static string strTobeSplitted = "ordersearch.aspx|myaccountstatementsearch.aspx";
        static void Main(string[] args)
        {
            List<string> strArr = strTobeSplitted.Split(new string[]{"|"}, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
            foreach (var item in strArr)
            {
                Console.WriteLine(item.Trim());
            }
        }
    }
}
