using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Обобщённые_типы_1.Classes
{
    internal class Phone
    {
        public string Model { get; set;  }
        public double Price { get; set;  }

        public Phone(string model, double price)
        {
            Model = model;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Model}: {Price}";
        }
    }
}
