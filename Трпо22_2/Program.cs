using System;
using static System.Console;

namespace Трпо22_2
{
    public interface ISubject
    {
        void Request();
    }

    class RealSubject : ISubject
    {
        public void Request()
        {
            WriteLine("RealSubject: Handling Request.");
        }
    }

    class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            this._realSubject = realSubject;
        }

        public void Request()
        {
            if (this.CheckAccess())
            {
                this._realSubject.Request();

                this.LogAccess();
            }
        }

        public bool CheckAccess()
        {
            WriteLine("Proxy: Checking access prior to firing a real request.");
            return true;
        }

        public void LogAccess()
        {
            WriteLine("Proxy: Logging the time of request.");
        }
    }

    public class Client
    {

        public void ClientCode(ISubject subject)
        {
            subject.Request();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            WriteLine();

            WriteLine("Client: Executing the same client code with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            client.ClientCode(proxy);
        }
    }
}
