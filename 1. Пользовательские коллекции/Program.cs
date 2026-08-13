using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            Console.WriteLine("ЗАДАНИЕ 1");

            var citizens = new CitizenCollection();

            var student1 = new Student("Иванов Иван", "1234-567890", 20, "ВГУ");
            var student2 = new Student("Петров Петр", "2345-678901", 18, "БГУ");
            var pensioner1 = new Pensioner("Сидорова Мария", "3456-789012", 71, 1200);
            var pensioner2 = new Pensioner("Козлов Николай", "4567-890123", 79, 1800);
            var worker1 = new Worker("Смирнов Алексей", "5678-901234", 35, "Газпром");
            var worker2 = new Worker("Волкова Елена", "6789-012345", 27, "Яндекс");

            citizens.Add(student1);
            citizens.Add(student2);
            citizens.Add(pensioner1);
            citizens.Add(worker1);
            citizens.Add(worker2);
            citizens.Add(pensioner2);

            citizens.GetAll();

            var worker3 = new Worker("Волкова Елена", "6789-012345", 27, "Яндекс");
            citizens.Add(worker3);

            citizens.RemoveFirst();

            citizens.Remove(worker1);
            citizens.GetAll();

            int position;
            citizens.Contains(student1, out position);

            citizens.ReturnLast(out position);

            citizens.Clear();
            citizens.GetAll();

            /*Задание 2*/
            Console.WriteLine("ЗАДАНИЕ 2");

            int[] mas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = MasSquared(mas);
            
            foreach ( var el in result)
            {
                Console.WriteLine(el);
            }
        }

        public static IEnumerable<int> MasSquared(int[] numbers)
        {
            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                {
                    yield return number * number;
                }

            }
        }




    }
}
