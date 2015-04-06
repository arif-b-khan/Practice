using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class CommandReceiver : CommandPattern.ICommandReceiver
    {
        public void Insert()
        {
            Console.WriteLine("Inserted Command");
        }
        public void Update()
        {
            Console.WriteLine("Updated command");
        }
        public void Delete()
        {
            Console.WriteLine("Delete command");
        }
    }
}
