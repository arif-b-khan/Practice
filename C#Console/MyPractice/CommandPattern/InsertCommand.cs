using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class InsertCommand : IDBCommand
    {
        ICommandReceiver receiver;
        public InsertCommand(ICommandReceiver pReceiver)
        {
            receiver = pReceiver;
        }

        public void Execute()
        {
            receiver.Insert();
        }
    }
}
