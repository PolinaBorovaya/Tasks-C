using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ввод_вывод2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = @"D:\folders";

            try
            {
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                for(int i = 0; i < 100; i++)
                {
                    string folderName = $"Folder_{i}";
                    string newPath = Path.Combine(path, folderName);
                    Directory.CreateDirectory(newPath);

                    Console.WriteLine($"Папка {i} создана");
                }

                Console.WriteLine("Все папки созданы \n");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.ToString());
            }

            Console.WriteLine("Нажмите enter для удаления");
            Console.ReadLine();

            try
            {
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Папка не существует");
                    return;
                }

                for (int i = 0; i < 100; i++)
                {
                    string folderName = $"Folder_{i}";
                    string newPath = Path.Combine(path, folderName);
                    if (Directory.Exists(newPath))
                    {
                        Directory.Delete(newPath);

                        Console.WriteLine($"Папка {i} удалена");
                    }
                    else Console.WriteLine($"Папка {i} не найдена");

                }

                Console.WriteLine("Все папки удалены \n");

                if (Directory.Exists(path) && Directory.GetFiles(path).Length == 0)
                {
                    Directory.Delete(path);
                    Console.WriteLine("Корневая папка удалена");
                }
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка: " + ex.ToString()); }


        }
    }
}
