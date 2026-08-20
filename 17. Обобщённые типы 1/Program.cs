using _17.Обобщённые_типы_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Обобщённые_типы_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bookStorage = new Storage<Book>();

            Console.WriteLine("=== КНИГИ ===");

            Book book1 = new Book("Война и мир", "Лев Толстой");
            Book book2 = new Book("Преступление и наказание", "Фёдор Достоевский");
            Book book3 = new Book("Мастер и Маргарита", "Михаил Булгаков");
            Book book4 = new Book("1984", "Джордж Оруэлл");
            Book book5 = new Book("Гарри Поттер", "Дж.К. Роулинг");
            bookStorage.AddItem(book1);
            bookStorage.AddItem(book2);
            bookStorage.AddItem(book3);
            bookStorage.AddItem(book4);
            bookStorage.AddItem(book5);

            foreach(var book in bookStorage)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine();

            var books = bookStorage.GetAll();

            var foundBook = bookStorage.FindItem(books, b => b.Title == "1984");
            Console.WriteLine($"Поиск книги по названию '1984': {foundBook} \n");

            bookStorage.RemoveItem(book1);
            Console.WriteLine($"Книга {book1} была удалена \n");

            foreach (var book in bookStorage)
            {
                Console.WriteLine(book);
            }



            Console.WriteLine("\n=== ТЕЛЕФОНЫ ===\n");

            var phoneStorage = new Storage<Phone>();

            Phone phone1 = new Phone("iPhone 15 Pro", 1099.99);
            Phone phone2 = new Phone("Samsung Galaxy S24", 999.99);
            Phone phone3 = new Phone("Google Pixel 8", 799.99);
            Phone phone4 = new Phone("Xiaomi Mi 14", 699.99);
            Phone phone5 = new Phone("OnePlus 12", 899.99);

            phoneStorage.AddItem(phone1);
            phoneStorage.AddItem(phone2);
            phoneStorage.AddItem(phone3);
            phoneStorage.AddItem(phone4);
            phoneStorage.AddItem(phone5);

            foreach (var phone in phoneStorage)
            {
                Console.WriteLine($"{phone}");
            }

            Console.WriteLine();

            var phones = phoneStorage.GetAll();
            var foundPhone = phoneStorage.FindItem(phones, p => p.Model == "Google Pixel 8");
            Console.WriteLine($"Поиск телефона по модели 'Google Pixel 8': {foundPhone} \n");

            phoneStorage.RemoveItem(phone3);
            Console.WriteLine($"Телефон '{phone3.Model}' был удален\n");

            foreach (var phone in phoneStorage)
            {
                Console.WriteLine($"{phone}");
            }



            Console.WriteLine("\n=== ФРУКТЫ ===\n");

            var fruitStorage = new Storage<Fruit>();

            Fruit fruit1 = new Fruit("Яблоко", 2.5);
            Fruit fruit2 = new Fruit("Банан", 1.8);
            Fruit fruit3 = new Fruit("Апельсин", 2.0);
            Fruit fruit4 = new Fruit("Виноград", 1.2);
            Fruit fruit5 = new Fruit("Клубника", 0.8);

            fruitStorage.AddItem(fruit1);
            fruitStorage.AddItem(fruit2);
            fruitStorage.AddItem(fruit3);
            fruitStorage.AddItem(fruit4);
            fruitStorage.AddItem(fruit5);

            foreach (var fruit in fruitStorage)
            {
                Console.WriteLine($"{fruit}");
            }

            Console.WriteLine();

            var fruits = fruitStorage.GetAll();
            var foundFruit = fruitStorage.FindItem(fruits, f => f.Name == "Апельсин");
            Console.WriteLine($"Поиск фрукта по названию 'Апельсин': {foundFruit} \n");

            fruitStorage.RemoveItem(fruit3);
            Console.WriteLine($"Фрукт '{fruit3.Name}' был удален \n");

            foreach (var fruit in fruitStorage)
            {
                Console.WriteLine($"{fruit}");
            }
        }
    }
}
