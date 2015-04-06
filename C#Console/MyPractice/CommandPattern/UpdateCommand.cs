using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class UpdateCommand : IDBCommand
    {
        ICommandReceiver receiver;
        public UpdateCommand(ICommandReceiver pReceiver)
        {
            receiver = pReceiver;
        }

        public void Execute()
        {
            receiver.Update();
        }
    }
}
