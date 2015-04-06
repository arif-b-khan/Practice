using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommandReceiver recevier = new CommandReceiver();
            Invoker invoker = new Invoker();
            invoker.Add(new InsertCommand(recevier));
            invoker.Add(new InsertCommand(recevier));
            invoker.Add(new UpdateCommand(recevier));
            invoker.Add(new DeleteCommand(recevier));
            invoker.ExecuteAsync();
        }
    }
}
