using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Сериализация
{
    [Serializable]
    public class Animal
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Age { get; set; }
        [XmlAttribute]
        public string Species { get; set; }
        [XmlAttribute]
        public double Weight { get; set; }

        public Animal(){}

        public Animal(string name, int age, string species, double weight)
        {
            Name = name;
            Age = age;
            Species = species;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Species}: {Name}, {Age} лет, {Weight} кг";
        }
    }
}
