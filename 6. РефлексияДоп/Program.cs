using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace РефлексияДоп
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string assemblyPath = "TemperatureConverter.dll";

                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                Console.WriteLine($"Сборка: {assembly.GetName().Name}");
                Console.WriteLine($"Версия: {assembly.GetName().Version}");
                Console.WriteLine();

                Type[] types = assembly.GetTypes();
                Console.WriteLine($"Всего типов: {types.Length}\n");


                foreach (Type type in types)
                {
                    Console.WriteLine($"   Тип: {type.Name}");
                    Console.WriteLine($"   Пространство имен: {type.Namespace ?? "(нет)"}");
                    Console.WriteLine($"   Публичный: {type.IsPublic}");
                    Console.WriteLine($"   Класс: {type.IsClass}");

                    MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                    if (methods.Length > 0)
                    {
                        Console.WriteLine($"   Методы ({methods.Length}):");
                        foreach (MethodInfo method in methods)
                        {
                            ParameterInfo[] parameters = method.GetParameters();
                            string paramStr = parameters.Length > 0
                                ? string.Join(", ", Array.ConvertAll(parameters, p =>
                                    $"{p.ParameterType.Name} {p.Name}"))
                                : "нет параметров";

                            Console.WriteLine($"      - {method.ReturnType.Name} {method.Name}({paramStr})");
                        }
                    }
                }

                Console.WriteLine("Анализ завершен!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ошибка: Файл не найден!");
                Console.WriteLine("Проверьте путь к сборке.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

        }
    }
}
