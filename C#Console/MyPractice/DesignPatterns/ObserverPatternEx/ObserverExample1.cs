using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternEx.ObserverExample1
{
    public interface Observer: IDisposable
    {
        void Notify(string message);
        int Id { get; set; }
    }

    public interface IProvider
    {
        void Subscribe(Observer observer);
        void Unsubscribe(Observer observer);
    }

    public class Provider : IProvider
    {
        List<Observer> listOfObservers;
        string message;

        public Provider()
        {
            listOfObservers = new List<Observer>();
        }

        public string Message
        {
            set
            {
                message = value;
                NotifyAll(message);
            }
        }

        private void NotifyAll(string message)
        {
            foreach(Observer obsr in listOfObservers)
            {
                obsr.Notify(message);
            }
        }
        
        public void Subscribe(Observer observer)
        {
            CheckArgumentNullException(observer);

            if (!listOfObservers.Contains(observer))
            {
                listOfObservers.Add(observer);
            }
        }

        public void Unsubscribe(Observer observer)
        {
            CheckArgumentNullException(observer);

            if (listOfObservers.Contains(observer))
            {
                listOfObservers.Remove(observer);
            }
        }

        public Observer UnsubscribeById(int Id)
        {
            var observer = listOfObservers.Find(ob => ob.Id == Id);
            Unsubscribe(observer);
            return observer;
        }
        private void CheckArgumentNullException(Observer observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException("observer cannot be null");
            }
        }
    }

    public class ObserverOne : Observer, IDisposable
    {
        private readonly IProvider _localProvider;
        public int Id { get; set; }

        public ObserverOne(IProvider provider)
        {
            _localProvider = provider;
            _localProvider.Subscribe(this);
        }

        public ObserverOne(int observerId, IProvider provider): this(provider)
        {
            this.Id = observerId;
        }

        public void Notify(string message)
        {
            Console.WriteLine(string.Format("Id: {0};ObserverOne:{1}", Id, message));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                    _localProvider.Unsubscribe(this);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                Console.WriteLine(" DisposingId: "+ Id);
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~ObserverOne()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class ObserverTwo : Observer, IDisposable
    {

        private IProvider _localProvider;
        public int Id { get; set; }

        public ObserverTwo(IProvider provider)
        {
            _localProvider = provider;
            provider.Subscribe(this);
        }

        public ObserverTwo(int observerId, IProvider provider) : this (provider){
            this.Id = observerId;
        }

        public void Notify(string message)
        {
            Console.WriteLine(string.Format("Id: {0};ObserverTwo:{1}", Id, message));
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _localProvider.Unsubscribe(this);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ObserverTwo() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }

    public class Run
    {
        public static void RunMain()
        {
            var provider = new Provider();

            using (var observerOne = new ObserverOne(provider))
            {
                provider.Message = "Hello ObserverOne";
            }

            using (var observerTwo = new ObserverTwo(provider))
            {
                provider.Message = "Hello ObserverTwo";
            }

            for (int i = 1, notifyCounter = 1000; i < 10000;i++)
            {
                var observer1 = new ObserverOne(i, provider);
                //var observer2 = new ObserverTwo(i, provider);
                if(notifyCounter == i)
                {
                    provider.Message = "Reached : " + i;
                    for (int lastValue = notifyCounter; lastValue > notifyCounter - 1000; lastValue--)
                    {
                       var ob = provider.UnsubscribeById(lastValue);
                        ob.Dispose();
                    }
                    notifyCounter += 1000;
                }
            }
            //provider = null;
            Console.ReadLine();
            //provider.Message = "Notify one million observer";
        }
    }

}
