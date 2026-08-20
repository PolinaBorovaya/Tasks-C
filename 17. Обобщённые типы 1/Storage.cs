using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Обобщённые_типы_1
{
    internal class Storage<T> : IEnumerable<T>
    {
        private List<T> list = new List<T>();

        public void AddItem(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Товар не может быть null");

            list.Add(item);
        }

        public bool RemoveItem(T item)
        {
            if (item == null) return false;
            list.Remove(item);
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return list.AsReadOnly();
        }

        public T FindItem(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
