using System;
using System.IO;
using System.Threading;

namespace Синхронизация3
{
    internal class Program
    {
        private static SemaphoreSlim semaphore = new SemaphoreSlim(3, 3);
        private static readonly object logLock = new object();
        private static readonly string logFile = "access.log";
        private static int completedThreads = 0;
        private static readonly int totalThreads = 8;

        static void Main(string[] args)
        {

            for (int i = 1; i <= totalThreads; i++)
            {
                int threadId = i;
                ThreadPool.QueueUserWorkItem(state => AccessResource(threadId));
            }

            while (completedThreads < totalThreads)
            {
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nВсе потоки завершили работу.");
            Console.WriteLine($"Лог сохранён в файл: {logFile}");
        }

        static void Log(string message)
        {
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            string fullMessage = $"[{time}] {message}\n";

            lock (logLock)
            {
                try
                {
                    Console.Write(fullMessage);
                    File.AppendAllText(logFile, fullMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка записи в лог: {ex.Message}");
                }
            }
        }

        static void AccessResource(int number)
        {
            Log($"Поток {number}: Ожидает доступа к ресурсу.");

            semaphore.Wait();

            int freeSlots = semaphore.CurrentCount;

            try
            {
                Log($"Поток {number}: Получил доступ (свободно: {freeSlots})");

 
                Thread.Sleep(new Random().Next(1000, 3000));


                if (number == 5 && new Random().Next(2) == 0)
                {
                    throw new Exception($"Поток {number} сгенерировал ошибку!");
                }

                Log($"Поток {number}: Освободил ресурс (свободно было: {freeSlots})");
            }
            catch (Exception ex)
            {
                Log($"Поток {number}: {ex.Message}");
            }
            finally
            {
                semaphore.Release();
                Interlocked.Increment(ref completedThreads);
            }
        }
    }
}