using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _14.TPL_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = Task.Run(() =>
            {
                Parallel.Invoke(
                    () => AdditionTask(),
                    () => MultiplicationTask()
                );
            });

            while (!tasks.IsCompleted)
            {
                Console.WriteLine("Основной поток работает\n");
                Thread.Sleep(100);
            }

            Console.WriteLine("\n\nВсе параллельные задачи завершены");
        }

        static void AdditionTask()
        {
            int sum = 0;
            for (int i = 1; i <= 10; i++)
            {
                sum += i;
                Console.WriteLine($"  Сложение: {sum} (шаг {i})");
                Thread.Sleep(300); 
            }

            Console.WriteLine($"Результат сложения (от 1 до 10) = {sum}");
        }

        static void MultiplicationTask()
        {
            int mult = 1;
            for(int i = 1; i <= 10; i++)
            {
                mult *= i;
                Console.WriteLine($"  Умножение: {mult} (шаг {i})");
                Thread.Sleep(300);
            }

            Console.WriteLine($"Результат умножения (от 1 до 10) = {mult}");
        }
    }
}
