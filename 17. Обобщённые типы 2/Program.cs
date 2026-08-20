using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Обобщённые_типы_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Storage<T> ===");

            Storage<int> storage = new Storage<int>(3);
            storage.Add(10);
            storage.Add(20);
            storage.Add(30);

            Console.WriteLine("Хранилище int:");
            for (int i = 0; i < storage.Count; i++)
            {
                Console.WriteLine($"[{i}] = {storage.Get(i)}");
            }

            Console.WriteLine("\n=== Метод Swap<T> ===");
            int a = 18;
            int b = 50;
            Console.WriteLine($"a = {a}, b = {b}");
            Utils.Swap(ref a, ref b);
            Console.WriteLine($"После swap: a = {a}, b = {b}\n");

            string c = "ccccc";
            string d = "ddddd";
            Console.WriteLine($"c = {c}, d = {d}");
            Utils.Swap(ref c, ref d);
            Console.WriteLine($"После swap: c = {c}, d = {d}\n");


            Console.WriteLine("\n=== List<T> ===");

            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Console.WriteLine("Список чисел:");
            foreach (int item in list)
                Console.Write(item + " ");

            Console.WriteLine("\n\n=== Dictionary<TKey, TValue> ===");

            Dictionary<string, int> ages = new Dictionary<string, int>();
            ages.Add("Анна", 25);
            ages.Add("Иван", 30);
            ages.Add("Мария", 28);

            foreach (var pair in ages)
                Console.WriteLine($"{pair.Key}: {pair.Value} лет");
        }
    }
}
