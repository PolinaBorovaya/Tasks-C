using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Системные_коллекции
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Задание 1*/
            Console.WriteLine("ЗАДАНИЕ 1 \n");
            Dictionary<int, double> dictionary = new Dictionary<int, double>();
            dictionary.Add(101, 15000.50);
            dictionary.Add(102, 23400.75);
            dictionary.Add(103, 8900.00);

            foreach (var item in dictionary)
                Console.WriteLine($"Счет {item.Key}: {item.Value}");
            Console.WriteLine();

            SortedDictionary<int, double> sortedDictionary = new SortedDictionary<int, double>();
            sortedDictionary.Add(101, 15000.50);
            sortedDictionary.Add(102, 23400.75);
            sortedDictionary.Add(103, 8900.00);

            foreach (var item in sortedDictionary)
                Console.WriteLine($"Счет {item.Key}: {item.Value}");
            Console.WriteLine();

            ConcurrentDictionary<int, double> сoncurrentDictionary = new ConcurrentDictionary<int, double>();
            сoncurrentDictionary.TryAdd(101, 15000.50);
            сoncurrentDictionary.TryAdd(102, 23400.75);
            сoncurrentDictionary.TryAdd(103, 8900.00);

            foreach (var item in сoncurrentDictionary)
                Console.WriteLine($"Счет {item.Key}: {item.Value}");
            Console.WriteLine();

            /*Задание 2*/
            Console.WriteLine("ЗАДАНИЕ 2");
            OrderedDictionaryWrap<int, int> orderedDictionary = new OrderedDictionaryWrap<int, int>();

            orderedDictionary.Add(123, 202020204);
            orderedDictionary.Add(432, 322342342);
            orderedDictionary.Add(321, 324234234);
            orderedDictionary.Add(645, 234564523);

            orderedDictionary.GetAll();

            Console.WriteLine();

            try
            {
                orderedDictionary.Add(645, 324344234);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine();

            Console.WriteLine($"Наличие ключа 123: {orderedDictionary.ContainsKey(123)}");
            Console.WriteLine($"Наличие ключа 123: {orderedDictionary.ContainsKey(321)}");

            Console.WriteLine();

            if (orderedDictionary.GetValue(432, out int value1))
                Console.WriteLine($"Ключ 432 существует, значение: {value1}");
            else
                Console.WriteLine("Ключ 432 не найден");

            if (orderedDictionary.GetValue(999, out int value2))
                Console.WriteLine($"Ключ 999 существует, значение: {value2}");
            else
                Console.WriteLine("Ключ 999 не найден");

            Console.WriteLine();

            orderedDictionary.Insert(2, 555, 555555555);
            Console.WriteLine("После вставки (555, 555555555) на позицию 3:");
            orderedDictionary.GetAll();

            try
            {
                orderedDictionary.Insert(1, 123, 111111111);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка (дубликат ключа): {ex.Message}");
            }

            Console.WriteLine();

            orderedDictionary.Clear();
            orderedDictionary.GetAll();

            Console.WriteLine(); 

            Console.WriteLine("Работа с компаратором:");
            var stringDict = new OrderedDictionaryWrap<string, string>(StringComparer.OrdinalIgnoreCase);
            stringDict.Add("One", "Первый");
            stringDict.Add("Two", "Второй");
            stringDict.Add("Three", "Третий");

            stringDict.GetAll();
            Console.WriteLine();

            Console.WriteLine($"Содержит 'one': {stringDict.ContainsKey("one")}");
            Console.WriteLine($"Содержит 'TWO': {stringDict.ContainsKey("TWO")}");
            Console.WriteLine($"Содержит 'four': {stringDict.ContainsKey("four")}");

            try
            {
                stringDict.Insert(2, "one", "Четвёртый");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка (дубликат ключа): {ex.Message}");
            }

            Console.WriteLine(); Console.WriteLine();

            /*Задание 3*/
            Console.WriteLine("ЗАДАНИЕ 3");
            SortedList<string, double> accounts = new SortedList<string, double>
            {
                { "Иванов", 15000.50 },
                { "Петров", 23400.75 },
                { "Сидоров", 8900.00 },
                { "Кузнецов", 12300.25 },
                { "Смирнов", 5600.00 }
            };

            foreach(var item in accounts)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }

            Console.WriteLine();

            for(int i = accounts.Count-1; i >= 0; i--)
            {
                Console.WriteLine($"{accounts.Keys[i]}:{accounts.Values[i]}");
            }

            //ЛИБО

            Console.WriteLine();

            foreach (var item in accounts.Reverse())
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
        }
    }
}
