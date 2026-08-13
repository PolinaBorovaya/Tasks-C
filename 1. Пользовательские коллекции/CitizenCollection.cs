using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CitizenCollection : IEnumerable
    {
        private ArrayList citizens = new ArrayList();

        public int Add(Citizen citizen)
        {
            int position = 0;

            if (citizen == null)
            {
                Console.WriteLine("Вы не ввели данные\n");
                return -1;
            }


            foreach (Citizen existing in citizens)
            {
                if (existing.Equals(citizen))
                {
                    Console.WriteLine("Такой человек уже есть в базе \n");
                    return -1;
                }
            }

            if (citizen is Pensioner)
            {
                int insertIndex = 0;

                foreach(Citizen existing in citizens)
                {
                    if (existing is Pensioner)
                    {
                        insertIndex++;
                    }
                    else break;
                }

                citizens.Insert(insertIndex, citizen);
                position = insertIndex;
            }
            else
            {
                position = citizens.Count;
                citizens.Add(citizen);
            }

            Console.WriteLine($"Был добавлен: {citizen.Name}. Место в очереди: {position + 1} \n");
            return position;
        }

        public Citizen RemoveFirst()
        {
            if(citizens.Count == 0)
            {
                Console.WriteLine("Ещё никого нет в очереди\n");
                return null;
            }
            Citizen first = (Citizen)citizens[0];
            citizens.Remove(first);
            Console.WriteLine($"Первый из очереди был удалён: {first.Name} \n");
            return first;
        }

        public bool Remove(Citizen citizen)
        {
            if (citizens.Count == 0)
            {
                Console.WriteLine("Ещё никого нет в очереди \n");
                return false;
            }

            foreach(Citizen existing in citizens)
            {
                if (citizen.Equals(existing))
                {
                    citizens.Remove(citizen);
                    Console.WriteLine($"{citizen.Name} был удалён из очереди \n");
                    return true;
                }
            }

            Console.WriteLine("Такого человека нет в очереди\n");
            return false;
        }

        public void GetAll()
        {
            if(citizens.Count == 0)
            {
                Console.WriteLine("Коллекция пуста\n");
                return;
            }

            for (int i = 0; i < citizens.Count; i++)
            {
                Citizen citizen = (Citizen)citizens[i];
                Console.WriteLine($"{i+1}. {citizen.Name}");
            }
            Console.WriteLine();
        }

        public bool Contains(Citizen citizen, out int position)
        {
            position = 0;
            for(int i = 0; i < citizens.Count; i++)
            {
                Citizen existing = (Citizen)citizens[i];
                if (existing.Equals(citizen))
                {
                    position = i;
                    Console.WriteLine($"{citizen.Name} найден {position + 1} в очереди \n");
                    return true;
                }
            }
            Console.WriteLine("Такого человека нет в очереди");
            return false;
        }

        public Citizen ReturnLast(out int position)
        {
            position = citizens.Count - 1;
            Citizen last = (Citizen)citizens[position];
            Console.WriteLine($"Последний человек в очереди - {last.Name} с номером {position + 1} \n");
            return last;
        }

        public void Clear()
        {
            citizens.Clear();
        }

        public IEnumerator GetEnumerator()
        {
            return citizens.GetEnumerator();
        }
    }
}
