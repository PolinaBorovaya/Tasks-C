using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Память2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Правильное использование - через using
            Console.WriteLine("--- Пример 1: using ---");
            using (var obj = new BigMemoryClass(30))
            {
                obj.ShowMemory();
                obj.DoWork();
            } 
            Console.WriteLine();

            // 2. Ручной вызов Dispose
            Console.WriteLine("--- Пример 2: ручной Dispose ---");
            var obj2 = new BigMemoryClass(20);
            obj2.ShowMemory();
            obj2.Dispose();
            Console.WriteLine();

            // 3. Без Dispose 
            Console.WriteLine("--- Пример 3: без Dispose ---");
            var obj3 = new BigMemoryClass(10);
            obj3.ShowMemory();
            obj3 = null; 

            Console.WriteLine("Вызов GC.Collect()...");
            GC.Collect();
            GC.WaitForPendingFinalizers(); 
            Console.WriteLine();

            // 4. Информация о GC
            Console.WriteLine("--- Информация о GC ---");
            Console.WriteLine($"Поколение 0: {GC.CollectionCount(0)} сборок");
            Console.WriteLine($"Поколение 1: {GC.CollectionCount(1)} сборок");
            Console.WriteLine($"Поколение 2: {GC.CollectionCount(2)} сборок");
            Console.WriteLine($"Память GC: {GC.GetTotalMemory(false) / (1024.0 * 1024.0):F1} МБ");

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
