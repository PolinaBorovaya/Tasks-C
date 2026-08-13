using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Полиморфизм.nvi;

namespace Полиморфизм
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ЗАДАНИЕ 1 (Template Method)
            OrderProcessor regular = new RegularOrder();
            OrderProcessor express = new ExpressOrder();
            OrderProcessor wholesale = new WholesaleOrder();

            Console.WriteLine("Выполнение для RegularOrder:");
            regular.ProcessOrder("Ноутбук", 2);

            Console.WriteLine("Выполнение для ExpressOrder:");
            express.ProcessOrder("Смартфон", 3);

            Console.WriteLine("Выполнение для WholesaleOrder:");
            wholesale.ProcessOrder("Монитор", 100);

            Console.WriteLine('\n'); 

            //ЗАДАНИЕ 2 (NVI)
            Animal[] animals = { new Dog(), new Cat(), new Bird() };

            foreach (var animal in animals)
            {
                animal.Speak();
                animal.Walk();
                Console.WriteLine();
            }

        }
    }
}
