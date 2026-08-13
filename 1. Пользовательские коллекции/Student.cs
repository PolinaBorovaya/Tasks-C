using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student : Citizen
    {
        public string University { get; set; }

        public Student(string name, string passportNumber, int age, string university) : base(name, passportNumber, age)
        {
            University = university;
        }
    }
}
