using System;
namespace CommandPattern
{
    public interface ICommandReceiver
    {
        void Delete();
        void Insert();
        void Update();
    }
}
