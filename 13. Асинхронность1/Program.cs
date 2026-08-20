using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace _13.Асинхронность
{
    internal class Program
    {
        static ManualResetEvent done = new ManualResetEvent(false);
        delegate string ProcessDelegate(string data);
        static void Main(string[] args)
        {
            ProcessDelegate processor = ProcessData;

            string str = "Hello World";

            processor.BeginInvoke(str, new AsyncCallback(CallbackMethod), "Строка");

            done.WaitOne();
            Console.WriteLine("Программа завершена");

        }

        static string ProcessData(string data)
        {
            Console.WriteLine($"  Асинхронный метод в потоке {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000); 
            return $"{data.ToUpper()}";
        }

        static void CallbackMethod(IAsyncResult ar)
        {
            string state = (string)ar.AsyncState;
            Console.WriteLine($"  Данные состояния: {state}");

            AsyncResult result = (AsyncResult)ar;
            ProcessDelegate originalDelegate = (ProcessDelegate)result.AsyncDelegate;
            string output = originalDelegate.EndInvoke(ar);

            done.Set();

            Console.WriteLine($"  Результат: {output}");
        }

    }
}
