using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Обобщённые_типы_1.Classes
{
    internal class Fruit
    {
        public string Name { get; set;  }
        public double Weight { get; set;  }

        public Fruit(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Name}: {Weight}";
        }
    }
}
