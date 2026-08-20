using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Обобщённые_типы_2
{
    internal class Storage<T>
    {
        private T[] mas;

        private int count; 

        public int Count => mas.Length;

        public Storage(int capacity)
        {
            mas = new T[capacity];
            count = 0;
        }

        public void Add(T obj)
        {
            if (count < mas.Length)
            {
                mas[count] = obj;
                count++;
            }
            else
            {
                throw new InvalidOperationException("Хранилище заполнено");
            }
        }

        public T Get(int id)
        {
            if (id >= 0 && id < count)
            {
                return mas[id];
            }
            throw new IndexOutOfRangeException("Индекс вне диапазона");
        }



    }
}
