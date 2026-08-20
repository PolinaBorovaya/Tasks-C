using System;
using System.Reflection;

namespace Рефлексия
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string assemblyPath = "TemperatureConverter.dll";
                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                Console.WriteLine($"Сборка загружена: {assembly?.GetName().Name}");
                Console.WriteLine($"Версия: {assembly?.GetName().Version}");
                Console.WriteLine();

                Type converterType = assembly.GetType("TemperatureConverter.Converter");
                if (converterType == null)
                {
                    Console.WriteLine("Тип не найден!");
                    return;
                }

                Console.WriteLine("ЧТО ПОКАЗЫВАТЬ?");
                Console.WriteLine("  1. Только методы");
                Console.WriteLine("  2. Только свойства");
                Console.WriteLine("  3. Методы и свойства");
                Console.WriteLine("  4. Всё (методы, свойства, поля)");
                Console.Write("Выбор: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("АТРИБУТЫ ТИПА");
                ShowAttributes(converterType);

                Console.WriteLine("\nЧЛЕНЫ ТИПА");

                switch (choice)
                {
                    case "1":
                        Methods(converterType);
                        break;
                    case "2":
                        Properties(converterType);
                        break;
                    case "3":
                        Methods(converterType);
                        Properties(converterType);
                        break;
                    case "4":
                        Methods(converterType);
                        Properties(converterType);
                        Fields(converterType);
                        break;
                    default:
                        Console.WriteLine("Введите существующий пункт меню");
                        break;
                }

                Console.WriteLine("\n" + new string('=', 60));
                object converterInstance = Activator.CreateInstance(converterType);

                Console.WriteLine("\nКОНВЕРТАЦИЯ ТЕМПЕРАТУРЫ");

                MethodInfo method1 = converterType.GetMethod("CelsiusToFahrenheit");
                if (method1 == null)
                {
                    Console.WriteLine("Метод CelsiusToFahrenheit не найден!");
                    return;
                }

                Console.Write("\nВведите температуру в °C: ");
                double celsius = double.Parse(Console.ReadLine());

                object result1 = method1.Invoke(converterInstance, new object[] { celsius });
                Console.WriteLine($"{celsius}°C = {result1:F2}°F");

                MethodInfo method2 = converterType.GetMethod("FahrenheitToCelsius");
                if (method2 == null)
                {
                    Console.WriteLine("Метод FahrenheitToCelsius не найден!");
                    return;
                }

                Console.Write("\nВведите температуру в °F: ");
                double fahrenheit = double.Parse(Console.ReadLine());

                object result2 = method2.Invoke(converterInstance, new object[] { fahrenheit });
                Console.WriteLine($"{fahrenheit}°F = {result2:F2}°C");

                Console.WriteLine("\n" + new string('=', 60));
                Console.WriteLine("\nАТРИБУТЫ СБОРКИ");
                ShowAttributes(assembly);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }


        static void Methods(Type type)
        {
            Console.WriteLine("\n МЕТОДЫ:");
            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
            );

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine($"\n  Метод: {method.Name}");
                Console.WriteLine($"    Возвращает: {method.ReturnType.Name}");

                var parameters = method.GetParameters();
                if (parameters.Length > 0)
                {
                    Console.Write("    Параметры: ");
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                        if (i < parameters.Length - 1) Console.Write(", ");
                    }
                    Console.WriteLine();
                }

                ShowAttributes(method, "    ");
            }
        }

        static void Properties(Type type)
        {
            Console.WriteLine("\n СВОЙСТВА:");
            PropertyInfo[] properties = type.GetProperties(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
            );

            if (properties.Length == 0)
            {
                Console.WriteLine("  (нет свойств)");
            }
            else
            {
                foreach (PropertyInfo prop in properties)
                {
                    Console.WriteLine($"\n  Свойство: {prop.Name}");
                    Console.WriteLine($"    Тип: {prop.PropertyType.Name}");

                    string getSet = "";
                    if (prop.GetMethod != null) getSet += "get; ";
                    if (prop.SetMethod != null) getSet += "set;";
                    Console.WriteLine($"    Доступ: {{ {getSet} }}");

                    ShowAttributes(prop, "    ");
                }
            }
        }

        static void Fields(Type type)
        {
            Console.WriteLine("\n ПОЛЯ:");
            FieldInfo[] fields = type.GetFields(
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
            );

            if (fields.Length == 0)
            {
                Console.WriteLine("  (нет полей)");
            }
            else
            {
                foreach (FieldInfo field in fields)
                {
                    Console.WriteLine($"\n  Поле: {field.Name}");
                    Console.WriteLine($"    Тип: {field.FieldType.Name}");
                    ShowAttributes(field, "    ");
                }
            }
        }

        static void ShowAttributes(Type type)
        {
            object[] attributes = type.GetCustomAttributes(false);

            if (attributes.Length == 0)
            {
                Console.WriteLine("  (нет атрибутов)");
                return;
            }

            foreach (object attr in attributes)
            {
                Type attrType = attr.GetType();
                Console.WriteLine($"  [{attrType.Name}]");

                PropertyInfo[] props = attrType.GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    try
                    {
                        object value = prop.GetValue(attr);
                        if (value != null && prop.Name != "TypeId")
                        {
                            Console.WriteLine($"    {prop.Name} = {value}");
                        }
                    }
                    catch { }
                }
            }
        }

        static void ShowAttributes(MethodInfo method, string prefix = "")
        {
            object[] attributes = method.GetCustomAttributes(false);

            if (attributes.Length == 0)
            {
                Console.WriteLine($"{prefix}(нет атрибутов)");
                return;
            }

            foreach (object attr in attributes)
            {
                Type attrType = attr.GetType();
                Console.WriteLine($"{prefix}[{attrType.Name}]");

                PropertyInfo[] props = attrType.GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    try
                    {
                        object value = prop.GetValue(attr);
                        if (value != null && prop.Name != "TypeId")
                        {
                            Console.WriteLine($"{prefix}  {prop.Name} = {value}");
                        }
                    }
                    catch { }
                }
            }
        }

        static void ShowAttributes(PropertyInfo property, string prefix = "")
        {
            object[] attributes = property.GetCustomAttributes(false);

            if (attributes.Length == 0)
            {
                Console.WriteLine($"{prefix}(нет атрибутов)");
                return;
            }

            foreach (object attr in attributes)
            {
                Type attrType = attr.GetType();
                Console.WriteLine($"{prefix}[{attrType.Name}]");

                PropertyInfo[] props = attrType.GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    try
                    {
                        object value = prop.GetValue(attr);
                        if (value != null && prop.Name != "TypeId")
                        {
                            Console.WriteLine($"{prefix}  {prop.Name} = {value}");
                        }
                    }
                    catch { }
                }
            }
        }

        static void ShowAttributes(FieldInfo field, string prefix = "")
        {
            object[] attributes = field.GetCustomAttributes(false);

            if (attributes.Length == 0)
            {
                Console.WriteLine($"{prefix}(нет атрибутов)");
                return;
            }

            foreach (object attr in attributes)
            {
                Type attrType = attr.GetType();
                Console.WriteLine($"{prefix}[{attrType.Name}]");

                PropertyInfo[] props = attrType.GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    try
                    {
                        object value = prop.GetValue(attr);
                        if (value != null && prop.Name != "TypeId")
                        {
                            Console.WriteLine($"{prefix}  {prop.Name} = {value}");
                        }
                    }
                    catch { }
                }
            }
        }

        static void ShowAttributes(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(false);

            if (attributes.Length == 0)
            {
                Console.WriteLine("  (нет атрибутов)");
                return;
            }

            foreach (object attr in attributes)
            {
                Type attrType = attr.GetType();
                Console.WriteLine($"  [{attrType.Name}]");

                PropertyInfo[] props = attrType.GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    try
                    {
                        object value = prop.GetValue(attr);
                        if (value != null && prop.Name != "TypeId")
                        {
                            Console.WriteLine($"    {prop.Name} = {value}");
                        }
                    }
                    catch { }
                }
            }
        }
    }
}