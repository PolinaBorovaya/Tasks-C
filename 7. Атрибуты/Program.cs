using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLevel
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var employees = new List<Employee>
            {
                new Director("Елена Волкова"),
                new Manager("Иван Петров"),
                new Programmer("Алексей Смирнов"),
                new Programmer("Мария Иванова")
            };

            var accessLevels = new Dictionary<string, AccessLevelAttribute.AccessLevel>
            {
                { "Общая информация", AccessLevelAttribute.AccessLevel.None },
                { "Финансовые отчеты", AccessLevelAttribute.AccessLevel.ReadOnly },
                { "База данных", AccessLevelAttribute.AccessLevel.ReadWrite },
                { "Админ панель", AccessLevelAttribute.AccessLevel.FullAccess }
            };

            foreach (var emp in employees)
            {
                Type type = emp.GetType();
                AccessLevelAttribute attr = (AccessLevelAttribute)Attribute
                    .GetCustomAttribute(type, typeof(AccessLevelAttribute));

                if (attr == null) continue;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{emp.Position}: {emp.Name} (Уровень: {attr.Level})");
                Console.ResetColor();

                foreach (var section in accessLevels)
                {
                    bool hasAccess = (int)attr.Level >= (int)section.Value;

                    Console.Write($"   {section.Key}: ");
                    if (hasAccess)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("ДОСТУП РАЗРЕШЕН");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ДОСТУП ЗАПРЕЩЕН");
                        Console.ResetColor();
                    }
                }

            }

        }


    }
}
