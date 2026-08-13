using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Citizen
    {
        public string Name { get; set; }
        public string PassportNumber { get; set; }

        public int Age { get; set; }

        public Citizen(string name, string passportNumberm, int age) 
        {
            Name = name;
            PassportNumber = passportNumberm;
            Age = age;
        }

        public override bool Equals(object obj)
        {
            if (obj is Citizen obj2) return PassportNumber == obj2.PassportNumber;
            return false;
        }

        public override int GetHashCode()
        {
            return PassportNumber?.GetHashCode() ?? 0;
        }

        
    }
}
