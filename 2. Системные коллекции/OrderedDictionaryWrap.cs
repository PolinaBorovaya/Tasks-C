using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Системные_коллекции
{
    public class OrderedDictionaryWrap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private List<TKey> keys = new List<TKey>();
        private List<TValue> values = new List<TValue>();
        private  IComparer<TKey> comparer;

        public OrderedDictionaryWrap(IComparer<TKey> comparer = null)
        {
            this.comparer = comparer ?? Comparer<TKey>.Default;
        }

        public void Add(TKey key, TValue value)
        {
            if (FindIndex(key) != -1) throw new ArgumentException("Такой ключ уже есть");

            keys.Add(key);
            values.Add(value);
        }

        public void Clear()
        {
            keys.Clear();
            values.Clear();
        }

        public bool ContainsKey(TKey key) => FindIndex(key) != -1;

        public bool Remove(TKey key)
        {
            int index = FindIndex(key);
            if (index == -1) return false;

            keys.RemoveAt(index);
            values.RemoveAt(index);
            return true;
        }

        public bool GetValue(TKey key, out TValue value)
        {
            int index = FindIndex(key);
            if (index != -1)
            {
                value = values[index];
                return true;
            }
            value = default;
            return false;
        }

        public void Insert(int index, TKey key, TValue value)
        {
            if (index < 0 || index > keys.Count) throw new ArgumentOutOfRangeException($"Индекс должен быть от 0 до {keys.Count-1}");

            if (FindIndex(key) != -1) throw new ArgumentException($"Элемент с ключом {key} уже существует");

            keys.Insert(index, key);
            values.Insert(index, value);

        }

        public void GetAll()
        {
            if(keys.Count == 0) Console.WriteLine("Коллекция пуста");

            for(int i = 0; i < keys.Count; i++)
            {
                Console.WriteLine($"{i+1}. {keys[i]} : {values[i]}");
            }
        }

        private int FindIndex(TKey key)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (comparer.Compare(keys[i], key) == 0)
                    return i;
            }
            return -1;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < keys.Count; i++)
                yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
