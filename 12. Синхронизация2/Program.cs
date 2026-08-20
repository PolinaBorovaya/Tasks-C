using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Синхронизация2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var mutex = new Mutex(true, Constans.mutexName, out bool createdNew))
            {
                if (!createdNew)
                {
                    Console.WriteLine("Приложение уже запущено!");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Приложение запущено успешно!");
                Console.WriteLine("Это единственный экземпляр.");
                Console.ReadKey();
            }


        }
    }
}
