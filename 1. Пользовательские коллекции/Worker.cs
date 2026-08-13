using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Worker : Citizen
    {
        public string Company {  get; set; }

        public Worker(string name, string passportNumber, int age, string company) : base(name, passportNumber, age)
        {
            Company = company;
        }
    }
}
