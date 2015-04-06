using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class DeleteCommand : IDBCommand
    {
        ICommandReceiver receiver;
        public DeleteCommand(ICommandReceiver pReceiver)
        {
            receiver = pReceiver;
        }

        public void Execute()
        {
            receiver.Delete();
        }
    }
}
