using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Память
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (var monitor = new MemoryMonitor(100, 70))
            {
                monitor.ShowGCInfo();

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"\nШаг {i + 1}:");
                    monitor.AllocateMemory(15 + i * 5); 
                }

                Console.WriteLine("\nОсвобождение памяти:");
                monitor.FreeMemory(2);
                monitor.FreeMemory(0);

                Console.WriteLine("\nДополнительное выделение:");
                monitor.AllocateMemory(10);

                monitor.ShowGCInfo();
            }

        }
    }
}
