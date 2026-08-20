using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Синхронизация1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MANUALRESETEVENT\n");
            DemonstrateManualResetEvent();

            Console.WriteLine();

            Console.WriteLine("\n\nAUTORESETEVENT\n");
            DemonstrateAutoResetEvent();
        }

        static void DemonstrateManualResetEvent()
        {
            using(var manual = new ManualResetEvent(false))
            {
                var waitingThread = new Thread(() =>
                {
                    Console.WriteLine("[Ожидающий] Поток запущен, ждет сигнал...");
                    manual.WaitOne();
                    Console.WriteLine("[Ожидающий] Сигнал получен!");

                    Console.WriteLine("[Ожидающий] Ждем повторный сигнал...");
                    manual.WaitOne();
                    Console.WriteLine("[Ожидающий] Сигнал снова получен!");
                });

                var signalingThread = new Thread(() =>
                {
                    Console.WriteLine("[Сигнальный] Поток готовится отправить сигнал...");
                    Thread.Sleep(2000);
                    Console.WriteLine("[Сигнальный] Отправка сигнала");
                    manual.Set();

                    Thread.Sleep(1000);
                    Console.WriteLine("[Сигнальный] Сброс события");
                    manual.Reset();
                });

                waitingThread.Start();
                signalingThread.Start();

                waitingThread.Join();
                signalingThread.Join();

            }
        }

        static void DemonstrateAutoResetEvent()
        {
            using (var auto = new AutoResetEvent(false))
            {
                var waitingThread = new Thread(() =>
                {
                    Console.WriteLine("[Ожидающий] Поток запущен, ждет сигнал...");
                    auto.WaitOne();
                    Console.WriteLine("[Ожидающий] Сигнал получен!");

                    Console.WriteLine("[Ожидающий] Ждем снова повторный сигнал");
                    auto.WaitOne();
                    Console.WriteLine("[Ожидающий] Получили второй сигнал!");
                });

                var signalingThread = new Thread(() =>
                {
                    Console.WriteLine("[Сигнальный] Поток готовится отправить сигнал...");
                    Thread.Sleep(2000);
                    Console.WriteLine("[Сигнальный] Отправка первого сигнала");
                    auto.Set();

                    Thread.Sleep(1000);
                    Console.WriteLine("[Сигнальный] Отправка второго сигнала");
                    auto.Set();
                });

                waitingThread.Start();
                signalingThread.Start();

                waitingThread.Join();
                signalingThread.Join();

            }
        }
    }
}
