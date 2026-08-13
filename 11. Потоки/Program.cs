using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    internal class Program
    {
        private static int _counter = 0;

        private static readonly object _locker = new object();

        private static int _currentThreadNumber = 1;

        static void Main(string[] args)
        {
            //ЗАДАНИЕ 1
            string outputFile = "output.txt";
            string file1 = "text1.txt";
            string file2 = "text2.txt";

            if (!File.Exists(file1) || !File.Exists(file2))
            {
                Console.WriteLine("Создайте файлы в папке приложения");
                return;
            }

            var writer = new FileWriter(outputFile);

            Thread thread1 = new Thread(() => ReadFile(file1, writer));
            Thread thread2 = new Thread(() => ReadFile(file2, writer));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Готово! Результат в файле {outputFile}");


            //ЗАДАНИЕ 2

            Thread th1 = new Thread(() => Worker(1));
            Thread th2 = new Thread(() => Worker(2));
            Thread th3 = new Thread(() => Worker(3));

            th1.Start();
            th2.Start();
            th3.Start();

            th1.Join();
            th2.Join();
            th3.Join();

            Console.WriteLine("Все потоки завершили работу");

        }

        public static void ReadFile(string filePath, FileWriter fileWriter)
        {
            try
            {
                string[] text = File.ReadAllLines(filePath);
                foreach (string line in text)
                {
                    Thread.Sleep(1000);
                    fileWriter.WriteLine($"[{Path.GetFileName(filePath)}] {line}");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }

        static void Worker(int threadNumber)
        {
            for (int i = 0; i < 10; i++)
            {
                lock (_locker)
                {
                    while(_currentThreadNumber !=  threadNumber)
                    {
                        Monitor.Wait(_locker);
                    }

                    _counter++;
                    Console.WriteLine($"Поток {threadNumber}: {_counter}");

                    if (threadNumber == 3)
                    {
                        _currentThreadNumber = 1;
                    }
                    else
                    {
                        _currentThreadNumber = _currentThreadNumber + 1;
                    }

                    Monitor.PulseAll(_locker);
                }
            }
        }
    }
}
