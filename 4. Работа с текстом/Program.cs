using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Работа_с_текстом
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ЗАДАНИЕ 1
            DateTime purchaseDate = DateTime.Now;
            string[] products = { "Хлеб", "Молоко", "Яйца", "Масло" };
            double[] prices = { 45.50, 89.90, 120.00, 215.30 };
            double total = 0;
            foreach (var price in prices) total += price;

            string filePath = @"D:\check.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Дата: {purchaseDate}");
                writer.WriteLine("Товары:");
                for (int i = 0; i < products.Length; i++)
                {
                    writer.WriteLine($"{products[i]} - {prices[i]} руб.");
                }
                writer.WriteLine($"Итого: {total} руб.");
            }

            Console.WriteLine("Файл создан: " + filePath);
            Console.WriteLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Такого файла не существует");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            DateTime date = DateTime.Parse(lines[0].Substring(6));

            int productCount = lines.Length - 3; 
            string[] productsFromFile = new string[productCount];
            double[] pricesFromFile = new double[productCount];

            for (int i = 0; i < productCount; i++)
            {
                string[] parts = lines[i + 2].Split('-'); 
                productsFromFile[i] = parts[0].Trim();
                pricesFromFile[i] = double.Parse(parts[1].Trim().Replace(" руб.", ""));
            }

            double totalFromFile = double.Parse(lines[lines.Length - 1].Substring(7).Replace(" руб.", ""));

            Console.WriteLine("ТЕКУЩАЯ ЛОКАЛЬ (ru-RU)");
            Console.WriteLine($"Дата: {date}");
            for (int i = 0; i < productsFromFile.Length; i++)
                Console.WriteLine($"{productsFromFile[i]} - {pricesFromFile[i].ToString("C")}");
            Console.WriteLine($"Итого: {totalFromFile.ToString("C")}");
            Console.WriteLine();

            CultureInfo enUS = new CultureInfo("en-US");

            Console.WriteLine("ЛОКАЛЬ en-US");
            Console.WriteLine($"Дата: {date.ToString(enUS)}");
            for (int i = 0; i < productsFromFile.Length; i++)
                Console.WriteLine($"{productsFromFile[i]} - {pricesFromFile[i].ToString("C", enUS)}");
            Console.WriteLine($"Итого: {totalFromFile.ToString("C", enUS)}");

            Console.WriteLine();

            //ЗАДАНИЕ 2

            bool isValidLogin = false;

            while (!isValidLogin)
            {
                Console.WriteLine("Введите логин: ");
                string login = Console.ReadLine();

                if(Regex.IsMatch(login, @"^[a-zA-Z]+$"))
                {
                    isValidLogin = true;
                    
                }
                else
                {
                    Console.WriteLine("Должны быть только латинские символы. Повторите ввод");
                }
            }

            bool isValidPassword = false;

            while (!isValidPassword)
            {
                Console.WriteLine("Введите пароль: ");
                string password = Console.ReadLine();

                if(Regex.IsMatch(password, @"^[0-9!@#$%^&*()]+$"))
                {
                    isValidPassword = true;
                }
                else
                {
                    Console.WriteLine("Должны быть только цифры и символы. Повторите ввод");
                }
            }









        }
    }
}