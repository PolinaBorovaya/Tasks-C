using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Dynamic;
using System.Collections.Generic;

namespace Работа_с_текстом
{
    internal class Program
    {
        public static string loginRegex = @"^[a-zA-Z]+$";
        public static string passwordRegex = @"^[0-9!@#$%^&*()]+$";

        static DateTime ParseDate(string[] lines)
        {
            foreach (var line in lines)
            {
                if (line.StartsWith("Дата:"))
                {
                    string dateStr = line.Substring("Дата:".Length).Trim();
                    return DateTime.Parse(dateStr);
                }
            }
            return DateTime.Now; 
        }

        static (string[] products, double[] prices) ParseProducts(string[] lines)
        {
            var productsList = new List<string>();
            var pricesList = new List<double>();

            foreach (var line in lines)
            {
                if (line.Contains("-") && line.Contains("руб.") && !line.Contains("Итого"))
                {
                    string[] parts = line.Split('-');
                    if (parts.Length == 2)
                    {
                        string product = parts[0].Trim();
                        string priceStr = parts[1].Trim().Replace("руб.", "").Trim();

                        if (double.TryParse(priceStr, out double price))
                        {
                            productsList.Add(product);
                            pricesList.Add(price);
                        }
                    }
                }
            }

            return (productsList.ToArray(), pricesList.ToArray());
        }

        static double ParseTotal(string[] lines)
        {
            foreach (var line in lines)
            {
                if (line.StartsWith("Итого:"))
                {
                    string totalStr = line.Substring("Итого:".Length).Trim().Replace("руб.", "").Trim();
                    if (double.TryParse(totalStr, out double total))
                    {
                        return total;
                    }
                }
            }
            return 0; 
        }

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

            var date = ParseDate(lines);

            var (productsFromFile, pricesFromFile) = ParseProducts(lines);

            double totalFromFile = ParseTotal(lines);

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

                if(Regex.IsMatch(login, loginRegex))
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

                if(Regex.IsMatch(password, passwordRegex))
                {
                    isValidPassword = true;
                }
                else
                {
                    Console.WriteLine("Должны быть только цифры и символы. Поz вторите ввод");
                }
            }









        }
    }
}