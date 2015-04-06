using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class Invoker
    {
        List<IDBCommand> commandList;
        public Invoker()
        {
            commandList = new List<IDBCommand>();
        }
        
        public void Add(IDBCommand command)
        {
            commandList.Add(command);
        }

        public async void ExecuteAsync()
        {
            foreach (IDBCommand cmd in commandList)
            {
                cmd.Execute();
            }
        }
    }
}
