using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Память2
{
    public class BigMemoryClass : IDisposable
    {
        private byte[] _bigArray;        
        private IntPtr _nativeBuffer;    
        private bool _disposed = false;
        private readonly int _id;
        private static int _counter = 0;

        public BigMemoryClass(int sizeMB = 50)
        {
            _id = ++_counter;
            Console.WriteLine($"[{_id}] Создан объект");

            _bigArray = new byte[sizeMB * 1024 * 1024];
            Console.WriteLine($"  Выделено {sizeMB} МБ управляемой памяти");

            _nativeBuffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(1024 * 1024);
            Console.WriteLine($"  Выделена неуправляемая память (1 МБ)");
        }

        ~BigMemoryClass()
        {
            Console.WriteLine($"[{_id}] !!! ДЕСТРУКТОР вызван !!!");
            Dispose(false);
        }

        public void Dispose()
        {
            Console.WriteLine($"[{_id}] Dispose вызван явно");
            Dispose(true);
            GC.SuppressFinalize(this); 
            Console.WriteLine($"[{_id}] Очистка завершена");
        }


        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (_bigArray != null)
                {
                    _bigArray = null; 
                    Console.WriteLine($"[{_id}] Массив помечен для GC");
                }
            }

            if (_nativeBuffer != IntPtr.Zero)
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(_nativeBuffer);
                _nativeBuffer = IntPtr.Zero;
                Console.WriteLine($"[{_id}] Неуправляемая память освобождена");
            }

            _disposed = true;
        }

        public void DoWork()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(BigMemoryClass));

            Console.WriteLine($"[{_id}] Выполнение работы...");

            if (_bigArray != null && _bigArray.Length > 0)
            {
                _bigArray[0] = 255; 
            }
            Console.WriteLine($"[{_id}] Работа завершена");
        }

        public void ShowMemory()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(BigMemoryClass));

            long managedSize = _bigArray?.Length ?? 0;
            Console.WriteLine($"[{_id}] Управляемая память: {managedSize / (1024.0 * 1024.0):F1} МБ");
            Console.WriteLine($"[{_id}] GC.GetTotalMemory: {GC.GetTotalMemory(false) / (1024.0 * 1024.0):F1} МБ");
        }
    }
}
