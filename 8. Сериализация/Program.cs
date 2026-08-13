using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Сериализация
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>
            {
                new Animal("Бобик", 5, "Собака", 25.5),
                new Animal("Мурка", 3, "Кошка", 4.2),
                new Animal("Рекс", 2, "Собака", 30.0),
                new Animal("Кеша", 1, "Попугай", 0.15),
                new Animal("Марта", 4, "Кошка", 3.8),
                new Animal("Герда", 6, "Собака", 28.0),
                new Animal("Рыжик", 2, "Хомяк", 0.12),
                new Animal("Алиса", 3, "Лиса", 6.5),
                new Animal("Тиша", 1, "Хомяк", 0.08),
                new Animal("Волли", 4, "Попугай", 0.18)
            };

            XmlSerializer listSerializer = new XmlSerializer(typeof(List<Animal>));

            using(FileStream fs = new FileStream("animal.xml", FileMode.Create))
            {
                listSerializer.Serialize(fs, animals);
            }

            using(FileStream fs = new FileStream("animal.xml", FileMode.Open))
            {
                List<Animal> animals2 = (List<Animal>)listSerializer.Deserialize(fs); 
                foreach(Animal animal in animals2)
                {
                    Console.WriteLine(animal);
                }
            }
        }
    }
}
